using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace PetjeOp
{
    //De MasterController wordt altijd meegegeven, gebruik is bijv. alsvolgt:
    //Question q = masterController.DB.GetQuestion(id);
    public class Database
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void Query()
        {
            Console.WriteLine(GetQuestion(0).Description);
        }

        public MultipleChoiceQuestion GetQuestion(int id)
        {
            tblQuestion query = db.tblQuestions.SingleOrDefault(q => q.id == id);

            if (query != null)
            {
                MultipleChoiceQuestion question = new MultipleChoiceQuestion(query.description);
                return question;
            }
            return null;
        }

        public Questionnaire GetQuestionnaire(int id)
        {  
            tblQuestionnaire dbQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == id);

            Questionnaire questionnaire = new Questionnaire(dbQuestionnaire.description);
            questionnaire.ID = dbQuestionnaire.id;
            questionnaire.Subject = GetSubjectByID(dbQuestionnaire.subject);

            // Loop door alle questions binnen die questionnaire
            foreach (tblQuestion dbQuestion in dbQuestionnaire.tblQuestions)
            {
                MultipleChoiceQuestion question = new MultipleChoiceQuestion(dbQuestion.description);

                // Maak een nieuwe answer object aan voor onze correct answer
                Answer correctAnswer = new Answer(dbQuestion.tblAnswer.description);
                correctAnswer.ID = dbQuestion.tblAnswer.id;

                question.CorrectAnswer = correctAnswer;
                question.ID = dbQuestion.id;
                question.QuestionIndex = dbQuestion.questionindex;

                List<Answer> answerOptions = new List<Answer>();

                foreach (tblAnsweroption dbAnswerOption in dbQuestion.tblAnsweroptions)
                {
                    // Doordat we data hebben van onze answeroption, kunnen we nu ook de gehele vraag halen
                    tblAnswer tblAnswer = dbAnswerOption.tblAnswer;

                    Answer answer = new Answer(tblAnswer.description);
                    answer.ID = tblAnswer.id;
                    answerOptions.Add(answer);
                }

                // Voeg answeroptions (die desalniettemin volledige Answer objecten zijn) toe
                question.AnswerOptions = answerOptions;

                // Voeg vragen toe aan onze questionnaire
                questionnaire.Questions.Add(question);
            }
            if (questionnaire != null)
            {
                return questionnaire;
            }
            else
            {
                return null;
            }
        }

        public void UpdateQuestionnaire(Questionnaire questionnaire)
        {
            tblQuestionnaire updateQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == questionnaire.ID);         // Haalt questionnaire op uit DB
            updateQuestionnaire.description = questionnaire.Name;                                                                      // Wijzigt naam van questionnaire in DB

            foreach (tblQuestion dbQuestion in updateQuestionnaire.tblQuestions.ToList())                                            // Doorloopt lijst van bijbehorende questions uit DB
            {
                MultipleChoiceQuestion question = (MultipleChoiceQuestion)questionnaire.Questions.Select(q => q.ID == dbQuestion.id);// Haalt Question op uit Questionnaire                 
                dbQuestion.description = question.Description;                                                                      // Wijzigt de vraag in DB

                foreach (tblAnsweroption dbLinkAnwser in dbQuestion.tblAnsweroptions.ToList())                                        // Doorloopt lijst van bijbehorende answers uit DB
                {
                    tblAnswer dbAnswer = dbLinkAnwser.tblAnswer;
                    Answer answer = (Answer)question.AnswerOptions.Select(a => a.ID == dbLinkAnwser.answer);                               // Haalt Answer op uit Question
                    dbAnswer.description = answer.Description;                                                                  // Wijzigt het antwoord in DB
                }
                dbQuestion.correctanswer = question.CorrectAnswer.ID;                                                          // Wijzigt het correcte antwoord in DB
            }
            db.SubmitChanges();                                                                                                              // Waar alle Magic happens, alle bovenstaande wijzigingen worden doorgevoerd in de DB            
        }

        public Student GetStudent(String code)
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
        public Teacher GetTeacher(String code) // Returnt een Teacher als deze bestaat, anders NULL.
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

        public bool QuestionnaireExists(string name)
        {
            tblQuestionnaire foundQuestionnaire = (from questionnaire in db.tblQuestionnaires
                                                   where questionnaire.description.ToString().Equals(name)
                                                   select questionnaire).FirstOrDefault();

            if (foundQuestionnaire != null)
            {
                return true;
            }
            return false;
        }

        public Questionnaire AddQuestionnaire(Questionnaire questionnaire)
        {
            tblQuestionnaire tblQuestionnaire = new tblQuestionnaire();
            tblQuestionnaire.author = "eltjo1"; // test data
            tblQuestionnaire.description = questionnaire.Name;
            tblQuestionnaire.subject = questionnaire.Subject.Id;
            db.tblQuestionnaires.InsertOnSubmit(tblQuestionnaire);
            db.SubmitChanges();

            questionnaire.ID = tblQuestionnaire.id;

            //Loop door alle vragen heen
            foreach (MultipleChoiceQuestion q in questionnaire.Questions)
            {
                //Loop door alle antwoorden heen
                foreach (Answer answer in q.AnswerOptions)
                {
                    Answer ans = GetAnswer(answer.Description);
                    if (ans == null)
                    {
                        ans = AddAnswer(answer.Description.ToString());
                    }

                    if (q.CorrectAnswer == answer)
                    {
                        q.CorrectAnswer = ans;
                    }

                    // Synchroniseer onze offline answer met primary key van DB
                    answer.ID = ans.ID;
                }

                MultipleChoiceQuestion dbQuestion = AddMultipleChoiceQuestion(q, questionnaire.ID, tblQuestionnaire);
                // Synchroniseer onze offline dbQuestion met primary key van DB
                q.ID = dbQuestion.ID;

                // Nu kunnen we er door heen loopen aangezien we nu een ID hebben van Question
                foreach (Answer answer in q.AnswerOptions)
                {
                    LinkAnswerToQuestion(q, answer);
                }
            }

            return questionnaire;
        }

        public Answer GetAnswer(string answer)
        {
            tblAnswer foundAnswer = (from answers in db.tblAnswers
                                     where answers.description.ToString().Equals(answer)
                                     select answers).FirstOrDefault();

            if (foundAnswer != null)
            {
                Console.WriteLine("Found answer: " + foundAnswer.description.ToString());

                Answer retrievedAnswer = new Answer(foundAnswer.description);
                retrievedAnswer.ID = foundAnswer.id;

                return retrievedAnswer;
            }
            return null;
        }

        public Answer AddAnswer(string receivedAnswer)
        {
            tblAnswer answer = new tblAnswer();
            //answer.id = new Random().Next(100, 1000); // AI maken!!
            answer.description = receivedAnswer;

            db.tblAnswers.InsertOnSubmit(answer);
            db.SubmitChanges();

            return new Answer(answer.description)
            {
                ID = answer.id
            };
        }

        public void DeleteMultipleChoiceQuestion(MultipleChoiceQuestion question)
        {
            // Eerst moeten we de link verwijderen om referentiele integriteit te behouden
            List<tblAnsweroption> referencedAnswerOption = (from ao in db.tblAnsweroptions
                                                            where ao.question == question.ID
                                                            select ao).ToList();

            foreach (tblAnsweroption answerOption in referencedAnswerOption)
            {
                Console.WriteLine("Removing AnswerOption ID: " + answerOption.question);
                DeleteLinkAnswerToQuestion(answerOption.question);
            }

            Console.WriteLine("Question ID: " + question.ID);
            tblQuestion selectedQuestion = (from q in db.tblQuestions
                                            where q.id == question.ID
                                            select q).FirstOrDefault();

            if (selectedQuestion != null)
            {
                db.tblQuestions.DeleteOnSubmit(selectedQuestion);
                db.SubmitChanges();
            }
            else
            {
                Console.WriteLine("wtf, null record?");
            }
        }

        public MultipleChoiceQuestion AddMultipleChoiceQuestion(MultipleChoiceQuestion createdQuestion, int questionnaireId, tblQuestionnaire tblQuestionnaire)
        {
            tblQuestion question = new tblQuestion();
            //question.id = new Random().Next(100, 1000); // AI maken!!
            question.description = createdQuestion.Description;
            question.correctanswer = createdQuestion.CorrectAnswer.ID;
            question.questionnaire = questionnaireId;
            question.questionindex = createdQuestion.QuestionIndex;

            if (createdQuestion.TimeRestriction != TimeSpan.Zero)
            {
                question.timerestriction = createdQuestion.TimeRestriction.Ticks;
            }

            db.tblQuestions.InsertOnSubmit(question);
            db.SubmitChanges();

            tblQuestionnaire.tblQuestions.Add(question);

            return new MultipleChoiceQuestion(question.description)
            {
                ID = question.id,
                Description = question.description,
                CorrectAnswer = createdQuestion.CorrectAnswer,
                AnswerOptions = createdQuestion.AnswerOptions,
                QuestionIndex = createdQuestion.QuestionIndex,
                TimeRestriction = createdQuestion.TimeRestriction
            };
        }

        public void LinkAnswerToQuestion(MultipleChoiceQuestion refQuestion, Answer refAnswer)
        {
            // Dit moet zo, omdat we geen PI hebben in answeroption, LINQ vindt dat niet leuk
            //db.ExecuteCommand("INSERT INTO [answeroption] (question, answer) VALUES ({0}, {1})", refQuestion.ID, refAnswer.ID);

            //Of dus zo:
            tblAnsweroption answerOption = new tblAnsweroption // Maak item aan om toe te voegen
            {
                question = refQuestion.ID,
                answer = refAnswer.ID
            };
            db.tblAnsweroptions.InsertOnSubmit(answerOption); // Geef opdracht om bovenstaande item toe te voegen
            db.SubmitChanges(); // Voer veranderingen door
        }

        private void DeleteLinkAnswerToQuestion(int questionId)
        {
            // Dit moet zo, omdat we geen PI hebben in answeroption, LINQ vindt dat niet leuk
            //db.ExecuteCommand("DELETE FROM [answeroption] WHERE question = {0}", questionId);

            //Of dus zo:
            tblAnsweroption answerOption = db.tblAnsweroptions.Single(q => q.question == questionId); // Selecteer item op id
            db.tblAnsweroptions.DeleteOnSubmit(answerOption); // Geef opdracht om bovenstaande item te verwijderen
            db.SubmitChanges(); // Voer veranderingen door
        }

        public List<Questionnaire> GetAllQuestionnaires()
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

        public List<Exam> GetExam()
        {
            List<Exam> exams = new List<Exam>();

            foreach (tblExam tblExam in db.tblExams)
            {
                Questionnaire questionnaire = GetQuestionnaire(tblExam.questionnaire);

                Exam exam = new Exam(tblExam.id, questionnaire, tblExam.starttime , tblExam.endtime, tblExam.lecture);

                exams.Add(exam);


            }

            return exams;

        }

        public List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();

            foreach (tblSubject tblSubject in db.tblSubjects)
            {
                Subject subject = new Subject(tblSubject.id, tblSubject.name);

                subjects.Add(subject);
            }

            return subjects;
        }

        public Subject GetSubjectByID(int id)
        {
            Subject found = new Subject(0, "");

            foreach (tblSubject tblSubject in db.tblSubjects)
            {
                if (tblSubject.id == id)
                {
                    found = new Subject(tblSubject.id, tblSubject.name);
                }
            }

            return found;
        }

        //public Questionnaire GetQuestionnaire(int id)
        //{
        //    tblQuestionnaire tblQuestionnaire = (from questionnaire1 in db.tblQuestionnaires
        //                                         where questionnaire1.id == id
        //                                         select questionnaire1).FirstOrDefault();

        //    Questionnaire questionnaire = new Questionnaire(tblQuestionnaire.description);
        //    questionnaire.ID = tblQuestionnaire.id;
        //    questionnaire.Questions = GetQuestionsByQuestionnaire(questionnaire.ID);

        //    return questionnaire;
        //}

        public List<Question> GetQuestionsByQuestionnaire(int id)
        {
            List<tblQuestion> tblQuestion = (from questions in db.tblQuestions
                                             where questions.questionnaire == id
                                             select questions).ToList();

            List<Question> listQuestions = new List<Question>();
            foreach (tblQuestion question in tblQuestion)
            {
                Question newQuestion = new MultipleChoiceQuestion(question.description);
                newQuestion.ID = question.id;
                newQuestion.CorrectAnswer = new Answer(question.correctanswer);

                listQuestions.Add(newQuestion);
            }

            return listQuestions;
        }

        public List<Answer> GetAnswers()
        {
            List<Answer> answers = new List<Answer>();

            foreach (tblAnswer tblAnswer in db.tblAnswers)
            {
                Answer answer = new Answer(tblAnswer.description);

                answers.Add(answer);
            }

            return answers;
        }

        public List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();

            foreach (tblQuestion tblQuestion in db.tblQuestions)
            {
                Question question = new MultipleChoiceQuestion(tblQuestion.description);

                questions.Add(question);
            }

            return questions;

        }

        public List<Answer> GetAnswerByQuestion(int id)
        {
            List<tblAnsweroption> tblAnsweroption = (from answeroption in db.tblAnsweroptions
                                                     where answeroption.question == id
                                                     select answeroption).ToList();

            List<Answer> answeroptions = new List<Answer>();
            foreach (tblAnsweroption answeroption in tblAnsweroption)
            {
                Answer newAnswerOption = new Answer(answeroption.answer);
                newAnswerOption.ID = answeroption.answer;

                answeroptions.Add(newAnswerOption);
            }

            return answeroptions;
        }

        public List<Result> GetResultByAnswer(int questionid, int answerid, int examnr)
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

      public String GetDescriptionByAnswer(int id)
        {
            tblAnswer tblAnswers =                    (from answer in db.tblAnswers
                                                   where answer.id == id
                                                   select answer).FirstOrDefault();
            return tblAnswers.description; 
        }     
        

    }
}