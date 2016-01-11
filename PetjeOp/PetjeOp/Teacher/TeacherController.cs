using PetjeOp.ViewResults.ChooseExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetjeOp.AddQuestionnaire;
using PetjeOp.Questionnaires;

namespace PetjeOp {
    public class TeacherController : Controller, IEnvironment {
        public TeacherView View { get; set; }
        public TeacherModel Model { get; set; }
        public Exam x { get; set; }

        public TeacherController(MasterController masterController) : base(masterController) {
            Model = new TeacherModel();
            View = new TeacherView(this);
            x = null;
        }

        public override UserControl GetView() {
            return View;
        }

        public Panel GetViewPanel() {
            return View.viewPanel;
        }
        // Deze functie laat de Dialog zien waarin de docent een afnamemoment kan kiezen
        public void ShowExamDialog() {
            Model.Dialog = new ChooseExamDialog(this);

            Model.Dialog.ShowDialog();
        }
        // Deze functie zorgt er voor dat er naar de results toe gegaan wordt, na het kiezen van een afnamemoment
        public void GoToResults() {
            ViewResultsController vrc = (ViewResultsController)MasterController.GetController(typeof(ViewResultsController));
            MasterController.SetController(vrc);
            vrc.ex = x;

            vrc.ShowResults(vrc.ex);
        }

        public void GoToQuestionnaireOverview()
        {
            QuestionnaireOverviewController qoc = (QuestionnaireOverviewController)MasterController.GetController(typeof(QuestionnaireOverviewController));
            MasterController.SetController(qoc);
        }

        public void GoToAddExamController()
        {
            AddExamController aoc = (AddExamController) MasterController.GetController(typeof (AddExamController));
            MasterController.SetController(aoc);
        }

        public void GoToExamOverview() {
            ExamOverviewTeacherController etc = (ExamOverviewTeacherController)MasterController.GetController(typeof(ExamOverviewTeacherController));
            etc.Load();
            MasterController.SetController(etc);
        }

        public Panel GetHeaderPanel() {
            return View.pnlHeader;
        }

        public Panel GetLogoutButton() {
            return View.pnlButton_Logout_Background;
        }

        public void GoToTeacherHome()
        {
            TeacherHomeController thc =(TeacherHomeController) MasterController.GetController(typeof(TeacherHomeController));
            MasterController.SetController(thc);
        }
    }
}