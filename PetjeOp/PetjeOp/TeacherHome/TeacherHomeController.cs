using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp
{
    public class TeacherHomeController : Controller
    {
        public TeacherHomeView View { get; set; }
        public TeacherHomeModel Model { get; set; }

        public TeacherHomeController(MasterController masterController) : base(masterController)
        {
            Model = new TeacherHomeModel();
            View = new TeacherHomeView(this);
        }

        public override UserControl GetView()
        {
            return View;
        }

        //Maak een titel met de naam van de docent
        public void InitializeTitle()
        {
            View.lblWelcome.Text = String.Format("Welkom, {0} {1}!", MasterController.User.FirstName, MasterController.User.SurName);
        }

        //Ga naar het resultatenscherm
        public void GoToResults()
        {
            ((TeacherController)MasterController.ActiveParentContainer).ShowExamDialog();
        }

        //Ga naar het vragenlijstenscherm
        public void GoToQuestionnaires()
        {
            ((TeacherController)MasterController.ActiveParentContainer).GoToQuestionnaireOverview();
        }

        public void GoToExamOverview()
        {
            ExamOverviewTeacherController etc = (ExamOverviewTeacherController)MasterController.GetController(typeof(ExamOverviewTeacherController));
            etc.Load();
            MasterController.SetController(etc);
        }
    }
}