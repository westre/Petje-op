using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {

    // Deze delegates worden gebruikt voor de nieuwe threats 
    public delegate void SetTextCallback();
    public delegate void SecondThreadDel();
    public class AnswerQuestionnaireController : Controller{
        public AnswerQuestionnaireView View { get; set; }
        public AnswerQuestionnaireModel Model { get; set; }
        public Exam Exam { get; set; }

        // QueryListeners voor de gegeven antwoorden, en veranderende vragen.
        private DatabaseListener changeListener = new DatabaseListener();
        private DatabaseListener resultListener = new DatabaseListener();

        private Thread demoThread;
        private Thread secondThread;
        public AnswerQuestionnaireController(MasterController masterController) : base(masterController) {
            Model = new AnswerQuestionnaireModel();
            View = new AnswerQuestionnaireView(this);
            
           changeListener.OnChange += refreshQuestion;
           resultListener.OnChange += ChangeResult;
        }
        public void ChangeResult(SqlNotificationEventArgs eventArgs) // Activeer een nieuwe threat
        {
            this.demoThread = new Thread(new ThreadStart(this.secondThreadFunction));

            this.demoThread.Start();
        }

        public void secondThreadFunction() // Krijg toegang met invoke tot de view
        {
            if (this.View.InvokeRequired)
            {
                SecondThreadDel d = new SecondThreadDel(secondThreadFunction); // Probeer toegang te krijgen
                this.View.Invoke(d);
            }
            else
            {
                setExam(Exam.Examnr); // Voer de Threat uit op de invoke
            }
        }
        public void Init(int ExamID) // Setup van de Controller
        {
            View.VraagBox.Items.Clear();
            setExam(ExamID);
            // Zet de Query listener
            changeListener.TrackedQuery = "SELECT currentquestion FROM [dbo].[exam] WHERE id = " + ExamID;
            changeListener.Start();
            // Zet de Query listener
            resultListener.TrackedQuery = "SELECT student FROM [dbo].[result] WHERE student = '" + ((Student)(MasterController.User)).StudentNr + "'";
            resultListener.Start();
        }

        public override UserControl GetView() {
            return View;
        }

        public Panel GetViewPanel() {
            return View.viewPanel;
        }

        public void refreshQuestion(SqlNotificationEventArgs eventArgs)  // Activeer een nieuwe threat
        {
            this.demoThread = new Thread(new ThreadStart(this.ThreadProcSafe));

            this.demoThread.Start();
        }
        private void ThreadProcSafe()
        {
            this.firstThreadFunction();
        }
        private void firstThreadFunction()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.View.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(firstThreadFunction);
                this.View.Invoke(d);
            }
            else
            {
                if (Exam.CurrentQuestion != null) // Update antwoord, als het mogelijk is.
                {
                    MultipleChoiceQuestion question = MasterController.DB.GetQuestion((int)Exam.CurrentQuestion);
                    tblResult result = new tblResult();

                    if (this.View.VraagBox.SelectedIndex != -1) // Controleer of antwoord is gegeven.
                    {
                    result.answer = question.AnswerOptions[this.View.VraagBox.SelectedIndex].ID;
                    }
                    else
                    {
                        result.answer = null;
                    }
                    result.student = ((Student)(MasterController.User)).StudentNr;
                    result.exam = Exam.Examnr;
                    result.question = question.ID;

                    MasterController.DB.InsertResult(result); // Insert antwoord in de database
                }
                

                
                setExam(Exam.Examnr);
            }
        }

        public void setExam(int examID) // Refreshed the gehele controller, en zet het nieuwe afnamenmoment.
        {

            this.Exam = MasterController.DB.GetExam(examID);

            if (Exam.CurrentQuestion != null)
            {
                this.View.VraagBox.Items.Clear();
                MultipleChoiceQuestion question = MasterController.DB.GetQuestion(Exam.Questionnaire.Questions.SingleOrDefault(s => s.ID == Exam.CurrentQuestion).ID);
                
                if (MasterController.DB.QuestionContainsAnswerFromUser(Exam, ((Student)(MasterController.User)), question))
                {
                    View.lblTitle_Results_Title.Text = "Deze vraag is al door u beantwoord...";
                    View.VraagBox.Visible = false;
                }
                else
                {
                    foreach (Answer answer in question.AnswerOptions)
                    {
                        View.VraagBox.Items.Add(answer.Description);
                    }
                    View.lblTitle_Results_Title.Text = question.Description;
                    View.VraagBox.Visible = true;
                }
            }
            else
            {
                View.lblTitle_Results_Title.Text = "Geen vraag beschikbaar! Wacht op de docent...";
                View.VraagBox.Visible = false;
            }
        }
    }
}
