using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Drawing.Design;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;

namespace PetjeOp.Questionnaires
{
    public class QuestionnaireOverviewController : Controller
    {
        public QuestionnaireOverviewView View { get; set; }
        public QuestionnaireOverviewModel Model { get; set; }

        public QuestionnaireOverviewController(MasterController masterController) : base(masterController) {
            Model = new QuestionnaireOverviewModel();
            View = new QuestionnaireOverviewView(this);
        }

        public override UserControl GetView()
        {
            return View;
        }

        //Verander scherm naar AddQuestionnaire
        public void GoToAddQuestionnaire()
        {
            AddQuestionnaireController aqc = (AddQuestionnaireController)MasterController.GetController(typeof(AddQuestionnaireController));
            aqc.ClearControls();
            MasterController.SetController(aqc);
        }

        //Vraag alle Questionnaires en Subjects op
        public void GetAllQuestionnairesAndSubjects()
        {
            //Toon LoadingDialog tijdens ophalen gegevens
            LoadingDialog l = new LoadingDialog();
            l.Show();
            Application.DoEvents();

            //Vraag Questionnaires op
            Model.AllQuestionnaires = MasterController.DB.GetAllQuestionnaires();

            //Vraag Subjects op
            Model.Subjects = MasterController.DB.GetSubjects();

            //Vraag Teachers op
            Model.Teachers = MasterController.DB.GetTeachers();

            //Verberg LoadingDialog
            l.Hide();
        }

        //Vul ComboBox met Subjects
        public void FillComboBoxes()
        {
            //Maak ComboBox leeg
            View.cbSubjects.Items.Clear();
            View.cbAuthors.Items.Clear();

            //Voeg item toe om alle vakken te laden
            View.cbSubjects.Items.Add("Alle Vakken");
            View.cbAuthors.Items.Add("Alle Docenten");

            //Loop over Subjects
            foreach (Subject s in Model.Subjects)
            {
                //Subject toevoegen
                View.cbSubjects.Items.Add(s);
            }
            foreach (Teacher t in Model.Teachers)
            {
                //Teacher toevoegen
                View.cbAuthors.Items.Add(t);
            }

            //Selecteer eerste index
            View.cbSubjects.SelectedIndex = 0;
            View.cbAuthors.SelectedIndex = 0;
        }

        //Filter de Questionnaires
        public void FilterQuestionnaires(Subject s)
        {
            //Maak nieuwe List
            List<Questionnaire> newList = new List<Questionnaire>();

            //Loop over Questionnaires
            foreach (Questionnaire q in Model.ListQuestionnaires)
            {
                //Als SubjectID van Questonnair gelijk is aan ID van gekozen Subject
                if (q.Subject.Id == s.Id)
                    //Voeg toe aan nieuwe List
                    newList.Add(q);
            }
            //Vervang oude list door nieuwe List
            Model.ListQuestionnaires = newList;
        }

        public void FilterQuestionnaires(Teacher t)
        {
            //Maak nieuwe List
            List<Questionnaire> newList = new List<Questionnaire>();

            //Loop over Questionnaires
            foreach (Questionnaire q in Model.ListQuestionnaires)
            {
                //Als SubjectID van Questonnair gelijk is aan ID van gekozen Subject
                if (q.Author.TeacherNr == t.TeacherNr)
                    //Voeg toe aan nieuwe List
                    newList.Add(q);
            }
            //Vervang oude list door nieuwe List
            Model.ListQuestionnaires = newList;
        }
        
        //Reset de lijst zodat alle Questionnaires er weer in staan
        public void ResetLists()
        {
            //Kijk of de gearchiveerde vragenlijsten weergeven moeten worden.
            if (View.cbShowArchive.Checked)
            {
                //Laat alle vragenlijsten zien
                Model.ListQuestionnaires = Model.AllQuestionnaires;
            }
            else
            {
                //Laat alleen vragenlijsten zien die niet gearchiveerd zijn
                Model.ListQuestionnaires = Model.AllQuestionnaires.Where(q => q.Archived == false).ToList();
            }
            if (View.cbAuthors.SelectedItem is Teacher)
            {
                //Wanneer er iets is geselecteerd, filtreer de questionnaires
                FilterQuestionnaires((Teacher)View.cbAuthors.SelectedItem);
            }
            if (View.cbSubjects.SelectedItem is Subject)
            {
                //Wanneer er iets is geselecteerd, filtreer de questionnaires
                FilterQuestionnaires((Subject)View.cbSubjects.SelectedItem);
            }
        }

        public void GoToQuestionnaireDetails()
        {
            // Null check
            if(View.tvQuestionnaires.SelectedNode == null) {
                MessageBox.Show("Kies een afnamemoment");
                return;
            }

            //Roep het questionnairescherm aan en voeg de huidige questionnaire er aan toe.
            QuestionnaireDetailController qoc = (QuestionnaireDetailController)MasterController.GetController(typeof(QuestionnaireDetailController));

            //Bepaal geselecteerde Questionnaire
            qoc.SetQuestionnaire((Questionnaire)View.tvQuestionnaires.SelectedNode.Tag);

            //Set de ParentController
            qoc.View.questionsView1.ParentController = qoc;

            //Update de TreeView met vragen in QuestionnareDetails
            qoc.View.questionsView1.UpdateTreeView();

            //Set lijst met alle Questionnaires in QuestionnaireDetails
            qoc.Model.Questionnaires = Model.AllQuestionnaires;

            //Vul de ComboBox met alle Questionnaires
            qoc.FillCbSelectQuestionnaire();

            //Verander scherm naar QuestionnareDetails
            MasterController.SetController(qoc);
        }

