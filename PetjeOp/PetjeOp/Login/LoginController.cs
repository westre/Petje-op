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
            // Set login model, View wordt in de Dialog doorgegeven
            Model = new LoginModel();
        }

        public override UserControl GetView() {
            // GetView wordt niet gebruikt bij login dialog, maar wordt wel verplicht om te implementeren door de Controller klasse
            // Bovendien is LoginView van type Form, wat niet valt te converteren naar een UserControl object
            return null; 
        }

        internal void StudentLogin() {
            // Deze functie wordt aangeroepen als een student inlogt
            Controller controller = MasterController.GetController(typeof(StudentController)); // Haalt controller van studentomgeving op
            MasterController.SetController(controller); // Set deze controller als actieve controller
            View.DialogResult = DialogResult.OK; // Set het dialog result naar OK om door te geven dat er een succesvolle login was
            View.Close(); // Logindialog wordt gesloten
        }


        internal void TeacherLogin() {
            // Deze functie wordt aangeroepen als een docent inlogt
            Controller controller = MasterController.GetController(typeof(TeacherController)); // Haalt controller van docentomgeving op
            MasterController.SetController(controller); // Set deze controller als actieve controller
            View.DialogResult = DialogResult.OK; // Set het dialog result naar OK om door te geven dat er een succesvolle login was
            View.Close(); // Logindialog wordt gesloten
        }
        internal void QuestionnaireDetail()
        {
            // Dit is een tijdelijke functie voor de tijdelijke knop, deze moet nog verwijderd worden!
            Controller controller = MasterController.GetController(typeof(QuestionnaireDetailController));
            MasterController.SetController(controller);
            View.DialogResult = DialogResult.OK;
            View.Close();
        }
        internal void AnswerQuestion(int ExamID)
        {
            // Dit is een tijdelijke functie voor de tijdelijke knop, deze moet nog verwijderd worden!
            Controller controller = MasterController.GetController(typeof(AnswerQuestionnaireController));
            AnswerQuestionnaireController AnswerQuestionnaireController = (AnswerQuestionnaireController)controller;
            AnswerQuestionnaireController.setExam(ExamID);

            MasterController.SetController(controller);
            View.DialogResult = DialogResult.OK;
            View.Close();
        }
    }
}
