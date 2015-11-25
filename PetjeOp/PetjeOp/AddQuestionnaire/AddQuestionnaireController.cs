using System;
using System.Collections.Generic;
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

        //Functie om 'Wijzig' en 'Verwijder' aan en uit te zetten wanneer er al dan niet een vraag is geselecteerd
        public void ControlEditDeleteButtons()
        {
            if (View.tvQuestions.SelectedNode != null)
            {
                //Vraag geselecteerd: zet knoppen aan
                View.btnEditQuestion.Enabled = true;
                View.btnDeleteQuestion.Enabled = true;
            } else
            {
                //Geen vraag geselecteerd: zet knoppen uit
                View.btnEditQuestion.Enabled = false;
                View.btnDeleteQuestion.Enabled = false;
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

                //Koppel vraagobject aan de Node
                addedNode.Tag = q;

                //Loop door alle antwoorden heen
                foreach (Answer answer in q.AnswerOptions)
                {
                    //Voeg Child toe
                    TreeNode addedChild = addedNode.Nodes.Add(answer.Description);

                    //Koppel antwoord aan Child
                    addedChild.Tag = answer;
                }
            }
            
            //Klap alle vragen uit
            View.tvQuestions.ExpandAll();
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

            //Bepaal vraag als attribuut voor Dialog
            foreach (MultipleChoiceQuestion q in Model.Questions)
            {
                //Controleer of er een Node geselecteerd is
                if (View.tvQuestions.SelectedNode != null)
                {
                    //Controleer of de geselecteerde vraag gelijk is aan de vraag in de lijst
                    if (q.Equals(View.tvQuestions.SelectedNode.Tag))
                    {
                        //Match de vraag
                        currentQuestion = q;

                        //Match de index
                        currentQuestionIndex = q.QuestionIndex;
                    }
                }
            }

            //Toon dialoog
            AddQuestionDialog editDialog = new AddQuestionDialog(this, currentQuestion, currentQuestionIndex);
            DialogResult dr = editDialog.ShowDialog();

            //Als op OK is geklikt, verwijder de oude vraag.
            //Nieuwe vraag is toegevoegd bij het sluiten van het dialoog
            if(dr == DialogResult.OK)
                Model.Questions.RemoveAt(currentQuestionIndex - 1);

            //Update de TreeView
            UpdateTreeView();
        }
    }
}
