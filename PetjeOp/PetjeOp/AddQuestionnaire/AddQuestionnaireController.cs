using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire.AddQuestion;

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

        // Hier veranderen we de View met de data van ExampleModel
        public void UpdateView()
        {
            
        }

        // Laat de dialoog zien om een vraag toe te voegen
        public void ShowQuestionDialog()
        {
            Model.Dialog = new AddQuestionDialog(this);
            Model.Dialog.ShowDialog();
        }

        //Zet 'Wijzig' en 'Verwijder' aan
        public void EnableEditDeleteButtons()
        {
            View.btnEditQuestion.Enabled = true;
            View.btnDeleteQuestion.Enabled = true;
        }

        //Zet 'Wijzig' en 'Verwijder' uit
        public void DisableEditDeleteButtons()
        {
            View.btnEditQuestion.Enabled = false;
            View.btnDeleteQuestion.Enabled = false;
        }

        //Functie om 'Wijzig' en 'Verwijder' aan en uit te zetten wanneer er al dan niet een vraag is geselecteerd
        public void ControlEditDeleteButtons()
        {
            if (View.tvQuestions.SelectedNode != null && View.tvQuestions.SelectedNode.Parent == null)
            {
                EnableEditDeleteButtons();
                View.lblNoNodeSelectedError.Text = "";
            }
            else
            {
                DisableEditDeleteButtons();
                View.lblNoNodeSelectedError.Text = "Selecteer een vraag om de knoppen te activeren!";
            }
        }

        //Functie om de TreeView met vragen en antwoorden te updaten
        public void UpdateTreeView()
        {
            //Sorteer de lijst met vragen op QuestionIndex
            Model.Questions.Sort();

            //Maak de TreeView leeg
            View.tvQuestions.Nodes.Clear();

            //Loop door alle vragen heen
            foreach (MultipleChoiceQuestion q in Model.Questions)
            {
                //Voeg Node toe met vraag
                TreeNode addedNode = View.tvQuestions.Nodes.Add(q.QuestionIndex + ": " + q.Description);

                //Maak een bold font aan
                Font boldFont = new Font(View.tvQuestions.Font, FontStyle.Bold);

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
            View.tvQuestions.ExpandAll();
            CheckButtons();
        }

        public override UserControl GetView()
        {
            return View;
        }

        //Geef gegenereerde vraag door aan het model
        public void AddDialogInformation(MultipleChoiceQuestion question, bool updateTV)
        {
            //Voeg vraag toe aan lijst met vragen in Model
            Model.Questions.Add(question);

            //Bepaal of TreeView geupdatet moet worden
            if (updateTV)
            {
                UpdateTreeView();
            }
        }

        //Functie die uitgevoerd wordt bij wijzigen van een vraag
        public void editQuestion()
        {
            MultipleChoiceQuestion currentQuestion = null;
            int currentQuestionIndex = 0;

                //Controleer of er een Node geselecteerd is
            if (View.tvQuestions.SelectedNode != null)
            {
                //Bepaal vraag als attribuut voor Dialog
                currentQuestion = (MultipleChoiceQuestion) View.tvQuestions.SelectedNode.Tag;

                currentQuestionIndex = Model.Questions.FindIndex(ql => ql.QuestionIndex == currentQuestion.QuestionIndex);
            }

            //Toon dialoog
            AddQuestionDialog editDialog = new AddQuestionDialog(this, currentQuestion, (currentQuestionIndex + 1));
            DialogResult dr = editDialog.ShowDialog();

            //Als op OK is geklikt, verwijder de oude vraag.
            //Nieuwe vraag is toegevoegd bij het sluiten van het dialoog
            if (dr == DialogResult.OK)
            {
                Model.Questions.RemoveAt(currentQuestionIndex);
            }
                
            //Update de TreeView
            UpdateTreeView();
        }

        public void DeleteQuestion()
        {
            //Dialoog voor bevestiging
            DialogResult dr = MessageBox.Show("Weet u zeker dat u deze vraag wilt verwijderen?", "Let op", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            //Als er op OK geklikt is, verwijder antwoord uit lijst
            if (dr == DialogResult.Yes)
            {
                MultipleChoiceQuestion q = (MultipleChoiceQuestion) View.tvQuestions.SelectedNode.Tag;

                int index = Model.Questions.FindIndex(ql => ql.QuestionIndex == q.QuestionIndex);
                Model.Questions.RemoveAt(index);

                int newQuestionIndex = 1;
                foreach (Question question in Model.Questions)
                {
                    question.QuestionIndex = newQuestionIndex ++;
                }

                UpdateTreeView();

                DisableEditDeleteButtons();
            }
        }

        public void CheckButtons()
        {
            if (!View.tbQuestionnaireName.Text.Any())
            {
                View.lblQuestionaireNameError.Text = "Vul een vraagnaam in!";
                View.btnSaveQuestionnaire.Enabled = false;
            }
            else
            {
                View.lblQuestionaireNameError.Text = "";
                View.btnSaveQuestionnaire.Enabled = true;
            }

            if (View.tvQuestions.Nodes.Count == 0)
            {
                View.lblNoQuestionsInQuestionaire.Text = "Voeg vragen toe!";
                View.btnSaveQuestionnaire.Enabled = false;
            }
            else
            {
                View.lblNoQuestionsInQuestionaire.Text = "";
                View.btnSaveQuestionnaire.Enabled = true;
            }
        }
    }
}
