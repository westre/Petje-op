using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetjeOp.AddQuestionnaire.AddQuestion;

namespace PetjeOp.AddQuestionnaire
{
    public class AddQuestionnaireModel
    {
        public string Name { get; set; }
        public AddQuestionDialog Dialog { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Question> Questions { get; set; } 

        public AddQuestionnaireModel()
        {
            Questions = new List<Question>();
        }
    }
}
