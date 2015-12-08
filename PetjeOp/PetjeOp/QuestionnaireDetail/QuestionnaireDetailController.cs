using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.QuestionnaireDetail;
using PetjeOp.Questionnaires;

namespace PetjeOp {
    public class QuestionnaireDetailController : Controller {
        public QuestionnaireDetailView View { get; set; }
        public QuestionnaireDetailModel Model { get; set; }

        public QuestionnaireDetailController(MasterController masterController) : base(masterController) {
            Model = new QuestionnaireDetailModel();
            View = new QuestionnaireDetailView(this);
        }

        public override UserControl GetView() {
            return View;
        }

        public void setQuestionnaire(Questionnaire q)
        {
            Model.Questionnaire = q;
        }

        public void GoToQuestionnaireOverview()
        {
            //Roep het questionnairescherm aan en voeg de huidige questionnaire er aan toe.
            QuestionnaireOverviewController qoc = (QuestionnaireOverviewController)MasterController.GetController(typeof(QuestionnaireOverviewController));
            qoc.GetAllQuestionnairesAndSubjects();
            qoc.FillTreeView();
            MasterController.SetController(qoc);
        }

    }
}
