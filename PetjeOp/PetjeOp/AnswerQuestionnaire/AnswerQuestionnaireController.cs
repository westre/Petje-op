using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class AnswerQuestionnaireController : Controller, IEnvironment {
        public AnswerQuestionnaireView View { get; set; }
        public AnswerQuestionnaireModel Model { get; set; }
        public Questionnaire Questionnaire { get; set; }

        public AnswerQuestionnaireController(MasterController masterController) : base(masterController) {
            Model = new AnswerQuestionnaireModel();
            View = new AnswerQuestionnaireView(this);
        }

        public override UserControl GetView() {
            return View;
        }

        public Panel GetViewPanel() {
            return View.viewPanel;
        }
    }
}
