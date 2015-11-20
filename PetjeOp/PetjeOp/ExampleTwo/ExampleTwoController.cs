using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class ExampleTwoController : Controller {
        public ExampleTwoView View { get; set; }
        public ExampleTwoModel Model { get; set; }

        public ExampleTwoController(MasterController masterController) : base(masterController) {
            Model = new ExampleTwoModel();
            View = new ExampleTwoView(this);
        }

        public override UserControl GetView() {
            return View;
        }
    }
}
