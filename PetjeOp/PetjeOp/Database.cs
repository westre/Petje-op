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
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Boolean QuestionContainsAnswerFromUser(Exam Exam, Student student, Question Question)
        {
            tblResult result = db.tblResults.SingleOrDefault(g => g.student == student.StudentNr && g.exam == Exam.Examnr && g.question == Question.ID);

            if(result != null)
            {
                return true;
            }

            return false;
        }

        public List<tblExam> GetExamsOfStudent(String StudentNR)
        {
            tblStudent student = db.tblStudents.SingleOrDefault(g => g.nr == StudentNR);

            List<tblExam> exams = db.tblExams.Where(g => g.tblLecture.@class == student.@class).ToList();

            return exams;
        }

        // Voegt een resultaat toe van een antwoord op een vraag in een examen.
        public void InsertResult(tblResult Result)
        {
            // Wordt aangeroepen om de gehele enity te refreshen. Inverband met foreign-keys...
            db = new DataClasses1DataContext();
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
            foreach(tblExam exam in dbQuestionnaire.tblExams.ToList())
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
            try {
            // Eerst wordt de query uitgevoerd welke de vraag selecteerd op basis van het meegegeven ID
            tblQuestion dbQuestion = db.tblQuestions.SingleOrDefault(q => q.id == id);

            // Hier wordt gecontrolleerd of de query gelukt is, 
            // null staat immers voor een niet geslaagde query of een query zonder resultaten
                if (dbQuestion != null) {
                    // Hier wordt een nieuwe vraag aangemaakt via de contstructor van MultipleChoiceQuestion
                    // De description wordt hieraan meegegeven, die met de query is opgehaald
                    MultipleChoiceQuestion question = new MultipleChoiceQuestion(dbQuestion.description);
                    question.ID = id; // Vervolgens wordt het ID van het Question object toegevoegd, dit is hetzelfde ID dan degene in de database
                                    
                    List<Answer> answerOptions = new List<Answer>(); // Lijst met answeropties wordt aangemaakt, welke straks gevult wordt
                    List<tblAnsweroption> dbAnsweroption = dbQuestion.tblAnsweroptions.ToList(); // Lijst met tblAnsweropties, welke straks doorlopen wordt

                    if (dbQuestion.timerestriction != null) {
                        question.TimeRestriction = TimeSpan.FromTicks((long)dbQuestion.timerestriction);
                    }
                    else {
                        question.TimeRestriction = TimeSpan.Zero;
                    }

                    foreach (tblAnsweroption dbAnswerOption in dbAnsweroption) { // Doorloopt de antwoordopties die een foreign key naar de geselecteerde question in de database hebben
                        // Doordat we data hebben van onze answeroption, kunnen we nu ook de gehele vraag halen
                        tblAnswer tblAnswer = dbAnswerOption.tblAnswer; // Cast antwoordtabel in variable

                        Answer answer = new Answer(tblAnswer.description); // Maakt een nieuw antwoord aan
                        answer.ID = tblAnswer.id; // Werkt het id bij naar degene die ook in de database gebruikt wordt

                        if (dbQuestion.correctanswer == tblAnswer.id) {
                            question.CorrectAnswer = answer;
                        }
                        answerOptions.Add(answer); // Voegt het antwoord object toe aan de lijst van antwoordopties die straks toegevoegd wordt aan de vraag

                    }

                    // Voegt de lijst met antwoord opties toe aan de vraag
                    question.AnswerOptions = answerOptions;               

                    return question;
                }
                // Als de query gefaalt is return null, deze wordt later opgevangen
                return null;
            }
            catch(SqlException ex) { MessageBox.Show(ex.Message); return null; }  
        }

        // Deze functie wordt gebruikt om een vragenlijst op te halen uit de database, het ID wordt hiervoor meegegeven
        public Questionnaire GetQuestionnaire(int id)
        {
            try {
                // Query die questionnaire op id selecteerd en opslaat in het Linq tblQuestionnaire object
                tblQuestionnaire dbQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == id);

                if (dbQuestionnaire != null) {// Als de query gelukt is
                    Questionnaire questionnaire = new Questionnaire(dbQuestionnaire.description); // Maak een questionnaire object aan
                    questionnaire.ID = dbQuestionnaire.id; // Geef het id mee vanuit de database
                    questionnaire.Subject = new Subject(dbQuestionnaire.tblSubject.id, dbQuestionnaire.tblSubject.name); // Set het subject van de vragenlijst

                    Teacher author = new Teacher(); // Teacher object aanmaken voor Autheur
                    author.TeacherNr = dbQuestionnaire.tblTeacher.nr;
                    author.FirstName = dbQuestionnaire.tblTeacher.firstname;
                    author.SurName = dbQuestionnaire.tblTeacher.surname;

                    questionnaire.Author = author; // Set auteur van de vragenlijst
                    questionnaire.Archived = dbQuestionnaire.archived;

                    // Loop door alle questions binnen die questionnaire
                    foreach (tblQuestion dbQuestion in dbQuestionnaire.tblQuestions) {
                        MultipleChoiceQuestion question = new MultipleChoiceQuestion(dbQuestion.description); // 

                        question.ID = dbQuestion.id;
                        question.QuestionIndex = dbQuestion.questionindex;
                        if (dbQuestion.timerestriction != null)
                        {
                            question.TimeRestriction = TimeSpan.FromTicks((long)dbQuestion.timerestriction);
                        }
                        else
                        {
                            question.TimeRestriction = TimeSpan.Zero;
                        }
                    

                        List<Answer> answerOptions = new List<Answer>();

                        foreach (tblAnsweroption dbAnswerOption in dbQuestion.tblAnsweroptions) {
                            // Doordat we data hebben van onze answeroption, kunnen we nu ook de gehele vraag halen
                            tblAnswer tblAnswer = dbAnswerOption.tblAnswer;

                            Answer answer = new Answer(tblAnswer.description);
                            answer.ID = tblAnswer.id;
                            answerOptions.Add(answer);

                                if (dbQuestion.correctanswer == answer.ID) {
                                question.CorrectAnswer = answer;
                            }
                        }

                        // Voeg answeroptions (die desalniettemin volledige Answer objecten zijn) toe
                        question.AnswerOptions = answerOptions;

                        // Voeg vragen toe aan onze questionnaire
                        questionnaire.Questions.Add(question);
                    }
                    return questionnaire;
                }
                return null;
            }catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public void UpdateQuestionnaire(Questionnaire questionnaire, List<Question> deletedQuestions = null) {
            try {
                tblQuestionnaire updateQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == questionnaire.ID);         // Haalt questionnaire op uit DB
                updateQuestionnaire.description = questionnaire.Name;                                                                      // Wijzigt naam van questionnaire in DB
                updateQuestionnaire.archived = questionnaire.Archived;

                if (deletedQuestions != null)
                {
                    foreach (MultipleChoiceQuestion delQuestion in deletedQuestions)
                    {
                        DeleteMultipleChoiceQuestion(delQuestion.ID);
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
                        dbQuestion.description = question.Description;                                                                      // Wijzigt de vraag in DB

                        foreach (tblAnsweroption dbLinkAnwser in dbQuestion.tblAnsweroptions.ToList())                                        // Doorloopt lijst van bijbehorende answers uit DB
                        {
                            tblAnswer dbAnswer = dbLinkAnwser.tblAnswer;
                            Answer answer = question.AnswerOptions.Single(a => a.ID == dbLinkAnwser.answer);                               // Haalt Answer op uit Question
                            dbAnswer.description = answer.Description;                                                                 // Wijzigt het antwoord in DB
                        }
                        dbQuestion.correctanswer = question.CorrectAnswer.ID;
                    }                    
                    if(dbQuestion != null)
                    {
                        updateQuestionnaire.tblQuestions.Add(dbQuestion);
                    }                        
                }
                db.SubmitChanges(); // Waar alle Magic happens, alle bovenstaande wijzigingen worden doorgevoerd in de DB      
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
        }                                                                            

        public Student GetStudent(String code)
        {
            try {
            Student person = (from tblStudent in db.tblStudents
                              where tblStudent.nr == code
                                  select new Student {
                                  StudentNr = tblStudent.nr,
                                  FirstName = tblStudent.firstname,
                                  SurName = tblStudent.surname,
                                  GroupNr = tblStudent.@class

                              }).FirstOrDefault();

                if (person != null) {
                return person; // Returnt, uit database opgehaalde, Student.
            }
            return null;
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }   
        }
        public Teacher GetTeacher(String code) // Returnt een Teacher als deze bestaat, anders NULL.
        {
            try {
            Teacher person = (from tblTeacher in db.tblTeachers
                              where tblTeacher.nr == code
                                  select new Teacher {
                                  TeacherNr = tblTeacher.nr,
                                  FirstName = tblTeacher.firstname,
                                  SurName = tblTeacher.surname

                              }).FirstOrDefault();

                if (person != null) {
                return person; // Returnt, uit database opgehaalde, Teacher.
            }
            return null;
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public Questionnaire AddQuestionnaire(Teacher teacher, Questionnaire questionnaire)
        {
            try {
            tblQuestionnaire tblQuestionnaire = new tblQuestionnaire();
            
            tblQuestionnaire.author = teacher.TeacherNr; // test data
            tblQuestionnaire.description = questionnaire.Name;
            tblQuestionnaire.subject = questionnaire.Subject.Id;
            db.tblQuestionnaires.InsertOnSubmit(tblQuestionnaire);
            db.SubmitChanges();

            questionnaire.ID = tblQuestionnaire.id;
            questionnaire.Author = teacher;

            //Loop door alle vragen heen
                foreach (MultipleChoiceQuestion q in questionnaire.Questions) {
                //Loop door alle antwoorden heen
                    foreach (Answer answer in q.AnswerOptions) {
                    Answer ans = GetAnswer(answer.Description);
                        if (ans == null) {
                        ans = AddAnswer(answer.Description.ToString());
                    }

                        if (q.CorrectAnswer == answer) {
                        q.CorrectAnswer = ans;
                    }

                    // Synchroniseer onze offline answer met primary key van DB
                    answer.ID = ans.ID;
                }

                tblQuestion dbQuestion = AddMultipleChoiceQuestion(q, questionnaire.ID);
                tblQuestionnaire.tblQuestions.Add(dbQuestion);
                // Synchroniseer onze offline dbQuestion met primary key van DB
                q.ID = dbQuestion.id;

                // Nu kunnen we er door heen loopen aangezien we nu een ID hebben van Question
                    foreach (Answer answer in q.AnswerOptions) {
                    LinkAnswerToQuestion(q, answer);
                }
            }

            return questionnaire;
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public Answer GetAnswer(string answer)
        {
            try {
            tblAnswer foundAnswer = (from answers in db.tblAnswers
                                     where answers.description.ToString().Equals(answer)
                                     select answers).FirstOrDefault();

                if (foundAnswer != null) {
                Console.WriteLine("Found answer: " + foundAnswer.description.ToString());

                Answer retrievedAnswer = new Answer(foundAnswer.description);
                retrievedAnswer.ID = foundAnswer.id;

                return retrievedAnswer;
            }
            return null;
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public Answer AddAnswer(string receivedAnswer)
        {
            try {
            tblAnswer answer = new tblAnswer();
            answer.description = receivedAnswer;

            db.tblAnswers.InsertOnSubmit(answer);
            db.SubmitChanges();

                return new Answer(answer.description) {
                ID = answer.id
            };
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; } 
        }

        public void DeleteMultipleChoiceQuestion(int id)
        {
            try {
                // Eerst moeten we de link verwijderen om referentiele integriteit te behouden
                List<tblAnsweroption> referencedAnswerOption = (from ao in db.tblAnsweroptions
                                                                where ao.question == id
                                                                select ao).ToList();

                foreach (tblAnsweroption answerOption in referencedAnswerOption) {
                    DeleteLinkAnswerToQuestion(answerOption.question);
                }
            
                tblQuestion selectedQuestion = (from q in db.tblQuestions
                                                where q.id == id
                                                select q).FirstOrDefault();

                if (selectedQuestion != null) {
                    db.tblQuestions.DeleteOnSubmit(selectedQuestion);
                    db.SubmitChanges();
                }
            }catch (SqlException ex) { MessageBox.Show(ex.Message); }            
        }

        public tblQuestion AddMultipleChoiceQuestion(MultipleChoiceQuestion createdQuestion, int questionnaireId)
        {
            try {
                tblQuestion question = new tblQuestion();
                question.description = createdQuestion.Description;
                question.correctanswer = createdQuestion.CorrectAnswer.ID;
                question.questionnaire = questionnaireId;
                question.questionindex = createdQuestion.QuestionIndex;

                if (createdQuestion.TimeRestriction != TimeSpan.Zero) {
                    question.timerestriction = createdQuestion.TimeRestriction.Ticks;
                }

                db.tblQuestions.InsertOnSubmit(question);
                db.SubmitChanges();

                return question;
            } catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public void LinkAnswerToQuestion(MultipleChoiceQuestion refQuestion, Answer refAnswer)
        {
            try {
            //Of dus zo:
            tblAnsweroption answerOption = new tblAnsweroption // Maak item aan om toe te voegen
            {
                question = refQuestion.ID,
                answer = refAnswer.ID
            };
            db.tblAnsweroptions.InsertOnSubmit(answerOption); // Geef opdracht om bovenstaande item toe te voegen
            db.SubmitChanges(); // Voer veranderingen door
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }

            
        }

        private void DeleteLinkAnswerToQuestion(int questionId)
        {
            try {
            List<tblAnsweroption> answerOptions = db.tblAnsweroptions.Where(q => q.question == questionId).ToList(); // Selecteer item op id
                foreach (tblAnsweroption dbAnswerOption in answerOptions) {
                db.tblAnsweroptions.DeleteOnSubmit(dbAnswerOption);
            }

             // Geef opdracht om bovenstaande item te verwijderen
            db.SubmitChanges(); // Voer veranderingen door
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }

            
        }

        public void AnswerCleanup()
        {
            try {
                foreach (tblAnswer dbAnswer in db.tblAnswers) // Doorloopt alle antwoorden
            {
                if (dbAnswer.tblAnsweroptions.Count == 0) // Als een antwoordt geen relatie meer heeft met een answeroption
                {
                    db.tblAnswers.DeleteOnSubmit(dbAnswer); // dan wordt het antwoordt verwijderd.
                }
            }
            db.SubmitChanges(); // Voert de wijziginen uit
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }

            
        }

        public List<Questionnaire> GetAllQuestionnaires()
        {
            try {
                List<Questionnaire> questionnaires = new List<Questionnaire>();

                // Loop door alle questionnaires
                foreach (tblQuestionnaire tblQuestionnaire in db.tblQuestionnaires) {
                    // Voeg questionnaire toe aan onze lijst met questionnaire
                    questionnaires.Add(GetQuestionnaire(tblQuestionnaire.id));
                }

                return questionnaires;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        } 
            

        // hier worden de afnamemomenten uit de database gehaald
        public List<Exam> GetAllExams()
        {
            try {
            List<Exam> exams = new List<Exam>();

                foreach (tblExam tblExam in db.tblExams) {
                Questionnaire questionnaire = GetQuestionnaire(tblExam.questionnaire);
               

                Exam exam = new Exam(tblExam.id, questionnaire, tblExam.starttime, tblExam.endtime, tblExam.lecture);

                exams.Add(exam);


            }

            return exams;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }

            

        }

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
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }



        }

        public List<Exam> GetExamsByQuestionnaire(Questionnaire q)
        {
            try {
            List<Exam> exams1 = new List<Exam>();
            List<tblExam> exams = (from tblExam in db.tblExams
                                       where tblExam.tblQuestionnaire.id == q.ID
                                       select tblExam).ToList();

                foreach (tblExam exam in exams) {
                Exam newExam = new Exam(exam.id, q, exam.starttime, exam.endtime, exam.lecture);
                exams1.Add(newExam);
            }

            return exams1;
        } 
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }


        } 


        public Exam GetExam(int examID) // Return een Exam van het opgegeven ID
        {
            try {
             Exam exam = (from tblExam in db.tblExams
                         where tblExam.id == examID
                             select new Exam(tblExam.id, tblExam.questionnaire) {
                             CurrenQuestion = tblExam.currentquestion
                         }).FirstOrDefault();

            exam.questionnaire = this.GetQuestionnaire(exam.qstnn);
                if (exam != null) {
                return exam; // Returnt, uit database opgehaalde, Exam
            }
            return null;
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }

            
        }

        public List<Exam> GetExams()
        {
            try {
            List<Exam> exams = new List<Exam>();

                foreach (tblExam tblExam in db.tblExams) {
                Questionnaire questionnaire = GetQuestionnaire(tblExam.questionnaire);

                Exam exam = new Exam(tblExam.id, questionnaire, tblExam.starttime, tblExam.endtime, tblExam.lecture);

                exams.Add(exam);


            }

            return exams;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }

            

        }

     
        public void UpdateExamCurrentQuestion(int examId, int questionId) {
            try {
                if (examId != -1) {
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
            catch (SqlException ex) { MessageBox.Show(ex.Message); }

            
        }


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
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

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
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        // hier worden de antwoorden opgehaald die bij een specifieke vraag horen
        public List<Answer> GetAnswersByQuestion(int id)
        {
            try {
            List<tblAnsweroption> tblAnsweroption = (from answeroption in db.tblAnsweroptions
                                                     where answeroption.question == id
                                                     select answeroption).ToList();

            List<Answer> answeroptions = new List<Answer>();
                foreach (tblAnsweroption answeroption in tblAnsweroption) {
                Answer newAnswerOption = new Answer(answeroption.answer);
                newAnswerOption.ID = answeroption.answer;
                newAnswerOption.Description = answeroption.tblAnswer.description;

                answeroptions.Add(newAnswerOption);
            }

            return answeroptions;
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }

            
        }
        // Hier worden de resultaten opgehaald voor elk specifieke antwoord.
        
        public List<Result> GetResultByAnswer(int questionid, int answerid, int examnr)
        {
            try {
            List<tblResult> tblResult = (from result in db.tblResults
                                         where (result.question == questionid && result.answer == answerid && result.exam == examnr)
                                         select result).ToList();

            List<Result> results = new List<Result>();
                foreach (tblResult result in tblResult) {
                Result newResult = new Result(result.exam, result.answer, result.question);
                results.Add(newResult);
            }

            return results;
        }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }

            
        }
        // hier wordt het antwoord opgehaald bij een antwoord ID (de beschrijving van het antwoord)
      public String GetDescriptionByAnswer(int id)
        {
            try {
                tblAnswer tblAnswers = (from answer in db.tblAnswers
                                                   where answer.id == id
                                                   select answer).FirstOrDefault();
            return tblAnswers.description; 
        }     
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }

            
        }     
        
        // Haal resultaten op van examen
        public List<Result> GetResultsByExamId(int id) {
            db.Refresh(RefreshMode.OverwriteCurrentValues, db.tblResults);

            List<Result> results = new List<Result>();

            List<tblResult> tblResults = (from result in db.tblResults
                                          where result.exam == id
                                          select result).ToList();

            foreach(tblResult tblResult in tblResults) {
                Result result = new Result(id, tblResult.answer, tblResult.question);
                results.Add(result);
            }

            return results;
        }

        public void DeleteResults(int examId, int questionId) {
            IEnumerable<tblResult> results = (from result in db.tblResults
                                 where result.exam == examId && result.question == questionId
                                 select result).ToList();

            if (results.Count() > 0) {
                db.tblResults.DeleteAllOnSubmit(results);
                db.SubmitChanges();
            }

            MessageBox.Show("Alle resultaten zijn verwijderd");
        }
    }
}