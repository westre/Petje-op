using PetjeOp.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class LoginController : Controller {
        public LoginView View { get; set; }
        public LoginModel Model { get; set; }

        public LoginController(MasterController masterController) : base(masterController) {
            //Set login model
            Model = new LoginModel();
        }

        public override UserControl GetView() {
            return null;
        }

        internal void StudentLogin() {
            Controller controller = MasterController.GetController(typeof(StudentController));
            MasterController.SetController(controller);
            View.DialogResult = DialogResult.OK;
            View.Close();
            MasterController.Show();          
        }
        internal void QuestionnaireDetail()
        {
            Controller controller = MasterController.GetController(typeof(QuestionnaireDetailController));
            MasterController.SetController(controller);
            View.DialogResult = DialogResult.OK;
            View.Close();
            MasterController.Show();
        }

        internal void TeacherLogin() {
            Controller controller = MasterController.GetController(typeof(TeacherController));
            MasterController.SetController(controller);
            View.DialogResult = DialogResult.OK;
            View.Close();
            MasterController.Show();
        }

        internal void AnswerQuestion(int ExamID)
        {           
            Controller controller = MasterController.GetController(typeof(AnswerQuestionnaireController));
            AnswerQuestionnaireController AnswerQuestionnaireController = (AnswerQuestionnaireController)controller;
            AnswerQuestionnaireController.setExam(ExamID);

            MasterController.SetController(controller);
            View.DialogResult = DialogResult.OK;
            View.Close();
            MasterController.Show();
        }
    }
}
