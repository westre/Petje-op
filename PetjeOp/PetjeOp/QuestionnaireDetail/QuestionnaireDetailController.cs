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

            //Check of vragenlijst gearchiveerd is
            if (Model.Questionnaire.Archived)
            {
                DisableControls();
                View.lblNoEdit.Text = "Vragenlijst kan niet gewijzigd worden, omdat deze gearchiveerd is";
                View.lblNoEdit.Show();
            }
            //Check of huidige teacher de auteur is
            else if (((Teacher) MasterController.User).TeacherNr != Model.Questionnaire.Author.TeacherNr)
            {
                DisableControls();
                View.lblNoEdit.Text = "Vragenlijst kan alleen gewijzigd worden door auteur";
                View.lblNoEdit.Show();
            }
            //Check of de vragenlijst resultaten bevat
            else if (MasterController.DB.QuestionnaireContainsResults(Model.Questionnaire.ID))
            {
                DisableControls();
                View.lblNoEdit.Text = "Vragenlijst kan niet gewijzigd worden, omdat deze resultaten bevat";
                View.lblNoEdit.Show();
            }
            else
            {
                EnableControls();
                View.lblNoEdit.Hide();
            }
        }

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
        public void SetLabels()
        {
            //Set de tekst van de labels naar de gegevens van de huidige questionnaire.
            View.lblAuthorData.Text = "(" + Model.Questionnaire.Author.TeacherNr + ") " + Model.Questionnaire.Author.FirstName + " " + Model.Questionnaire.Author.SurName;
            View.lblNameData.Text = Model.Questionnaire.Name;
            View.lblSubjectData.Text = Model.Questionnaire.Subject.Name;
        }

        //Vul ComboBox met vragenlijsten
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

        //Vul ComboBox met vakken
        public void FillCbSubjects()
        {
            View.cbSubject.Items.Clear();

            Model.Subjects = MasterController.DB.GetAllSubjects();

            foreach (Subject s in Model.Subjects)
            {
                View.cbSubject.Items.Add(s);
            }
        }

        //Selecteer vak in de combobox van de huidige Questionnaire
        public void SelectSubject(Subject subject)
        {
            foreach (object item in View.cbSubject.Items)
            {
                Subject s = (Subject) item;

                if (subject.Id == s.Id)
                    View.cbSubject.SelectedItem = s;
            }
        }

        //Sla de details van de Questionnaire op
        public void SaveQuestionnaireDetails()
        {
            Model.Questionnaire.Name = View.tbNameEdit.Text;
            Model.Questionnaire.Subject = (Subject) View.cbSubject.SelectedItem;

            View.tbNameEdit.Hide();
            View.cbSubject.Hide();

            View.btnSave.Hide();
            View.btnCancelEdit.Hide();
            View.btnEdit.Show();

            SetLabels();
        }

        //Update de Questionnaire in de database
        public void SaveQuestionnaire()
        {
            MasterController.DB.UpdateQuestionnaire(Model.Questionnaire, Model.DeletedQuestions);
        }

        //Kijk of de ErrorProvider(s) een error bevatten
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

        //Kijk of er vragen in de Questionniare aanwezig zijn
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

        //Zet de controls uit
        public void DisableControls()
        {
            Disabled = true;
            View.btnEdit.Enabled = false;
            View.questionsView1.DisableView();
        }

        //Zet de controls aan
        public void EnableControls()
        {
            Disabled = false;
            View.btnEdit.Enabled = true;
            View.questionsView1.EnableView();
        }
    }
}
