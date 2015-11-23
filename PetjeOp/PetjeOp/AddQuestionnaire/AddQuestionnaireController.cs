using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp.AddQuestionnaire
{
    public class AddQuestionnaireController : Controller
    {
        public AddQuestionnaireView View { get; set; }
        public AddQuestionnaireModel Model { get; set; }

        public AddQuestionnaireController(MasterController masterController) : base(masterController) {
            Model = new AddQuestionnaireModel();
            View = new AddQuestionnaireView(this);
        }

        // In de controller wordt zowel de Model als View aangestuurd
        // Als voorbeeld veranderen we nu data van de Model, een Model kun je zien als een entiteit/object die ALLEEN properties/variabelen vasthoudt
        public void SetName(string name)
        {
            Model.Name = name;
        }

        // Hier veranderen we de View met de data van ExampleModel
        public void UpdateView()
        {
            
        }

        // Laat de dialoog zien om een vraag toe te voegen
        public void ShowQuestionDialog()
        {
            Model.dialog.ShowDialog();
        }

        public void ControlEditDeleteButtons()
        {
            if (View.tvQuestions.SelectedNode != null)
            {
                View.btnEditQuestion.Enabled = true;
                View.btnDeleteQuestion.Enabled = true;
            } else
            {
                View.btnEditQuestion.Enabled = false;
                View.btnDeleteQuestion.Enabled = false;
            }
        }

        public override UserControl GetView()
        {
            return View;
        }
    }
}
