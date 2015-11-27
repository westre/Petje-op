using PetjeOp;
using PetjeOp.AddQuestionnaire;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class ViewResultsController : Controller {
        public ViewResultsView View { get; set; }
        public ViewResultsModel Model { get; set; }
        public Exam ex;

        public ViewResultsController(MasterController masterController) : base(masterController) {
            Model = new ViewResultsModel();
            View = new ViewResultsView(this);
        }

        public override UserControl GetView() {
            return View;
        }

        public void ShowResults()
        {
            View.listQuestions.Items.Clear();
            AddQuestionsToList();

            
        }

        public void AddQuestionsToList()
        {
            foreach (Question q in ex.questionnaire.Questions)
            {
                View.listQuestions.Items.AddRange(new object[] {
            q});
            }
            
        }

        public void ShowChart()
        {
            Question chosen = (Question)View.listQuestions.SelectedItem;
            // View.label1.Text = chosen.ToString();
            // View.chart1.Series.
            Console.WriteLine("iets");
            View.series1.Points.Clear();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 500D);
            dataPoint1.AxisLabel = "ssss";
            View.series1.Points.Add(dataPoint1);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 800D);
            dataPoint2.AxisLabel = "ssss2";
            View.series1.Points.Add(dataPoint2);

            //System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            //customLabel1.Text = "a";
            //customLabel1.ToPosition = 1D;
            //chartArea1.AxisX.CustomLabels.Add(customLabel1);
            //this.chart1.ChartAreas.Add(chartArea1);
        }
        public void GoToMainMenu()
        {
            Controller controller = MasterController.GetController(typeof(AddQuestionnaireController));
            MasterController.SetController(controller);
        }

    }
}
