using System;
using System.Collections.Generic;
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

            if (query!=null){                
                MultipleChoiceQuestion question = new MultipleChoiceQuestion(query.description);
                return question;
            }
            return null;          
        }

        /*public Questionnaire GetQuestionnaire(int id)
        {           
            tblQuestionnaire query = db.tblQuestionnaires.SingleOrDefault(q => q.id == id);

            if (query!=null){
                Questionnaire questionnaire = new Questionnaire(query.description);
                foreach(tblLinkQuestion question in query.tblLinkQuestions.ToList())
                {
                    questionnaire.addQuestion(new MultipleChoiceQuestion(question.tblQuestion.question));
                }
                return questionnaire;
            }
            return null;     
        }*/

        /*public void UpdateQuestionnaire(Questionnaire questionnaire)
        {
            tblQuestionnaire updateQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.questionnairenr == 0);         // Haalt questionnaire op uit DB
            updateQuestionnaire.questionnairename = questionnaire.Name;                                                                      // Wijzigt naam van questionnaire in DB

            foreach (tblLinkQuestion dbQuestion in updateQuestionnaire.tblLinkQuestions.ToList())                                            // Doorloopt lijst van bijbehorende questions uit DB
            {
                MultipleChoiceQuestion question = (MultipleChoiceQuestion)questionnaire.Questions.Select(q => q.ID == dbQuestion.questionnr);// Haalt Question op uit Questionnaire                 
                dbQuestion.tblQuestion.question = question.Description;                                                                      // Wijzigt de vraag in DB
                
                foreach(tblLinkAnswer dbLinkAnwser in dbQuestion.tblQuestion.tblLinkAnswers.ToList())                                        // Doorloopt lijst van bijbehorende answers uit DB
                {                                                                       
                    Answer answer = (Answer)question.AnswerOptions.Select(a => a.ID == dbLinkAnwser.answernr);                               // Haalt Answer op uit Question
                    dbLinkAnwser.tblAnswer.answer = answer.Description;                                                                      // Wijzigt het antwoord in DB
                }
                dbQuestion.tblQuestion.correctanswernr = question.CorrectAnswer.ID;                                                          // Wijzigt het correcte antwoord in DB
            }
            db.SubmitChanges();                                                                                                              // Waar alle Magic happens, alle bovenstaande wijzigingen worden doorgevoerd in de DB            
        }*/

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

            if (person!=null){
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

        public Questionnaire AddQuestionnaire(string name) { // Dit moet echt even een AI worden
            tblQuestionnaire questionnaire = new tblQuestionnaire();
            questionnaire.id = new Random().Next(100, 1000);
            questionnaire.author = "eltjo1";
            questionnaire.description = name;
            db.tblQuestionnaires.InsertOnSubmit(questionnaire);
            db.SubmitChanges();

            //return questionnaire.id;

            return new Questionnaire(name) {
                ID = questionnaire.id,
                Name = name
            };
        }

        public Answer GetAnswer(string answer) {
            tblAnswer foundAnswer =   (from answers in db.tblAnswers
                                where answers.description.ToString().Equals(answer)
                                select answers).FirstOrDefault();

            if(foundAnswer != null) {
                Console.WriteLine("Found answer: " + foundAnswer.ToString());

                Answer retrievedAnswer = new Answer(foundAnswer.ToString());
                retrievedAnswer.ID = foundAnswer.id;

                return retrievedAnswer;
            }
            return null;
        }

        public Answer AddAnswer(string receivedAnswer) {
            tblAnswer answer = new tblAnswer();
            answer.id = new Random().Next(100, 1000); // AI maken!!
            answer.description = receivedAnswer;

            db.tblAnswers.InsertOnSubmit(answer);
            db.SubmitChanges();

            return new Answer(answer.description) {
                ID = answer.id
            };
        }

        public void AddMultipleChoiceQuestion(MultipleChoiceQuestion createdQuestion, int questionnaireId) {
            tblQuestion question = new tblQuestion();
            question.id = new Random().Next(100, 1000); // AI maken!!
            question.description = createdQuestion.Description;
            question.correctanswer = createdQuestion.CorrectAnswer.ID;
            question.questionnaire = questionnaireId;

            db.tblQuestions.InsertOnSubmit(question);
            db.SubmitChanges();
        }
    }
}
