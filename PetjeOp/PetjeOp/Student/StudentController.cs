using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class StudentController : Controller, IEnvironment {
        public StudentView View { get; set; }
        public QuestionnaireOverviewModel Model { get; set; }

        public StudentController(MasterController masterController) : base(masterController) {
            Model = new QuestionnaireOverviewModel();
            View = new StudentView(this);
        }

        public override UserControl GetView() {
            return View;
        }

        public Panel GetViewPanel() {
            return View.viewPanel;
        }

        public Panel GetHeaderPanel() {
            return View.pnlHeader;
        }

        public Panel GetLogoutButton() {
            return View.pnlButton_Logout_Background;
        }
    }
}
