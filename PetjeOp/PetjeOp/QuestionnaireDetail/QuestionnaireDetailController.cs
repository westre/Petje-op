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

        //Verander de questionnaire van de model.
        public void setQuestionnaire(Questionnaire q)
        {
            Model.Questionnaire = q;
        }

        //
        public void GoToQuestionnaireOverview()
        {
            //Roep het questionnairescherm aan, haal gegevens uit de database en vul deze in in de treeview. 
            //Daarna zet je de huidige questionnaire op nul en set je de controller.
            
            QuestionnaireOverviewController qoc = (QuestionnaireOverviewController)MasterController.GetController(typeof(QuestionnaireOverviewController));
            qoc.GetAllQuestionnairesAndSubjects();
            qoc.FillTreeView();
            Model.Questionnaire = null;
            MasterController.SetController(qoc);
        }

        //Set labeldata in het scherm, auteurdata, naamdata en vakdata van een vragenlijst.
        public void setLabels()
        {
            View.lblAuthorData.Text = "(" + Model.Questionnaire.Author.TeacherNr + ") " + Model.Questionnaire.Author.FirstName + " " + Model.Questionnaire.Author.SurName;
            View.lblNameData.Text = Model.Questionnaire.Name;
            View.lblSubjectData.Text = Model.Questionnaire.Subject.Name;
        }

        //Stop gegevens van de database in de combobox.
        public void fillCbSelectQuestionnaire()
        {
            View.cbSelectQuestionnaire.Items.Clear();
            List<Questionnaire> currentQuestionnaires = Model.Questionnaires;
            foreach (Questionnaire q in currentQuestionnaires)
            {
                View.cbSelectQuestionnaire.Items.Add(q);

            }
                View.cbSelectQuestionnaire.SelectedItem = Model.Questionnaire;
        }
    }
}
