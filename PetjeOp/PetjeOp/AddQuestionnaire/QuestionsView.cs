using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire.AddQuestion;

namespace PetjeOp.AddQuestionnaire
{
    public partial class QuestionsView : UserControl
    {
        public AddQuestionDialog Dialog { get; set; }
        public Controller ParentController { get; set; }

        public QuestionsView()
        {
            InitializeComponent();
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            Dialog = new AddQuestionDialog(this);
            Dialog.ShowDialog();
        }

        private void tvQuestions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvQuestions.SelectedNode != null && tvQuestions.SelectedNode.Parent == null)
            {
                EnableEditDeleteButtons();
                lblNoNodeSelectedError.Text = "";
            } else
            {
                DisableEditDeleteButtons();
                lblNoNodeSelectedError.Text = "Selecteer een vraag om de knoppen te activeren!";
            }
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            MultipleChoiceQuestion currentQuestion = null;
            int currentQuestionIndex = 0;

            //Controleer of er een Node geselecteerd is
            if (tvQuestions.SelectedNode != null)
            {
                //Bepaal vraag als attribuut voor Dialog
                currentQuestion = (MultipleChoiceQuestion) tvQuestions.SelectedNode.Tag;

                if (ParentController is AddQuestionnaireController)
                {
                    currentQuestionIndex = ((AddQuestionnaireController) ParentController).Model.Questionnaire.Questions.FindIndex(ql => ql.QuestionIndex == currentQuestion.QuestionIndex);
                } else if (ParentController is QuestionnaireDetailController)
                {
                    currentQuestionIndex = ((QuestionnaireDetailController)ParentController).Model.Questionnaire.Questions.FindIndex(ql => ql.QuestionIndex == currentQuestion.QuestionIndex);
                }

                //currentQuestionIndex = Questionnaire.Questions.FindIndex(ql => ql.QuestionIndex == currentQuestion.QuestionIndex);
            }

            //Toon dialoog
            AddQuestionDialog editDialog = new AddQuestionDialog(this, currentQuestion, (currentQuestionIndex + 1));
            DialogResult dr = editDialog.ShowDialog();

            //Als op OK is geklikt, verwijder de oude vraag.
            //Nieuwe vraag is toegevoegd bij het sluiten van het dialoog
            if (dr == DialogResult.OK)
            {
                // Database actie
                ParentController.MasterController.DB.DeleteMultipleChoiceQuestion(currentQuestion);

                if (ParentController is AddQuestionnaireController)
                {
                    ((AddQuestionnaireController) ParentController).Model.Questionnaire.Questions.RemoveAt(
                        currentQuestionIndex);
                }
                else if(ParentController is QuestionnaireDetailController)
                {
                    ((QuestionnaireDetailController)ParentController).Model.Questionnaire.Questions.RemoveAt(
                        currentQuestionIndex);
                }
            }

            //Update de TreeView
            UpdateTreeView();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            Questionnaire tempQuestionnaire = new Questionnaire(-1);

            if (ParentController is AddQuestionnaireController)
            {
               tempQuestionnaire = ((AddQuestionnaireController) ParentController).Model.Questionnaire;
            } else if (ParentController is QuestionnaireDetailController)
            {
                tempQuestionnaire = ((QuestionnaireDetailController)ParentController).Model.Questionnaire;
            }

            //Dialoog voor bevestiging
            DialogResult dr = MessageBox.Show("Weet u zeker dat u deze vraag wilt verwijderen?", "Let op",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            //Als er op OK geklikt is, verwijder antwoord uit lijst
            if (dr == DialogResult.Yes)
            {
                MultipleChoiceQuestion q = (MultipleChoiceQuestion) tvQuestions.SelectedNode.Tag;

                int index = tempQuestionnaire.Questions.FindIndex(ql => ql.QuestionIndex == q.QuestionIndex);
                tempQuestionnaire.Questions.RemoveAt(index);

                // Verwijder van DB
                ParentController.MasterController.DB.DeleteMultipleChoiceQuestion(q);

                int newQuestionIndex = 1;
                foreach (Question question in tempQuestionnaire.Questions)
                {
                    question.QuestionIndex = newQuestionIndex++;
                }

                UpdateTreeView();
                DisableEditDeleteButtons();

                if (ParentController is AddQuestionnaireController)
                {
                    ((AddQuestionnaireController) ParentController).Model.Questionnaire = tempQuestionnaire;
                } else if (ParentController is QuestionnaireDetailController)
                {
                    ((QuestionnaireDetailController)ParentController).Model.Questionnaire = tempQuestionnaire;
                }
            }
        }

