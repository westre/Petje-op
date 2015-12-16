using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class TeacherHomeController : Controller {
        public TeacherHomeView View { get; set; }
        public TeacherHomeModel Model { get; set; }

        public TeacherHomeController(MasterController masterController) : base(masterController) {
            Model = new TeacherHomeModel();
            View = new TeacherHomeView(this);
        }

        public override UserControl GetView() {
            return View;
        }
    }
}