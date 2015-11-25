using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class ViewResultsController : Controller {
        public ViewResultsView View { get; set; }
        public ViewResultsModel Model { get; set; }

        public ViewResultsController(MasterController masterController) : base(masterController) {
            Model = new ViewResultsModel();
            View = new ViewResultsView(this);
        }

        public override UserControl GetView() {
            return View;
        }
       
    }
}
