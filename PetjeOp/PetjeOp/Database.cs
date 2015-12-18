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
                        Answer ans = GetAnswer(answer.Description);
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

                foreach (Answer answer in createdQuestion.AnswerOptions)
                {
                    tblAnswer newAnswer = AddAnswer(answer);
                    if (answer == createdQuestion.CorrectAnswer)
                    {
                        question.correctanswer = newAnswer.id;
                    }
                    LinkAnswerToQuestion(question.id, ConvertDbAnswer(newAnswer));
                }

                db.tblQuestions.InsertOnSubmit(question);
                db.SubmitChanges();

                return question;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public tblAnswer AddAnswer(Answer answer)
        {
            try
            {
                tblAnswer answerExist = GetAnswer(answer.Description, true);
                if (answerExist != null)
                {
                    return answerExist;
                }
                else
                {
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
                        foreach (Answer answer in question.AnswerOptions)
                        {
                            LinkAnswerToQuestion(dbQuestion.id, answer);
                        }
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
                db.SubmitChanges(); // Waar alle Magic happens, alle bovenstaande wijzigingen worden doorgevoerd in de DB      
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
        }

        // Deze functie wordt gebruikt om een vragenlijst op te halen uit de database, het ID wordt hiervoor meegegeven
        public dynamic GetQuestionnaire(int id, bool dbObject = false)
        {
            try
            {
                // Query die questionnaire op id selecteerd en opslaat in het Linq tblQuestionnaire object
                tblQuestionnaire dbQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == id);

                if (dbQuestionnaire != null)
                {
                    if (dbObject)
                    {
                        return dbQuestionnaire;
                    }
                    else
                    {
                        return ConvertDbQuestionnaire(dbQuestionnaire);
                    }
                }
                return null;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        // Deze functie wordt gebruikt om een vraag op te halen uit de database, het ID wordt hiervoor meegegeven
        public dynamic GetQuestion(int id, bool dbObject = false)
        {
            try
            {
                // Eerst wordt de query uitgevoerd welke de vraag selecteerd op basis van het meegegeven ID
                tblQuestion dbQuestion = db.tblQuestions.SingleOrDefault(q => q.id == id);

                // Hier wordt gecontrolleerd of de query gelukt is, 
                // null staat immers voor een niet geslaagde query of een query zonder resultaten
                if (dbQuestion != null)
                {
                    if (dbObject)
                    {
                        return dbQuestion;
                    }
                    else
                    {
                        return ConvertDbQuestion(dbQuestion);
                    }
                }
                // Als de query gefaalt is return null, deze wordt later opgevangen
                return null;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        public dynamic GetAnswer(string answer, bool dbObject = false)
        {
            try
            {
                tblAnswer dbAnswer = (from answers in db.tblAnswers
                                      where answers.description.ToString().Equals(answer)
                                      select answers).FirstOrDefault();

                if (dbAnswer != null)
                {
                    if (dbObject)
                    {
                        return dbAnswer;
                    }
                    else
                    {
                        return ConvertDbAnswer(dbAnswer);
                    }
                }

                return null;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
        }

        // Voegt een resultaat toe van een antwoord op een vraag in een examen.
        public void InsertResult(tblResult Result)
        {
            db.tblResults.InsertOnSubmit(Result);

            try
            {
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
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
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
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
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
                List<tblAnsweroption> answerOptions = db.tblAnsweroptions.Where(q => q.question == questionId).ToList(); // Selecteer item op id
                foreach (tblAnsweroption dbAnswerOption in answerOptions)
                {
                    db.tblAnsweroptions.DeleteOnSubmit(dbAnswerOption);
                }

                // Geef opdracht om bovenstaande item te verwijderen
                db.SubmitChanges(); // Voer veranderingen door
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
        }

        public void AnswerCleanup()
        {
            try
            {
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
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
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
            try
            {
                List<Exam> exams1 = new List<Exam>();
                List<tblExam> exams = (from tblExam in db.tblExams
                                       where tblExam.tblQuestionnaire.id == q.ID
                                       select tblExam).ToList();

                foreach (tblExam exam in exams)
                {
                    Exam newExam = new Exam(exam.id, q, exam.starttime, exam.endtime, exam.lecture);
                    exams1.Add(newExam);
                }

                return exams1;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }


        }


        public Exam GetExam(int examID) // Return een Exam van het opgegeven ID
        {
            try
            {
                Exam exam = (from tblExam in db.tblExams
                             where tblExam.id == examID
                             select new Exam(tblExam.id, tblExam.questionnaire)
                             {
                                 CurrenQuestion = tblExam.currentquestion
                             }).FirstOrDefault();

                exam.questionnaire = this.GetQuestionnaire(exam.qstnn);
                if (exam != null)
                {
                    return exam; // Returnt, uit database opgehaalde, Exam
                }
                return null;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }


        }

        public List<Exam> GetExams()
        {
            try
            {
                List<Exam> exams = new List<Exam>();

                foreach (tblExam tblExam in db.tblExams)
                {
                    Questionnaire questionnaire = GetQuestionnaire(tblExam.questionnaire);

                    Exam exam = new Exam(tblExam.id, questionnaire, tblExam.starttime, tblExam.endtime, tblExam.lecture);

                    exams.Add(exam);


                }

                return exams;
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }
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
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }


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
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }


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
            catch (SqlException ex) { MessageBox.Show(ex.Message); return null; }


        }

        // Haal resultaten op van examen
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

        public Questionnaire ConvertDbQuestionnaire(tblQuestionnaire dbQuestionnaire)
        {
            Teacher author = new Teacher()
            {
                TeacherNr = dbQuestionnaire.tblTeacher.nr,
                FirstName = dbQuestionnaire.tblTeacher.firstname,
                SurName = dbQuestionnaire.tblTeacher.surname
            };
            Subject subject = new Subject(1, "");
            Questionnaire questionnaire = new Questionnaire(dbQuestionnaire.id)
            {
                Name = dbQuestionnaire.description,
                Author = author,
                Subject = subject,
                Archived = dbQuestionnaire.archived
            };
            // Loop door alle questions binnen die questionnaire
            foreach (tblQuestion dbQuestion in dbQuestionnaire.tblQuestions)
            {
                Question question = ConvertDbQuestion(dbQuestion);

                // Voeg vragen toe aan onze questionnaire
                questionnaire.Questions.Add(question);
            }
            return questionnaire;
        }

        public MultipleChoiceQuestion ConvertDbQuestion(tblQuestion dbQuestion)
        {
            MultipleChoiceQuestion question = new MultipleChoiceQuestion(dbQuestion.description)
            {
                ID = dbQuestion.id,
                QuestionIndex = dbQuestion.questionindex
            };
            if (dbQuestion.timerestriction != null)
                question.TimeRestriction = TimeSpan.FromTicks((long)dbQuestion.timerestriction);
            else
                question.TimeRestriction = TimeSpan.Zero;
            foreach (tblAnsweroption dbAnswerOption in dbQuestion.tblAnsweroptions)
            {
                Answer answer = ConvertDbAnswer(dbAnswerOption.tblAnswer);
                question.AnswerOptions.Add(answer);
                if (dbQuestion.correctanswer == answer.ID)
                {
                    question.CorrectAnswer = answer;
                }
            }
            return question;
        }

        public Answer ConvertDbAnswer(tblAnswer dbAnswer)
        {
            Answer answer = new Answer(dbAnswer.id)
            {
                Description = dbAnswer.description
            };
            return answer;
        }
    }
}