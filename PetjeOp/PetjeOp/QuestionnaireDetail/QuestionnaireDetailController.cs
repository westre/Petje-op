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

        public bool Disabled { get; private set; }

        public QuestionnaireDetailController(MasterController masterController) : base(masterController) {
            Model = new QuestionnaireDetailModel();
            View = new QuestionnaireDetailView(this);
            Disabled = false;
        }

        
        public override UserControl GetView() {
            return View;
        }

        //Verander de questionnaire van de model.
        public void SetQuestionnaire(Questionnaire q)
        {
            Model.Questionnaire = q;

            if (Model.Questionnaire.Archived)
            {
                DisableControls();
                View.lblNoEdit.Show();
            }
            else
            {
                EnableControls();
                View.lblNoEdit.Hide();
            }
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
        public void FillCbSelectQuestionnaire()
        {
            View.cbSelectQuestionnaire.Items.Clear();
            List<Questionnaire> currentQuestionnaires = Model.Questionnaires;
            foreach (Questionnaire q in currentQuestionnaires)
            {
                View.cbSelectQuestionnaire.Items.Add(q);

            }
                View.cbSelectQuestionnaire.SelectedItem = Model.Questionnaire;
        }

        public void FillCbSubjects()
        {
            View.cbSubject.Items.Clear();

            Model.Subjects = MasterController.DB.GetSubjects();

            foreach (Subject s in Model.Subjects)
            {
                View.cbSubject.Items.Add(s);
            }
        }

        public void SelectSubject(Subject subject)
        {
            foreach (object item in View.cbSubject.Items)
            {
                Subject s = (Subject) item;

                if (subject.Id == s.Id)
                    View.cbSubject.SelectedItem = s;
            }
        }

        public void SaveQuestionnaireDetails()
        {
            Model.Questionnaire.Name = View.tbNameEdit.Text;
            Model.Questionnaire.Subject = (Subject) View.cbSubject.SelectedItem;

            View.tbNameEdit.Hide();
            View.cbSubject.Hide();

            View.btnSave.Hide();
            View.btnCancelEdit.Hide();
            View.btnEdit.Show();

            setLabels();
        }

        public void SaveQuestionnaire()
        {
            MasterController.DB.UpdateQuestionnaire(Model.Questionnaire);
        }

        public void CheckForErrors()
        {
            if (string.IsNullOrEmpty(View.epTbEdit.GetError(View.tbNameEdit)))
            {
                View.btnSave.Enabled = true;
            }
            else
            {
                View.btnSave.Enabled = false;
            }
        }

        public void CheckQuestions()
        {
            if (string.IsNullOrEmpty(View.questionsView1.epNoQuestions.GetError(View.questionsView1.lblQuestions)) && !Disabled)
            {
                View.btnSaveQuestionnaire.Enabled = true;
            }
            else
            {
                View.btnSaveQuestionnaire.Enabled = false;
            }
        }

        public void DisableControls()
        {
            Disabled = true;
            View.btnEdit.Enabled = false;
            View.questionsView1.DisableView();
        }

        public void EnableControls()
        {
            Disabled = false;
            View.btnEdit.Enabled = true;
            View.questionsView1.EnableView();
        }
    }
}
