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

        private void UpdateTreeView()
        {
            Model.Questions.Sort();
            View.tvQuestions.Nodes.Clear();
            foreach (Question q in Model.Questions)
            {
                View.tvQuestions.Nodes.Add(q.QuestionNumber + ": " + q.Description);
                foreach (Answer answer in Model.Dialog.Question.AnswerOptions)
                {
                    View.tvQuestions.Nodes[q.QuestionNumber-1].Nodes.Add(answer.Description);
                }
            }
        }

        public override UserControl GetView()
        {
            return View;
        }

        public void AddDialogInformation(MultipleChoiceQuestion question)
        {

            //Model.Questions[question.ID] = question;

            Model.Questions.Add(question);
            foreach (MultipleChoiceQuestion q in Model.Questions)
            {
                Console.WriteLine(q.Description);
            }
            UpdateTreeView();
        }

        public void editQuestion()
        {
            MultipleChoiceQuestion currentQuestion = null;
            int currentQuestionNumber = 0;
            foreach (MultipleChoiceQuestion q in Model.Questions)
            {
                if (View.tvQuestions.SelectedNode != null)
                {
                    if (q.QuestionNumber == (View.tvQuestions.SelectedNode.Index + 1))
                    {
                        currentQuestion = q;
                        currentQuestionNumber = q.QuestionNumber;
                    }
                }
                else
                {
                    Console.WriteLine("Selected node is null!");
                }
            }
            AddQuestionDialog editDialog = new AddQuestionDialog(this, currentQuestion);
            editDialog.ShowDialog();
            Model.Questions.RemoveAt(currentQuestionNumber);
            foreach (MultipleChoiceQuestion q in Model.Questions)
            {
                foreach (Answer a in q.AnswerOptions)
                {
                    Console.WriteLine(a.Description);
                }
            }
            UpdateTreeView();
        }
    }
}
