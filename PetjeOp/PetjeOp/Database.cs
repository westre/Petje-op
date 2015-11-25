using System;
using System.Linq;

namespace PetjeOp
{
    //De MasterController wordt altijd meegegeven, gebruik is bijv. alsvolgt:
    //Question q = masterController.DB.GetQuestion(id);
    public class Database
    {
        DatabaseDataContext db = new DatabaseDataContext();

        public void Query()
        {
            Console.WriteLine(GetQuestion(0).Description);
        }

        public MultipleChoiceQuestion GetQuestion(int id)
        {
            tblQuestion query = db.tblQuestions.SingleOrDefault(q => q.questionnr == id);

            if (query!=null){                
                MultipleChoiceQuestion question = new MultipleChoiceQuestion(query.questionnr, query.question);
                return question;
            }
            return null;          
        }

        public Questionnaire GetQuestionnaire(int id)
        {           
            tblQuestionnaire query = db.tblQuestionnaires.SingleOrDefault(q => q.questionnairenr == id);

            if (query!=null){
                Questionnaire questionnaire = new Questionnaire(query.questionnairenr, query.questionnairename);
                foreach(tblLinkQuestion question in query.tblLinkQuestions.ToList())
                {
                    questionnaire.addQuestion(new MultipleChoiceQuestion(question.questionnr,question.tblQuestion.question));
                }
                return questionnaire;
            }
            return null;     
        }

        public void UpdateQuestionnaire(Questionnaire questionnaire)
        {
            tblQuestionnaire updateQuestionnaire = db.tblQuestionnaires.SingleOrDefault(q => q.questionnairenr == questionnaire.id);         // Haalt questionnaire op uit DB
            updateQuestionnaire.questionnairename = questionnaire.Name;                                                                      // Wijzigt naam van questionnaire in DB

            foreach (tblLinkQuestion dbQuestion in updateQuestionnaire.tblLinkQuestions.ToList())                                            // Doorloopt lijst van bijbehorende questions uit DB
            {
                MultipleChoiceQuestion question = (MultipleChoiceQuestion)questionnaire.Questions.Select(q => q.id == dbQuestion.questionnr);// Haalt Question op uit Questionnaire                 
                dbQuestion.tblQuestion.question = question.Description;                                                                      // Wijzigt de vraag in DB
                
                foreach(tblLinkAnswer dbLinkAnwser in dbQuestion.tblQuestion.tblLinkAnswers.ToList())                                        // Doorloopt lijst van bijbehorende answers uit DB
                {                                                                       
                    Answer answer = (Answer)question.AnswerOptions.Select(a => a.id == dbLinkAnwser.answernr);                               // Haalt Answer op uit Question
                    dbLinkAnwser.tblAnswer.answer = answer.Description;                                                                      // Wijzigt het antwoord in DB
                }
                dbQuestion.tblQuestion.correctanswernr = question.CorrectAnswer.id;                                                          // Wijzigt het correcte antwoord in DB
            }
            db.SubmitChanges();                                                                                                              // Waar alle Magic happens, alle bovenstaande wijzigingen worden doorgevoerd in de DB            
        }

        public Student GetStudent(int code)
        {
            //tblStudent query = db.tblStudents.SingleOrDefault(q => q.studentnr == code);
            //Student student = new Student(query.studentnr, query.firstname, query.name, query.groupnr);
            Student person = (from tblStudent in db.tblStudents
                               where tblStudent.studentnr == code
                               select new Student{
                                   StudentNr = tblStudent.studentnr,
                                   FirstName = tblStudent.firstname,
                                   SurName = tblStudent.name,
                                   GroupNr = tblStudent.groupnr
                               }).FirstOrDefault();           

            if (person!=null){
                return person;
            }
            return null;  
        }
        public Teacher GetTeacher(String code)
        {
            //tblStudent query = db.tblTeacher.SingleOrDefault(q => q.teachernr == code);
            //Student student = new Student(query.teachernr, query.firstname, query.name);
            Teacher person = (from tblTeacher in db.tblTeachers
                              where tblTeacher.teachernr == code
                              select new Teacher{
                                  TeacherNr = tblTeacher.teachernr,
                                  FirstName = tblTeacher.firstname,
                                  SurName = tblTeacher.name
                              }).FirstOrDefault();

            if (person != null)
            {
                return person;
            }
            return null;
        }
    }
}
