using PetjeOp.ViewResults.ChooseExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;
using PetjeOp.Questionnaires;

namespace PetjeOp
{
    public class TeacherController : Controller, IEnvironment
    {
        public TeacherView View { get; set; }
        public TeacherModel Model { get; set; }
        public Exam x { get; set; }

        public TeacherController(MasterController masterController) : base(masterController)
        {
            Model = new TeacherModel();
            View = new TeacherView(this);
            x = null;
        }
      

        public override UserControl GetView()
        {
            return View;
        }

        public Panel GetViewPanel()
        {
            return View.viewPanel;
        }

        public void ShowExamDialog()
        {
            Model.Dialog = new ChooseExamDialog(this);

            Model.Dialog.ShowDialog();
        }

        public void GoToResults()
        {
            ViewResultsController vrc = (ViewResultsController)MasterController.GetController(typeof(ViewResultsController));
            MasterController.SetController(vrc);
            vrc.ex = x;


            foreach(Question question in vrc.ex.questionnaire.Questions)
            {
                Console.WriteLine("question gevonden: " + question.Description);
            }

            vrc.ShowResults(vrc.ex);
        }

        public void GoToQuestionnaireOverview()
        {
            QuestionnaireOverviewController qoc = (QuestionnaireOverviewController)MasterController.GetController(typeof(QuestionnaireOverviewController));
            MasterController.SetController(qoc);
        }

        public void ShowDebugDialog()
        {
            DebugDialog dd = new DebugDialog(MasterController.DB.GetAllQuestionnaires());
            dd.ShowDialog();


        }
        
    }
}