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

        public void InitializeView() {
            //Zorg ervoor dat elke controller een grootte heeft die bij het venster past.
            GetView().Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            GetView().Width = MasterController.ActiveParentContainer.GetViewPanel().Width;
            GetView().Height = MasterController.ActiveParentContainer.GetViewPanel().Height;
        }
    }
}
