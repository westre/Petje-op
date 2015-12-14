using System;
using System.Collections.Generic;
using System.Data.Linq;
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

        // Deze functie wordt gebruikt om een vraag op te halen uit de database, het ID wordt hiervoor meegegeven
        public MultipleChoiceQuestion GetQuestion(int id)
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
                question.ID = id; // Vervolgens wordt het ID van het Question object toegevoegd, dit is hetzelfde ID dan degene in de database
                                
                List<Answer> answerOptions = new List<Answer>(); // Lijst met answeropties wordt aangemaakt, welke straks gevult wordt
                List<tblAnsweroption> dbAnsweroption = dbQuestion.tblAnsweroptions.ToList(); // Lijst met tblAnsweropties, welke straks doorlopen wordt

                foreach (tblAnsweroption dbAnswerOption in dbAnsweroption)
                { // Doorloopt de antwoordopties die een foreign key naar de geselecteerde question in de database hebben
                    // Doordat we data hebben van onze answeroption, kunnen we nu ook de gehele vraag halen
                    tblAnswer tblAnswer = dbAnswerOption.tblAnswer; // Cast antwoordtabel in variable

                    Answer answer = new Answer(tblAnswer.description); // Maakt een nieuw antwoord aan
                    answer.ID = tblAnswer.id; // Werkt het id bij naar degene die ook in de database gebruikt wordt
                    answerOptions.Add(answer); // Voegt het antwoord object toe aan de lijst van antwoordopties die straks toegevoegd wordt aan de vraag
                }

                // Voegt de lijst met antwoord opties toe aan de vraag
                question.AnswerOptions = answerOptions;               

                return question;
            }
            // Als de query gefaalt is return null, deze wordt later opgevangen
            return null;
        }

        // Deze functie wordt gebruikt om een vragenlijst op te halen uit de database, het ID wordt hiervoor meegegeven
        public Questionnaire GetQuestionnaire(int id)
        {
            // Query die questionnaire op id selecteerd en opslaat in het Linq tblQuestionnaire object
            tblQuestionnaire dbQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == id);
            if (dbQuestionnaire != null)
            {// Als de query gelukt is
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
                foreach (tblQuestion dbQuestion in dbQuestionnaire.tblQuestions)
                {
                    MultipleChoiceQuestion question = new MultipleChoiceQuestion(dbQuestion.description); // 

                    question.ID = dbQuestion.id;
                    question.QuestionIndex = dbQuestion.questionindex;
                    if (dbQuestion.timerestriction != null)
                    {
                        question.TimeRestriction = TimeSpan.FromTicks((long) dbQuestion.timerestriction);
                    }
                    else
                    {
                        question.TimeRestriction = TimeSpan.Zero;
                    }
                    

                    List<Answer> answerOptions = new List<Answer>();

                    foreach (tblAnsweroption dbAnswerOption in dbQuestion.tblAnsweroptions)
                    {
                        // Doordat we data hebben van onze answeroption, kunnen we nu ook de gehele vraag halen
                        tblAnswer tblAnswer = dbAnswerOption.tblAnswer;

                        Answer answer = new Answer(tblAnswer.description);
                        answer.ID = tblAnswer.id;
                        answerOptions.Add(answer);

                        if (dbQuestion.correctanswer == answer.ID)
                        {
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
        }

        public void UpdateQuestionnaire(Questionnaire questionnaire)
        {
            tblQuestionnaire updateQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.id == questionnaire.ID);         // Haalt questionnaire op uit DB
            updateQuestionnaire.description = questionnaire.Name;                                                                      // Wijzigt naam van questionnaire in DB
            updateQuestionnaire.archived = questionnaire.Archived;

            foreach (tblQuestion dbQuestion in updateQuestionnaire.tblQuestions.ToList())                                            // Doorloopt lijst van bijbehorende questions uit DB
            {
              
                    MultipleChoiceQuestion question = (MultipleChoiceQuestion)questionnaire.Questions.Single(q => q.ID == dbQuestion.id);// Haalt Question op uit Questionnaire                 
                    dbQuestion.description = question.Description;                                                                      // Wijzigt de vraag in DB

                    foreach (tblAnsweroption dbLinkAnwser in dbQuestion.tblAnsweroptions.ToList())                                        // Doorloopt lijst van bijbehorende answers uit DB
                    {
                        tblAnswer dbAnswer = dbLinkAnwser.tblAnswer;
                        Answer answer = question.AnswerOptions.Single(a => a.ID == dbLinkAnwser.answer);                               // Haalt Answer op uit Question
                        dbAnswer.description = answer.Description;                                                                  // Wijzigt het antwoord in DB
                    }
                    dbQuestion.correctanswer = question.CorrectAnswer.ID;                                                          // Wijzigt het correcte antwoord in DB

                    // Question is verwijderd uit de questionnaire
                    // Verwijder deze ook uit de database
                    // DeleteMultipleChoiceQuestion(dbQuestion.id);
                
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

        public Questionnaire AddQuestionnaire(Teacher teacher, Questionnaire questionnaire)
        {
            tblQuestionnaire tblQuestionnaire = new tblQuestionnaire();
            

            tblQuestionnaire.author = teacher.TeacherNr; // test data
            tblQuestionnaire.description = questionnaire.Name;
            tblQuestionnaire.subject = questionnaire.Subject.Id;
            db.tblQuestionnaires.InsertOnSubmit(tblQuestionnaire);
            db.SubmitChanges();

            questionnaire.ID = tblQuestionnaire.id;
            questionnaire.Author = teacher;

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
            answer.description = receivedAnswer;

            db.tblAnswers.InsertOnSubmit(answer);
            db.SubmitChanges();

            return new Answer(answer.description)
            {
                ID = answer.id
            };
        }

        public void DeleteMultipleChoiceQuestion(int id)
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

        public MultipleChoiceQuestion AddMultipleChoiceQuestion(MultipleChoiceQuestion createdQuestion, int questionnaireId, tblQuestionnaire tblQuestionnaire)
        {
            tblQuestion question = new tblQuestion();
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
            List<tblAnsweroption> answerOptions = db.tblAnsweroptions.Where(q => q.question == questionId).ToList(); // Selecteer item op id
            foreach (tblAnsweroption dbAnswerOption in answerOptions)
            {
                db.tblAnsweroptions.DeleteOnSubmit(dbAnswerOption);
            }

             // Geef opdracht om bovenstaande item te verwijderen
            db.SubmitChanges(); // Voer veranderingen door
        }

        public void AnswerCleanup()
        {
            foreach(tblAnswer dbAnswer in db.tblAnswers) // Doorloopt alle antwoorden
            {
                if (dbAnswer.tblAnsweroptions.Count == 0) // Als een antwoordt geen relatie meer heeft met een answeroption
                {
                    db.tblAnswers.DeleteOnSubmit(dbAnswer); // dan wordt het antwoordt verwijderd.
                }
            }
            db.SubmitChanges(); // Voert de wijziginen uit
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

        // hier worden de afnamemomenten uit de database gehaald
        public List<Exam> GetAllExams()
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

        public List<Exam> GetExamsByQuestionnaire(Questionnaire q)
        {
            List<Exam> exams1 = new List<Exam>();
            List<tblExam> exams = (from tblExam in db.tblExams
                         where tblExam.tblQuestionnaire.id == q.ID select tblExam).ToList();

            foreach (tblExam exam in exams)
            {
                Exam newExam = new Exam(exam.id, q, exam.starttime, exam.endtime, exam.lecture);
                exams1.Add(newExam);
            }

            return exams1;
        } 


        public Exam GetExam(int examID) // Return een Exam van het opgegeven ID
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

        public List<Exam> GetExams()
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

        public void UpdateExamCurrentQuestion(int examId, int questionId) {
            if(examId != -1) {
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

        // hier worden de vragen die bij een specifieke vragenlijst horen opgehaald
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
        // hier worden de antwoorden opgehaald uit de database
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
        // hier worden de vragen opgehaald uit de database
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
        // hier worden de antwoorden opgehaald die bij een specifieke vraag horen
        public List<Answer> GetAnswersByQuestion(int id)
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
        // Hier worden de resultaten opgehaald voor elk specifieke antwoord.
        
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
        // hier wordt het antwoord opgehaald bij een antwoord ID (de beschrijving van het antwoord)
      public String GetDescriptionByAnswer(int id)
        {
            tblAnswer tblAnswers =                    (from answer in db.tblAnswers
                                                   where answer.id == id
                                                   select answer).FirstOrDefault();
            return tblAnswers.description; 
        }     
        

    }
}