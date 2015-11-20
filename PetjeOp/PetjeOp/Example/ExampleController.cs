using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class ExampleController : Controller {
        public ExampleView View { get; set; }
        public ExampleModel Model { get; set; }

        public ExampleController(MasterController masterController) : base(masterController) {
            Model = new ExampleModel();
            View = new ExampleView(this);
        }

        // In de controller wordt zowel de Model als View aangestuurd
        // Als voorbeeld veranderen we nu data van de Model, een Model kun je zien als een entiteit/object die ALLEEN properties/variabelen vasthoudt
        public void SetName(string name) {
            Model.Name = name;
        }

        // Hier veranderen we de View met de data van ExampleModel
        public void UpdateView() {
            View.button1.Text = Model.Name;
        }

        public override UserControl GetView() {
            return View;
        }
    }
}
