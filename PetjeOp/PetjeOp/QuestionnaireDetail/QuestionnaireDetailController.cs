using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class QuestionnaireDetailController : Controller, IEnvironment {
        public QuestionnaireDetailView View { get; set; }
        public QuestionnaireDetailModel Model { get; set; }
        public Questionnaire Questionnaire { get; set; }

        public QuestionnaireDetailController(MasterController masterController) : base(masterController) {
            Model = new QuestionnaireDetailModel();
            View = new QuestionnaireDetailView(this);
        }

        public override UserControl GetView() {
            return View;
        }

        public Panel GetViewPanel() {
            return View.viewPanel;
        }
    }
}
