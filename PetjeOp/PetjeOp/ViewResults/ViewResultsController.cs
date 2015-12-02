using PetjeOp;
using PetjeOp.AddQuestionnaire;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.Questionnaires;

namespace PetjeOp {
    public class ViewResultsController : Controller
    {
        public ViewResultsView View { get; set; }
        public ViewResultsModel Model { get; set; }
        public Exam ex;

        public ViewResultsController(MasterController masterController) : base(masterController)
        {
            Model = new ViewResultsModel();
            View = new ViewResultsView(this);
            
        }

        public override UserControl GetView()
        {
            return View;
        }

        public void ShowResults(Exam ex)
        {
            foreach (Question question in ex.questionnaire.Questions)
            {
                Console.WriteLine(question.Description);
            }
            View.listQuestions.Items.Clear();
            AddQuestionsToList(ex.questionnaire.Questions);

        }

        public void AddQuestionsToList(List<Question> questions)
        {
            foreach (Question q in questions)
            {

                View.listQuestions.Items.Add(q);
            }

        }

        public void ShowChart()
        {
            Question chosen = (Question)View.listQuestions.SelectedItem;
            View.label1.Text = chosen.Description;

            View.series1.Points.Clear();

            List<Answer> answers = this.MasterController.DB.GetAnswerByQuestion(chosen.ID);

            foreach (Answer answer in answers)
            {
                
                List<Result> results = this.MasterController.DB.GetResultByAnswer(chosen.ID, answer.ID, ex.Examnr);
                double amount = results.Count();
                System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, amount);
                dataPoint1.AxisLabel = Convert.ToString(this.MasterController.DB.GetDescriptionByAnswer(answer.ID));
                if(answer.ID == chosen.CorrectAnswer.ID)
                {
                    dataPoint1.Color = Color.Green;
                } else
                {
                    dataPoint1.Color = Color.Red;
                }
                

                View.series1.Points.Add(dataPoint1);

            }
        }
        public void GoToMainMenu()
        {
            Controller controller = MasterController.GetController(typeof(QuestionnaireOverviewController));
            MasterController.SetController(controller);
        }

    }
}