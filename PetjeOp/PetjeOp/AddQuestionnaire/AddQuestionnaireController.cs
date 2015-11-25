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

        // In de controller wordt zowel de Model als View aangestuurd
        // Als voorbeeld veranderen we nu data van de Model, een Model kun je zien als een entiteit/object die ALLEEN properties/variabelen vasthoudt
        public void SetName(string name)
        {
            Model.Name = name;
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

        public void ControlEditDeleteButtons()
        {
            if (View.tvQuestions.SelectedNode != null)
            {
                View.btnEditQuestion.Enabled = true;
                View.btnDeleteQuestion.Enabled = true;
            } else
            {
                View.btnEditQuestion.Enabled = false;
                View.btnDeleteQuestion.Enabled = false;
            }
        }

        public void UpdateTreeView()
        {
            Model.Questions.Sort();
            View.tvQuestions.Nodes.Clear();

            foreach (MultipleChoiceQuestion q in Model.Questions)
            {
                TreeNode addedNode = View.tvQuestions.Nodes.Add(q.QuestionIndex + ": " + q.Description);
                addedNode.Tag = q;

                foreach (Answer answer in q.AnswerOptions)
                {
                    TreeNode addedChild = addedNode.Nodes.Add(answer.Description);
                    addedChild.Tag = answer;
                }
            }
        }

        public override UserControl GetView()
        {
            return View;
        }

        public void AddDialogInformation(MultipleChoiceQuestion question, bool updateTV)
        {
            Model.Questions.Add(question);

            if (updateTV)
            {
                UpdateTreeView();
            }
        }

        public void editQuestion()
        {
            MultipleChoiceQuestion currentQuestion = null;
            int currentQuestionNumber = 0;

            //Bepaal vraag als attribuut voor Dialog
            foreach (MultipleChoiceQuestion q in Model.Questions)
            {
                if (View.tvQuestions.SelectedNode != null)
                {
                    if (q.Equals(View.tvQuestions.SelectedNode.Tag))
                    {
                        currentQuestion = q;
                        currentQuestionNumber = q.QuestionIndex;
                    }
                }
            }

            //Toon dialoog
            AddQuestionDialog editDialog = new AddQuestionDialog(this, currentQuestion, currentQuestionNumber);
            DialogResult dr = editDialog.ShowDialog();

            //Als op OK is geklikt, verwijder de oude vraag.
            //Nieuwe vraag is toegevoegd bij het sluiten van het dialoog
            if(dr == DialogResult.OK)
                Model.Questions.RemoveAt(currentQuestionNumber - 1);

            //Update de TreeView
            UpdateTreeView();
        }
    }
}
