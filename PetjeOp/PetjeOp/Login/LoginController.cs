using PetjeOp.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class LoginController : Controller {
        public LoginView View { get; set; }
        public LoginModel Model { get; set; }

        public BackgroundWorker BackgroundWorker { get; set; }

        public LoginController(MasterController masterController) : base(masterController) {
            // Set login model, View wordt in de Dialog doorgegeven
            Model = new LoginModel();

            // BackgroundWorker = Thread
            BackgroundWorker = new BackgroundWorker();

            // Zodat we aanroepen van de worker thread kunnen opvangen in de main thread
            BackgroundWorker.WorkerReportsProgress = true;

            // DoWork is de worker thread, dus onafhankelijk van de main thread
            BackgroundWorker.DoWork += BackgroundWorker_DoWork;
            
            // Dit wordt uitgevoerd op de main thread, met de ontvangen data van de worker thread
            BackgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            var message = e.UserState.ToString();

            if(message == "ErGingWatMis") {
                View.Error.Text = "Onjuiste Login...";
                View.Error.Visible = true;
            }
            else if (message == "NiksIngevuld") {
                View.Error.Text = "U heeft niks ingevuld...";
                View.Error.Visible = true;
            }
            else if (message == "TeacherLogin") {
                MasterController.User = MasterController.DB.GetTeacher(View.txtLoginCode.Text); // Haal de Teacher uit de DB.
                TeacherLogin(); // Zet de client over naar Teacher omgeving
            }
            else if (message == "StudentLogin") {
                MasterController.User = MasterController.DB.GetStudent(View.txtLoginCode.Text); // Haal de Student uit de DB.
                StudentLogin(); // Zet de client over naar Student omgeving
            }

            View.pbLoading.Visible = false;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            if (View.txtLoginCode.Text == "") // Controleert of het text-veld blanco is, en zet het label naar een ERROR.
            {              
                BackgroundWorker.ReportProgress(0, "NiksIngevuld"); // Stuur data naar de main thread
            }
            else {
                if (MasterController.DB.GetStudent(View.txtLoginCode.Text) != null) // Controleer op een code van een Student
                {                   
                    BackgroundWorker.ReportProgress(0, "StudentLogin"); // Stuur data naar de main thread
                }
                else if (MasterController.DB.GetTeacher(View.txtLoginCode.Text) != null) // Controleer op een code van een Teacher
                {              
                    BackgroundWorker.ReportProgress(0, "TeacherLogin"); // Stuur data naar de main thread
                }
                else // Zet het label naar een ERROR
                {
                    BackgroundWorker.ReportProgress(0, "ErGingWatMis"); // Stuur data naar de main thread 
                }
            }
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
            View.Close();
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
            Controller controller = MasterController.GetController(typeof(StudentController));
            MasterController.SetController(controller);

            AnswerQuestionnaireController aqc = (AnswerQuestionnaireController)MasterController.GetController(typeof(AnswerQuestionnaireController));
            aqc.setExam(ExamID);
            aqc.Init(ExamID);
            MasterController.SetController(aqc);

            /*Controller controller = MasterController.GetController(typeof(AnswerQuestionnaireController));
            AnswerQuestionnaireController AnswerQuestionnaireController = (AnswerQuestionnaireController)controller;
            AnswerQuestionnaireController.setExam(ExamID);
            AnswerQuestionnaireController.Init(ExamID);
            MasterController.SetController(controller);*/
            View.DialogResult = DialogResult.OK;
            View.Close();
        }
    }
}