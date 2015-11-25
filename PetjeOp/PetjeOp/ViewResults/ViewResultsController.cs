using PetjeOp.ViewResults.ChooseExam;
using System;
using System.Collections.Generic;
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
           // View.label1.Text = chosen.ToString() + " : " ex.results[chosen.ID].ToString();
            
        }

    }
}
