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

            if (query==null){ return null; }else{
                MultipleChoiceQuestion question = new MultipleChoiceQuestion(query.question);
                return question;
            }           
        }

        public Questionnaire GetQuestionnaire(int id)
        {           
            tblQuestionnaire query = db.tblQuestionnaires.SingleOrDefault(q => q.questionnairenr == id);

            if (query==null){ return null; }else{
                Questionnaire questionnaire = new Questionnaire(query.questionnairename);
                foreach(tblLinkQuestion question in query.tblLinkQuestions.ToList())
                {
                    questionnaire.addQuestion(new MultipleChoiceQuestion(question.tblQuestion.question));
                }
                return questionnaire;
            }
        }

        public void UpdateQuestionaire(Questionnaire input)
        {

        }
    }
}
