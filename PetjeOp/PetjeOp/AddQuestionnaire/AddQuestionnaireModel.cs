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
        public AddQuestionDialog dialog;

        public AddQuestionnaireModel()
        {
            dialog = new AddQuestionDialog();
        }
    }
}
