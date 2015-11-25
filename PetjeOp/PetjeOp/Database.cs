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
                MultipleChoiceQuestion question = new MultipleChoiceQuestion(query.question);
                return question;
            }
            return null;          
        }

        public Questionnaire GetQuestionnaire(int id)
        {           
            tblQuestionnaire query = db.tblQuestionnaires.SingleOrDefault(q => q.questionnairenr == id);

            if (query!=null){
                Questionnaire questionnaire = new Questionnaire(query.questionnairename);
                foreach(tblLinkQuestion question in query.tblLinkQuestions.ToList())
                {
                    questionnaire.addQuestion(new MultipleChoiceQuestion(question.tblQuestion.question));
                }
                return questionnaire;
            }
            return null;     
        }

        public Student GetStudent(int code)
        {
            Student person = (from tblStudent in db.tblStudents
                               where tblStudent.studentnr == code
                               select new Student
                               {
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
            Teacher person = (from tblTeacher in db.tblTeachers
                              where tblTeacher.teachernr == code
                              select new Teacher
                              {
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
