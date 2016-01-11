using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PetjeOp
{
    // De MasterController wordt altijd meegegeven, gebruik is bijv. alsvolgt:
    // Question q = masterController.DB.GetQuestion(id);
    public class Database
    {
        // Initialiseren van de database connectie die vervolgens gebruikt wordt voor LinqtoSQL
        DatabaseDataContext db = new DatabaseDataContext();

        public Boolean QuestionContainsAnswerFromUser(Exam Exam, Student student, Question Question)
        {
            db = new DatabaseDataContext();

            tblResult result = db.tblResults.SingleOrDefault(g => g.student == student.StudentNr && g.exam == Exam.Examnr && g.question == Question.ID);

            if (result != null)
            {
                return true;
            }

            return false;
        }

        public List<tblExam> GetExamsOfStudent(String StudentNR)
        {
            tblStudent student = db.tblStudents.SingleOrDefault(g => g.nr == StudentNR);

            List<tblExam> exams = db.tblExams.Where(g => g.tblLecture.@class == student.@class && g.starttime <= DateTime.Now && g.endtime >= DateTime.Now).ToList();

            return exams;
        }

        // Voegt een resultaat toe van een antwoord op een vraag in een examen.
        public void InsertResult(tblResult Result)
        {
            // Wordt aangeroepen om de gehele enity te refreshen. Inverband met foreign-keys...
            db = new DatabaseDataContext();
            try
            {
                db.tblResults.InsertOnSubmit(Result);
                db.SubmitChanges();
                db.Refresh(RefreshMode.OverwriteCurrentValues, db.tblResults);
            }
            catch (Exception)
            {
                System.Console.WriteLine("Kon antwoord niet opslaan");
            }

        }

        // Deze functie controlleert of er geen Results zijn voor een Exam van een bepaalde Questionnaire
        public Boolean QuestionnaireContainsResults(int id)
        {
            //Selecteer de Questionnaire voor het ID
            tblQuestionnaire dbQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == id);

            //Loop door de examens
            foreach (tblExam exam in dbQuestionnaire.tblExams.ToList())
            {
                //Controleer of er results zijn voor dit Exam, Mocht dit zo zijn; return meteen true;
                if ((db.tblResults.Where(q => q.exam == exam.id)).Count() != 0)
                {
                    return true;
                }
            }

            return false;
        }

        // Deze functie wordt gebruikt om een vraag op te halen uit de database, het ID wordt hiervoor meegegeven
        public MultipleChoiceQuestion GetQuestion(int id)
        {
            try
            {
                // Eerst wordt de query uitgevoerd welke de vraag selecteerd op basis van het meegegeven ID
                tblQuestion dbQuestion = db.tblQuestions.SingleOrDefault(q => q.id == id);

                // Hier wordt gecontrolleerd of de query gelukt is, 
                // null staat immers voor een niet geslaagde query of een query zonder resultaten
                if (dbQuestion != null)
                {
                    // Hier wordt een nieuwe vraag aangemaakt via de contstructor van MultipleChoiceQuestion
                    // De description wordt hieraan meegegeven, die met de query is opgehaald
                    MultipleChoiceQuestion question = new MultipleChoiceQuestion(dbQuestion.description);
                    question.ID = id;
                    // Vervolgens wordt het ID van het Question object toegevoegd, dit is hetzelfde ID dan degene in de database

                    List<Answer> answerOptions = new List<Answer>();
                    // Lijst met answeropties wordt aangemaakt, welke straks gevult wordt
                    List<tblAnsweroption> dbAnsweroption = dbQuestion.tblAnsweroptions.ToList();
                    // Lijst met tblAnsweropties, welke straks doorlopen wordt

                    if (dbQuestion.timerestriction != null)
                    {
                        question.TimeRestriction = TimeSpan.FromTicks((long)dbQuestion.timerestriction);
                    }
                    else
                    {
                        question.TimeRestriction = TimeSpan.Zero;
                    }

                    foreach (tblAnsweroption dbAnswerOption in dbAnsweroption)
                    {
                        // Doorloopt de antwoordopties die een foreign key naar de geselecteerde question in de database hebben
                        // Doordat we data hebben van onze answeroption, kunnen we nu ook de gehele vraag halen
                        tblAnswer tblAnswer = dbAnswerOption.tblAnswer; // Cast antwoordtabel in variable

                        Answer answer = new Answer(tblAnswer.description); // Maakt een nieuw antwoord aan
                        answer.ID = tblAnswer.id; // Werkt het id bij naar degene die ook in de database gebruikt wordt

                        if (dbQuestion.correctanswer == tblAnswer.id)
                        {
                            question.CorrectAnswer = answer;
                        }
                        answerOptions.Add(answer);
                        // Voegt het antwoord object toe aan de lijst van antwoordopties die straks toegevoegd wordt aan de vraag
                    }

                    // Voegt de lijst met antwoord opties toe aan de vraag
                    question.AnswerOptions = answerOptions;

                    return question;
                }
                // Als de query gefaalt is return null, deze wordt later opgevangen
                return null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Deze functie wordt gebruikt om een vragenlijst op te halen uit de database, het ID wordt hiervoor meegegeven
        public Questionnaire GetQuestionnaire(int id)
        {
            try
            {
                // Query die questionnaire op id selecteerd en opslaat in het Linq tblQuestionnaire object
                tblQuestionnaire dbQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == id);

                if (dbQuestionnaire != null)
                {
                    return ConvertDbQuestionnaire(dbQuestionnaire);
                }
                return null;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public void UpdateQuestionnaire(Questionnaire questionnaire, List<Question> deletedQuestions = null)
        {
            try
            {
                tblQuestionnaire updateQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == questionnaire.ID); // Haalt questionnaire op uit DB
                updateQuestionnaire.description = questionnaire.Name; // Wijzigingen toepassen
                updateQuestionnaire.archived = questionnaire.Archived;

                if (deletedQuestions != null) // Als er vragen zijn verwijderd, bevinden deze zich niet meer in het object Questionnaire daarvoor is een aparte lijst meegegeven
                {
                    foreach (MultipleChoiceQuestion delQuestion in deletedQuestions)
                    {
                        DeleteMultipleChoiceQuestion(delQuestion.ID); // Verwijder de desbetreffende vraag
                    }
                }

                foreach (MultipleChoiceQuestion question in questionnaire.Questions)
                {
                    tblQuestion dbQuestion = null;
                    if (question.ID == -1)
                    {
                        dbQuestion = AddMultipleChoiceQuestion(question, questionnaire.ID);
                    }
                    else
                    {
                        dbQuestion = updateQuestionnaire.tblQuestions.SingleOrDefault(q => q.id == question.ID);
                        dbQuestion.description = question.Description; // Wijzigt de vraag in DB

                        foreach (tblAnsweroption dbLinkAnwser in dbQuestion.tblAnsweroptions.ToList()) // Doorloopt lijst van bijbehorende answers uit DB
                        {
                            tblAnswer dbAnswer = dbLinkAnwser.tblAnswer;
                            Answer answer = question.AnswerOptions.Single(a => a.ID == dbLinkAnwser.answer); // Haalt Answer op uit Question
                            dbAnswer.description = answer.Description; // Wijzigt het antwoord in DB
                        }
                        dbQuestion.correctanswer = question.CorrectAnswer.ID;
                    }
                    if (dbQuestion != null)
                    {
                        updateQuestionnaire.tblQuestions.Add(dbQuestion);
                    }
                }
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
        }

        // Haal studentgegevens op met behulp van de studentcode
        public Student GetStudent(String code)
        {
            try
            {
                Student person = (from tblStudent in db.tblStudents
                                  where tblStudent.nr == code
                                  select new Student
                                  {
                                      StudentNr = tblStudent.nr,
                                      FirstName = tblStudent.firstname,
                                      SurName = tblStudent.surname,
                                      GroupNr = tblStudent.@class

                                  }).FirstOrDefault();

                if (person != null)
                {
                    return person; // Returnt, uit database opgehaalde, Student.
                }
                return null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Teacher GetTeacher(String code) // Returnt een Teacher als deze bestaat, anders NULL.
        {
            try
            {
                Teacher person = (from tblTeacher in db.tblTeachers
                                  where tblTeacher.nr == code
                                  select new Teacher
                                  {
                                      TeacherNr = tblTeacher.nr,
                                      FirstName = tblTeacher.firstname,
                                      SurName = tblTeacher.surname

                                  }).FirstOrDefault();

                if (person != null)
                {
                    return person; // Returnt, uit database opgehaalde, Teacher.
                }
                return null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Questionnaire AddQuestionnaire(Teacher teacher, Questionnaire questionnaire)
        {
            try
            {
                tblQuestionnaire dbQuestionnaire = new tblQuestionnaire()
                {
                    author = questionnaire.Author.TeacherNr,
                    description = questionnaire.Name,
                    subject = questionnaire.Subject.Id
                };
                questionnaire.ID = dbQuestionnaire.id;

                //Loop door alle vragen heen
                foreach (MultipleChoiceQuestion question in questionnaire.Questions)
                {
                    //Loop door alle antwoorden heen
                    foreach (Answer answer in question.AnswerOptions)
                    {
                        Answer ans = ConvertDbAnswer(GetAnswer(answer.Description));
                        if (ans == null)
                        {
                            ans = ConvertDbAnswer(AddAnswer(answer));
                        }

                        if (question.CorrectAnswer == answer)
                        {
                            question.CorrectAnswer = ans;
                        }
                        // Synchroniseer onze offline answer met primary key van DB
                        answer.ID = ans.ID;
                    }
                    tblQuestion dbQuestion = AddMultipleChoiceQuestion(question, questionnaire.ID);

                    // Nu kunnen we door answers heen loopen aangezien we nu een ID hebben van Question
                    foreach (Answer answer in question.AnswerOptions)
                    {
                        LinkAnswerToQuestion(dbQuestion.id, answer);
                    }
                    dbQuestionnaire.tblQuestions.Add(dbQuestion);
                }

                db.tblQuestionnaires.InsertOnSubmit(dbQuestionnaire);
                db.SubmitChanges();
                return questionnaire;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public tblAnswer GetAnswer(string answer)
        {
            try
            {
                tblAnswer dbAnswer = (from answers in db.tblAnswers
                                      where answers.description.ToString().Equals(answer)
                                      select answers).FirstOrDefault();

                if (dbAnswer != null)
                {
                    return dbAnswer;
                }

                return null;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public tblAnswer AddAnswer(Answer answer)
        {
            try
            {
                tblAnswer answerExist = GetAnswer(answer.Description);
                if (answerExist != null)
                {
                    return answerExist;
                }
                else
                {
                    db = new DatabaseDataContext();
                    tblAnswer createAnswer = new tblAnswer()
                    {
                        description = answer.Description
                    };
                    db.tblAnswers.InsertOnSubmit(createAnswer);
                    db.SubmitChanges();

                    return createAnswer;
                }

            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public void DeleteMultipleChoiceQuestion(int id)
        {
            try
            {
                // Eerst moeten we de link verwijderen om referentiele integriteit te behouden
                List<tblAnsweroption> referencedAnswerOption = (from ao in db.tblAnsweroptions
                                                                where ao.question == id
                                                                select ao).ToList();

                foreach (tblAnsweroption answerOption in referencedAnswerOption)
                {
                    DeleteLinkAnswerToQuestion(answerOption.question);
                }

                tblQuestion selectedQuestion = (from q in db.tblQuestions
                                                where q.id == id
                                                select q).FirstOrDefault();

                if (selectedQuestion != null)
                {
                    db.tblQuestions.DeleteOnSubmit(selectedQuestion);
                    db.SubmitChanges();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public tblQuestion AddMultipleChoiceQuestion(MultipleChoiceQuestion createdQuestion, int questionnaireId)
        {
            try
            {
                tblQuestion question = new tblQuestion()
                {
                    description = createdQuestion.Description,
                    questionnaire = questionnaireId,
                    questionindex = createdQuestion.QuestionIndex
                };

                if (createdQuestion.TimeRestriction != TimeSpan.Zero)
                {
                    question.timerestriction = createdQuestion.TimeRestriction.Ticks;
                }

                List<tblAnswer> dbAnswers = new List<tblAnswer>();

                foreach (Answer answer in createdQuestion.AnswerOptions)
                {
                    tblAnswer newAnswer = AddAnswer(answer);
                    dbAnswers.Add(newAnswer);
                    if (answer == createdQuestion.CorrectAnswer)
                    {
                        question.correctanswer = newAnswer.id;
                    }
                }

                db.tblQuestions.InsertOnSubmit(question);
                db.SubmitChanges();

                foreach (tblAnswer dbAnswer in dbAnswers)
                {
                    LinkAnswerToQuestion(question.id, ConvertDbAnswer(dbAnswer));
                }

                return question;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public tblExam AddExam(Exam createdExam)
        {
            try
            {
                tblExam exam = new tblExam();
                exam.starttime = createdExam.Starttime;
                exam.endtime = createdExam.Endtime;
                exam.id = createdExam.Examnr;
                exam.questionnaire = createdExam.Questionnaire.ID;
                exam.lecture = createdExam.Lecture.ID;

                db.tblExams.InsertOnSubmit(exam);
                db.SubmitChanges();

                return exam;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }
        public tblLecture AddLecture(Lecture Lecture)
        {
            try
            {
                tblLecture lecture = new tblLecture();
                lecture.@class = Lecture.Class.Code;
                lecture.subject = Lecture.Subject.Id;
                lecture.teacher = Lecture.Teacher.TeacherNr;

                db.tblLectures.InsertOnSubmit(lecture);
                db.SubmitChanges();

                return lecture;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public void LinkAnswerToQuestion(int questionid, Answer answer)
        {
            try
            {
                //Of dus zo:
                tblAnsweroption answerOption = new tblAnsweroption // Maak item aan om toe te voegen
                {
                    question = questionid,
                    answer = answer.ID
                };
                db.tblAnsweroptions.InsertOnSubmit(answerOption); // Geef opdracht om bovenstaande item toe te voegen
                db.SubmitChanges(); // Voer veranderingen door
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
        }

        private void DeleteLinkAnswerToQuestion(int questionId)
        {
            try
            {
                List<tblAnsweroption> answerOptions = db.tblAnsweroptions.Where(q => q.question == questionId).ToList();
                // Selecteer item op id
                foreach (tblAnsweroption dbAnswerOption in answerOptions)
                {
                    db.tblAnsweroptions.DeleteOnSubmit(dbAnswerOption);
                }

                // Geef opdracht om bovenstaande item te verwijderen
                db.SubmitChanges(); // Voer veranderingen door
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AnswerCleanup()
        {
            try
            {
                foreach (tblAnswer dbAnswer in db.tblAnswers) // Doorloopt alle antwoorden
                {
                    if (dbAnswer.tblAnsweroptions.Count == 0)
                    // Als een antwoordt geen relatie meer heeft met een answeroption
                    {
                        db.tblAnswers.DeleteOnSubmit(dbAnswer); // dan wordt het antwoordt verwijderd.
                    }
                }
                db.SubmitChanges(); // Voert de wijziginen uit
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Questionnaire> GetAllQuestionnaires()
        {
            try
            {
                List<Questionnaire> questionnaires = new List<Questionnaire>();

                // Loop door alle questionnaires
                foreach (tblQuestionnaire tblQuestionnaire in db.tblQuestionnaires)
                {
                    // Voeg questionnaire toe aan onze lijst met questionnaire
                    questionnaires.Add(GetQuestionnaire(tblQuestionnaire.id));
                }

                return questionnaires;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // hier worden de afnamemomenten uit de database gehaald
        public List<Exam> GetAllExams()
        {
            try
            {
                List<Exam> exams = new List<Exam>();

                foreach (tblExam tblExam in db.tblExams)
                {
                    Questionnaire questionnaire = GetQuestionnaire(tblExam.questionnaire);

                    Exam exam = new Exam(tblExam.id, questionnaire, tblExam.starttime.Value, tblExam.endtime.Value,
                        GetLecture(tblExam.lecture));

                    exams.Add(exam);
                }

                return exams;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Haal alle afnamemomenten op die gegeven worden door een specifieke docent
        public List<Exam> GetExamsByTeacher(string teacherId)
        {
            try
            {
                List<Exam> exams = new List<Exam>();

                foreach (tblExam tblExam in db.tblExams)
                {
                    Lecture lecture = GetLecture(tblExam.lecture);

                    if (lecture.Teacher.TeacherNr == teacherId)
                    {
                        Questionnaire questionnaire = GetQuestionnaire(tblExam.questionnaire);

                        Exam exam = new Exam(tblExam.id, questionnaire, tblExam.starttime.Value, tblExam.endtime.Value,
                            lecture);

                        exams.Add(exam);
                    } 
                }

                return exams;
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Haal alle klassen op
        public List<Class> GetAllClasses()
        {
            try
            {
                List<Class> css = new List<Class>();

                foreach (tblClass tblclass in db.tblClasses)
                {
                    Class cs = new Class(tblclass.code);

                    css.Add(cs);
                }

                return css;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message); return null;

            }
        }

        // Haal alle lectures op
        public List<Lecture> GetAllLectures()
        {
            try
            {
                List<Lecture> les = new List<Lecture>();

                foreach (tblLecture tbllecture in db.tblLectures)
                {
                    les.Add(ConvertDbLecture(tbllecture));
                }

                return les;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message); return null;

            }
        }

        // Haal een specifieke lecture op met behulp van een ID
        public Lecture GetLecture(int id)
        {
            try
            {
                foreach (tblLecture tblLecture in db.tblLectures)
                {
                    if (tblLecture.id == id)
                    {
                        int lectureId = tblLecture.id;
                        Teacher lectureTeacher = GetTeacher(tblLecture.teacher);
                        Class lectureClass = new Class(tblLecture.@class);
                        Subject lectureSubject = GetSubject(tblLecture.subject);

                        return new Lecture(lectureId, lectureTeacher, lectureClass, lectureSubject);
                    }
                }

                return null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Lecture CheckLecture(Lecture lecture)
        {

            try
            {
                foreach (tblLecture tblLecture in db.tblLectures)
                {
                    if (tblLecture.subject == lecture.Subject.Id && tblLecture.@class == lecture.Class.Code && tblLecture.tblTeacher.nr == lecture.Teacher.TeacherNr)
                    {
                        int lectureId = tblLecture.id;
                        Teacher lectureTeacher = GetTeacher(tblLecture.teacher);
                        Class lectureClass = new Class(tblLecture.@class);
                        Subject lectureSubject = GetSubject(tblLecture.subject);

                        return new Lecture(lectureId, lectureTeacher, lectureClass, lectureSubject);
                    }
                }

                return null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<Exam> GetExamsByQuestionnaire(Questionnaire q)
        {
            try
            {
                List<Exam> exams1 = new List<Exam>();
                List<tblExam> exams = (from tblExam in db.tblExams
                                       where tblExam.tblQuestionnaire.id == q.ID
                                       select tblExam).ToList();

                foreach (tblExam exam in exams)
                {
                    Exam newExam = new Exam(exam.id, q, exam.starttime.Value, exam.endtime.Value,
                        GetLecture(exam.lecture));
                    exams1.Add(newExam);
                }

                return exams1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Exam GetExam(int examID) // Return een Exam van het opgegeven ID
        {
            try
            {

                Exam exam = (from tblExam in db.tblExams
                             where tblExam.id == examID
                             select new Exam(tblExam.id, GetQuestionnaire(tblExam.questionnaire))
                             {
                                 CurrentQuestion = tblExam.currentquestion
                             }).FirstOrDefault();

                if (exam != null)
                {
                    return exam; // Returnt, uit database opgehaalde, Exam
                }
                return null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void UpdateExamCurrentQuestion(int examId, int questionId)
        {
            try
            {
                if (examId != -1)
                {
                    tblExam tblExam = (from exam in db.tblExams
                                       where exam.id == examId
                                       select exam).FirstOrDefault();

                    if (questionId == -1)
                        tblExam.currentquestion = (int?)null;
                    else
                        tblExam.currentquestion = questionId;

                    db.SubmitChanges();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Haal alle vakken op
        public List<Subject> GetSubjects()
        {
            try
            {
                List<Subject> subjects = new List<Subject>();

                foreach (tblSubject tblSubject in db.tblSubjects)
                {
                    Subject subject = new Subject(tblSubject.id, tblSubject.name);

                    subjects.Add(subject);
                }

                return subjects;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        
        // Haal de naam van een specifiek vak op met behulp van het ID
        public Subject GetSubject(int id)
        {
            try
            {
                foreach (tblSubject tblSubject in db.tblSubjects)
                {
                    if (tblSubject.id == id)
                    {
                        return new Subject(tblSubject.id, tblSubject.name);
                    }
                }

                return null;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Haal alle docenten op
        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> teachers = new List<Teacher>();

                foreach (tblTeacher tblTeacher in db.tblTeachers)
                {
                    Teacher teacher = new Teacher(tblTeacher.nr, tblTeacher.firstname, tblTeacher.surname);

                    teachers.Add(teacher);
                }

                return teachers;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // hier worden de antwoorden opgehaald die bij een specifieke vraag horen
        public List<Answer> GetAnswersByQuestion(int id)
        {
            try
            {
                List<tblAnsweroption> tblAnsweroption = (from answeroption in db.tblAnsweroptions
                                                         where answeroption.question == id
                                                         select answeroption).ToList();

                List<Answer> answeroptions = new List<Answer>();
                foreach (tblAnsweroption answeroption in tblAnsweroption)
                {
                    Answer newAnswerOption = new Answer(answeroption.answer);
                    newAnswerOption.ID = answeroption.answer;
                    newAnswerOption.Description = answeroption.tblAnswer.description;

                    answeroptions.Add(newAnswerOption);
                }

                return answeroptions;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Hier worden de resultaten opgehaald voor elk specifieke antwoord.
        public List<Result> GetResultByAnswer(int questionid, int answerid, int examnr)
        {
            try
            {
                List<tblResult> tblResult = (from result in db.tblResults
                                             where (result.question == questionid && result.answer == answerid && result.exam == examnr)
                                             select result).ToList();

                List<Result> results = new List<Result>();
                foreach (tblResult result in tblResult)
                {
                    Result newResult = new Result(result.exam, result.answer, result.question);
                    results.Add(newResult);
                }

                return results;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // hier wordt het antwoord opgehaald bij een antwoord ID (de beschrijving van het antwoord)
        public String GetDescriptionByAnswer(int id)
        {
            try
            {
                tblAnswer tblAnswers = (from answer in db.tblAnswers
                                        where answer.id == id
                                        select answer).FirstOrDefault();
                return tblAnswers.description;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Haal resultaten op van een examen via het ID
        public List<Result> GetResultsByExamId(int id)
        {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.tblResults);

            List<Result> results = new List<Result>();

            List<tblResult> tblResults = (from result in db.tblResults
                                          where result.exam == id
                                          select result).ToList();

            foreach (tblResult tblResult in tblResults)
            {
                Result result = new Result(id, tblResult.answer, tblResult.question);
                results.Add(result);
            }

            return results;
        }

        public void DeleteResults(int examId, int questionId)
        {
            IEnumerable<tblResult> results = (from result in db.tblResults
                                              where result.exam == examId && result.question == questionId
                                              select result).ToList();

            if (results.Count() > 0)
            {
                db.tblResults.DeleteAllOnSubmit(results);
                db.SubmitChanges();
            }

            MessageBox.Show("Alle resultaten zijn verwijderd");
        }

        public void DeleteExam(int id) {
            try {
                tblExam tblExam = (from exam in db.tblExams
                                    where exam.id == id
                                    select exam).FirstOrDefault();

                if (tblExam != null) {
                    db.tblExams.DeleteOnSubmit(tblExam);
                    db.SubmitChanges();
                }
            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateExam(Exam updatedExam) {
            try {
                tblExam tblExam = (from exam in db.tblExams
                                   where exam.id == updatedExam.Examnr
                                   select exam).FirstOrDefault();

                tblExam.questionnaire = updatedExam.Questionnaire.ID;
                tblExam.lecture = updatedExam.Lecture.ID;
                tblExam.starttime = updatedExam.Starttime;
                tblExam.endtime = updatedExam.Endtime;

                db.SubmitChanges();
            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message);
            }
        }

        // Deze functie wordt gebruikt om het database object tblQuestionnaire te converteren naar een Questionnaire object die vervolgens gebruikt kan worden in het programma
        public Questionnaire ConvertDbQuestionnaire(tblQuestionnaire dbQuestionnaire)
        {
            Teacher author = new Teacher() // Teacher object aanmaken
            {
                TeacherNr = dbQuestionnaire.tblTeacher.nr,
                FirstName = dbQuestionnaire.tblTeacher.firstname,
                SurName = dbQuestionnaire.tblTeacher.surname
            };
            Subject subject = new Subject(dbQuestionnaire.tblSubject.id, dbQuestionnaire.tblSubject.name); // Subject object aanmaken
            Questionnaire questionnaire = new Questionnaire(dbQuestionnaire.id) // Questionnaire object aanmaken
            {
                Name = dbQuestionnaire.description,
                Author = author, // Teacher object koppelen
                Subject = subject, // Subject object koppelen
                Archived = dbQuestionnaire.archived
            };
            // Loop door alle questions binnen die questionnaire
            foreach (tblQuestion dbQuestion in dbQuestionnaire.tblQuestions)
            {
                Question question = ConvertDbQuestion(dbQuestion); // Converteert database object naar Question

                // Voeg vragen toe aan onze questionnaire
                questionnaire.Questions.Add(question);
            }
            return questionnaire;
        }

        // Deze functie wordt gebruikt om het database object tblQuestion te converteren naar een MultipleChoiceQuestion object die vervolgens gebruikt kan worden in het programma
        public MultipleChoiceQuestion ConvertDbQuestion(tblQuestion dbQuestion)
        {
            MultipleChoiceQuestion question = new MultipleChoiceQuestion(dbQuestion.description) // Questionnaire object aanmaken
            {
                ID = dbQuestion.id,
                QuestionIndex = dbQuestion.questionindex
            };

            if (dbQuestion.timerestriction != null) // Checkt als timerestriction is ingeschakeld
                question.TimeRestriction = TimeSpan.FromTicks((long)dbQuestion.timerestriction); // Converteert deze naar C#'s TimeSpan
            else
                question.TimeRestriction = TimeSpan.Zero; // Zo niet wordt de TimeSpan op nul gezet

            // Doorloop alle antwoordopties die gekoppeld zijn aan een vraag
            foreach (tblAnsweroption dbAnswerOption in dbQuestion.tblAnsweroptions)
            {
                Answer answer = ConvertDbAnswer(dbAnswerOption.tblAnswer); // Converteerd database object naar Answer
                question.AnswerOptions.Add(answer); // Voegt het antwoord toe als antwoordoptie aan het Question object
                if (dbQuestion.correctanswer == answer.ID)
                    question.CorrectAnswer = answer; // Als het database object ook het correcte antwoord is van de Question wordt deze als correct question ingesteld
            }
            return question;
        }

        // Deze functie wordt gebruikt om het database object tblAnswer te converteren naar een Answer object die vervolgens gebruikt kan worden in het programma
        public Answer ConvertDbAnswer(tblAnswer dbAnswer)
        {
            return new Answer(dbAnswer.id) // Answer object aanmaken en returnen
            {
                Description = dbAnswer.description
            };
        }

        // Deze functie wordt gebruikt om het database object tblLecture te converteren naar een Lecture object die vervolgens gebruikt kan worden in het programma
        public Lecture ConvertDbLecture(tblLecture dbLecture)
        {
            Teacher teacher = new Teacher() // Teacher object aanmaken
            {
                TeacherNr = dbLecture.tblTeacher.nr,
                FirstName = dbLecture.tblTeacher.firstname,
                SurName = dbLecture.tblTeacher.surname
            };
            Class clas = new Class(dbLecture.@class); // Class object aanmaken
            Subject subject = new Subject(dbLecture.tblSubject.id, dbLecture.tblSubject.name); // Subject object aanmaken

            Lecture lecture = new Lecture(dbLecture.id, teacher, clas, subject); // Lecture aanmaken met bovenstaande aangemaakte objecten
            return lecture;
        }
    }
}