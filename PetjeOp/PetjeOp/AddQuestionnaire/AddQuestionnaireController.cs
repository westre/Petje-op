using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire.AddQuestion;
using PetjeOp.Questionnaires;

namespace PetjeOp.AddQuestionnaire
{
    public class AddQuestionnaireController : Controller
    {
        public AddQuestionnaireView View { get; set; }
        public AddQuestionnaireModel Model { get; set; }

        public AddQuestionnaireController(MasterController masterController) : base(masterController) {
            Model = new AddQuestionnaireModel();
            View = new AddQuestionnaireView(this);
        }

        //Slaat Questionnaire op in de database.
        public void SaveQuestionnaire() {
            Model.Questionnaire.Name = View.tbQuestionnaireName.Text;
            Model.Questionnaire.Author = (Teacher)MasterController.User;
            
            //Als de questionnaire geen ID heeft staat hij nog niet in de database dus maken we hem aan.
            if (Model.Questionnaire.ID == -1) {
                Model.Questionnaire = MasterController.DB.AddQuestionnaire((Teacher)MasterController.User, Model.Questionnaire);
            }
            else
            {
                MasterController.DB.UpdateQuestionnaire(Model.Questionnaire);
            }

            //Roep het questionnairescherm aan en voeg de huidige questionnaire er aan toe.
            QuestionnaireOverviewController qoc = (QuestionnaireOverviewController)MasterController.GetController(typeof(QuestionnaireOverviewController));
            qoc.GetAllQuestionnairesAndSubjects();
            qoc.FillTreeView();
            MasterController.SetController(qoc);
        }

        public override UserControl GetView()
        {
            return View;
        }

        //Kijk of de buttons enabled kunnen worden.
        public void CheckButtons()
        {
            bool nameCheck = false;
            bool subjectCheck = false;
            bool questionsCheck = false;

            //Kijk of er een vragenlijstnaam is ingevuld.
            if (!View.tbQuestionnaireName.Text.Any())
            {
                View.lblQuestionaireNameError.Text = "Vul een vraagnaam in!";
                nameCheck = false;
            }
            else
            {
                View.lblQuestionaireNameError.Text = "";
                nameCheck = true;
            }

            //Kijk of er een vak geselecteerd is.
            if (View.cbSubjects.SelectedItem == null)
            {
                View.lblErrorSubject.Text = "Selecteer een vak!";
                subjectCheck = false;
            } else
            {
                View.lblErrorSubject.Text = "";
                subjectCheck = true;
            }

            if (!View.questionsView1.ValidateQuestions())
            {
                View.lblNoQuestionsInQuestionaire.Text = "Voeg vragen toe";
                questionsCheck = false;
            }
            else
            {
                View.lblNoQuestionsInQuestionaire.Text = "";
                questionsCheck = true;
            }

            if (nameCheck && subjectCheck && questionsCheck)
            {
                View.btnSaveQuestionnaire.Enabled = true;
            }
            else
            {
                View.btnSaveQuestionnaire.Enabled = false;
            }
        }

        //Haal de vakken uit de database en voeg ze toe aan de huidige model, voeg ze ook toe aan de combobox.
        public void AddSubjects()
        {

            Model.Subjects = MasterController.DB.GetAllSubjects();
            foreach (Subject subject in Model.Subjects)
            {
                View.cbSubjects.Items.Add(subject);
            }
        }

        //Zet het vak naar het geselecteerde vak in de combobox.
        public void SetSubject()
        {
            //Wanneer de selecteditem van de subject not null is, set het huidige subject in de model.
            if (View.cbSubjects.SelectedItem != null)
            {
                Model.Questionnaire.Subject = (Subject)View.cbSubjects.SelectedItem;
            }
        }

        //Verander scherm naar QuestionnaireOverview
        public void GoToQuestionnaireOverview()
        {
            //Clear de controls op de controller.
            ClearControls();
            QuestionnaireOverviewController qoc = (QuestionnaireOverviewController)MasterController.GetController(typeof(QuestionnaireOverviewController));
            MasterController.SetController(qoc);
        }

        public void ClearControls()
        {
            //Clear de textbox in de Questionnairename
            View.tbQuestionnaireName.Clear();
            //Leeg de combobox
            View.cbSubjects.SelectedIndex = -1;
            //Clear de nodes van de treeview
            View.questionsView1.tvQuestions.Nodes.Clear();
        }
    }
}