        //Zet 'Wijzig' en 'Verwijder' aan
        public void EnableEditDeleteButtons()
        {
            btnEditQuestion.Enabled = true;
            btnDeleteQuestion.Enabled = true;
        }

        //Zet 'Wijzig' en 'Verwijder' uit
        public void DisableEditDeleteButtons()
        {
            btnEditQuestion.Enabled = false;
            btnDeleteQuestion.Enabled = false;
        }

        //Functie om de TreeView met vragen en antwoorden te updaten
        public void UpdateTreeView()
        {
            Questionnaire tempQuestionnaire = new Questionnaire(-1);

            //Sorteer de lijst met vragen op QuestionIndex
            if (ParentController is AddQuestionnaireController)
            {
                tempQuestionnaire = ((AddQuestionnaireController) ParentController).Model.Questionnaire;
            }
            else if (ParentController is QuestionnaireDetailController)
            {
                tempQuestionnaire = ((QuestionnaireDetailController)ParentController).Model.Questionnaire;
            }

            tempQuestionnaire.Questions.Sort();

            //Maak de TreeView leeg
            tvQuestions.Nodes.Clear();

            //Loop door alle vragen heen
            foreach (MultipleChoiceQuestion q in tempQuestionnaire.Questions)
            {
                //Voeg Node toe met vraag
                TreeNode addedNode = tvQuestions.Nodes.Add(q.QuestionIndex + ": " + q.Description);

                //Maak een bold font aan
                Font boldFont = new Font(tvQuestions.Font, FontStyle.Bold);

                //Stel het bold font in voor de Node
                addedNode.NodeFont = boldFont;

                //Reset de tekst van de Node, zodat het nieuw font toegepast wordt
                addedNode.Text = addedNode.Text;

                //Koppel vraagobject aan de Node
                addedNode.Tag = q;

                //Loop door alle antwoorden heen
                foreach (Answer answer in q.AnswerOptions)
                {
                    string answerDescription = answer.Description;

                    Color childColor = Color.Red;

                    if (answer.Equals(q.CorrectAnswer))
                    {
                        childColor = Color.Green;
                    }

                    //Voeg Child toe
                    TreeNode addedChild = addedNode.Nodes.Add(answerDescription);
                    addedChild.ForeColor = childColor;

                    //Koppel antwoord aan Child
                    addedChild.Tag = answer;
                }
            }

            //Klap alle vragen uit
            tvQuestions.ExpandAll();
            //CheckButtons();
        }

        //Geef gegenereerde vraag door aan het model
        public void AddDialogInformation(MultipleChoiceQuestion question, bool updateTV)
        {
            //Voeg vraag toe aan lijst met vragen in Model

            if (ParentController is AddQuestionnaireController)
            {
                ((AddQuestionnaireController)ParentController).Model.Questionnaire.Questions.Add(question);
            } else if (ParentController is QuestionnaireDetailController)
            {
                ((QuestionnaireDetailController)ParentController).Model.Questionnaire.Questions.Add(question);
            }

            //Bepaal of TreeView geupdatet moet worden
            if (updateTV)
            {
                UpdateTreeView();
            }
        }

        public bool ValidateQuestions()
        {
            if (tvQuestions.Nodes.Count > 0)
            {
                return true;
            }

            return false;
        }

        private void QuestionsView_Load(object sender, EventArgs e)
        {
            UpdateTreeView();
        }
    }
}