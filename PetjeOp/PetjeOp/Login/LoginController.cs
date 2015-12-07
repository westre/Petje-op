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
            Model = new LoginModel();
            View = new LoginView(this);
        }

        public override UserControl GetView() {
            return View;
        }

        internal void StudentLogin() {
            Controller controller = MasterController.GetController(typeof(StudentController));
            MasterController.SetController(controller);
        }
        internal void QuestionnaireDetail()
        {
            Controller controller = MasterController.GetController(typeof(QuestionnaireDetailController));
            MasterController.SetController(controller);
        }

        internal void TeacherLogin() {
            Controller controller = MasterController.GetController(typeof(TeacherController));
            MasterController.SetController(controller);
        }

        internal void AnswerQuestion(int ExamID)
        {
            
            Controller controller = MasterController.GetController(typeof(AnswerQuestionnaireController));
            AnswerQuestionnaireController AnswerQuestionnaireController = (AnswerQuestionnaireController)controller;
            AnswerQuestionnaireController.setExam(ExamID);

            MasterController.SetController(controller);
        }
    }
}
