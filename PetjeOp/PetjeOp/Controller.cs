using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public abstract class Controller {
        public MasterController MasterController { get; set; }

        public Controller(MasterController masterController) {
            MasterController = masterController;
        }

        public abstract UserControl GetView();
    }
}