        public void CheckButtons()
        {
            //Als er een Node geselecteerd is, mag de knop 'Details' aangezet worden
            if (View.tvQuestionnaires.SelectedNode != null)
            {
                Questionnaire selectedQuestionnaire = (Questionnaire) View.tvQuestionnaires.SelectedNode.Tag;

                if (!selectedQuestionnaire.Archived)
                {
                    //Wanneer de huidige questionnaire niet gearchiveerd is, kan je hem verwijderen en niet recoveren
                    View.btnDelete.Enabled = true;
                    View.btnRecover.Hide();
                }
                else
                {
                    //Zo niet, kan je hem niet verwijderen maar wel recoveren
                    View.btnDelete.Enabled = false;
                    View.btnRecover.Show();
                }
                View.btnDetails.Enabled = true;
            }
            else
            {
                //Zo niet, verstop allen knoppen en zorg dat knoppen niet meer ingedrukt wordt
                View.btnDetails.Enabled = false;
                View.btnDelete.Enabled = false;
                View.btnRecover.Hide();
            }
        }

        public void ArchiveQuestionnaire()
        {
            // Null check
            if (View.tvQuestionnaires.SelectedNode == null) {
                MessageBox.Show("Kies een afnamemoment");
                return;
            }

            //Vraag of de gebruiker echt wilt archiveren
            DialogResult dlr = MessageBox.Show("Weet u zeker dat u deze vragenlijst wilt archiveren?",
                "Waarschuwing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //Wanneer er ja geklikt wordt, archiveer de vraag
            if (dlr == DialogResult.Yes)
            {
                Questionnaire selectedQuestionnaire = (Questionnaire) View.tvQuestionnaires.SelectedNode.Tag;

                selectedQuestionnaire.Archived = true;

                MasterController.DB.UpdateQuestionnaire(selectedQuestionnaire);

                FillTreeView();
                CheckButtons();
            }
        }

        public void UnarchiveQuestionnaire()
        {
            //Vraag of de gebruiker de vraag echt wilt herstellen
            DialogResult dlr = MessageBox.Show("Weet u zeker dat u deze vragenlijst wilt herstellen?",
                "Waarschuwing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //Wanneer er ja geklikt wordt, herstel de vraag
            if (dlr == DialogResult.Yes)
            {
                Questionnaire selectedQuestionnaire = (Questionnaire)View.tvQuestionnaires.SelectedNode.Tag;

                selectedQuestionnaire.Archived = false;

                MasterController.DB.UpdateQuestionnaire(selectedQuestionnaire);

                FillTreeView();
                CheckButtons();
            }
        }

        public void FillTreeView()
        {
            ResetLists();
            //Vul de TreeView met gegevens
            //TreeView leegmaken
            View.tvQuestionnaires.Nodes.Clear();

            //Loop over Questionnaires
            foreach (Questionnaire questionnaire in Model.ListQuestionnaires)
            {
                //Voeg Node toe
                TreeNode questionnaireTreeNode = View.tvQuestionnaires.Nodes.Add(questionnaire.Name + " (" + questionnaire.Subject + ")");
                questionnaireTreeNode.Tag = questionnaire;

                if (questionnaire.Archived)
                    questionnaireTreeNode.ForeColor = Color.DarkGray;

                //Loop over Questions
                foreach (MultipleChoiceQuestion question in questionnaire.Questions)
                {
                    //Voeg Node toe
                    TreeNode questionTreeNode =
                        questionnaireTreeNode.Nodes.Add(question.QuestionIndex + ": " + question.Description);
                    questionTreeNode.Tag = question;

                    if (questionnaire.Archived)
                        questionTreeNode.ForeColor = Color.DarkGray;

                    //Loop over Answers
                    foreach (Answer answer in question.AnswerOptions)
                    {
                        //Check of antwoord correct antwoord is
                        if (answer.ID == question.CorrectAnswer.ID)
                        {
                            //Voeg antwoord toe en zet de kleur naar groen
                            TreeNode addedAnswer = questionTreeNode.Nodes.Add(question.CorrectAnswer.Description);
                            addedAnswer.Tag = answer;
                            addedAnswer.ForeColor = Color.Green;
                        }
                        else
                        {
                            //Voeg antwoord toe en zet de kleur naar rood
                            TreeNode addedAnswer = questionTreeNode.Nodes.Add(answer.Description);
                            addedAnswer.Tag = answer;
                            addedAnswer.ForeColor = Color.Red;
                        }
                    }
                }
            }

            //Sorteer Nodes alfabetisch
            View.tvQuestionnaires.Sort();
        }

        public void FilterOnOwnQuestionnaires()
        {
            //Filter de lijst van vragenlijsten op de vragenlijsten van de ingelogde gebruiker
            if (View.cbOwnQuestionnairesOnly.Checked)
            {
                foreach (object s in View.cbAuthors.Items)
                {
                    if (s is Teacher)
                    {
                        Teacher s2 = (Teacher)s;
                        if (s2.TeacherNr == ((Teacher)MasterController.User).TeacherNr)
                        {
                            View.cbAuthors.SelectedItem = s2;
                            View.cbAuthors.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                View.cbAuthors.Enabled = true;
                View.cbAuthors.SelectedIndex = 0;
            }
        }
    }
}
