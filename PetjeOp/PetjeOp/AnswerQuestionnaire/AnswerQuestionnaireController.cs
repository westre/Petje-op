using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public delegate void SetTextCallback();
    public class AnswerQuestionnaireController : Controller{
        public AnswerQuestionnaireView View { get; set; }
        public AnswerQuestionnaireModel Model { get; set; }
        public Exam Exam { get; set; }
        private DatabaseListener changeListener = new DatabaseListener();
        private DatabaseListener resultListener = new DatabaseListener();

        private Thread demoThread;
        public AnswerQuestionnaireController(MasterController masterController) : base(masterController) {
            Model = new AnswerQuestionnaireModel();
            View = new AnswerQuestionnaireView(this);
            
           changeListener.TrackedQuery = "SELECT * FROM exam";
           changeListener.OnChange += refreshQuestion;
           resultListener.OnChange += refreshQuestion;
        }

        public void Init(int ExamID)
        {
            View.VraagBox.Items.Clear();
            setExam(ExamID);
            changeListener.TrackedQuery = "SELECT currentquestion FROM [dbo].[exam] WHERE id = " + ExamID;
            changeListener.Start();
            resultListener.TrackedQuery = "SELECT answer FROM [dbo].[result] WHERE student = '" + ((Student)(MasterController.User)).StudentNr + "'";
            resultListener.Start();
        }

        public override UserControl GetView() {
            return View;
        }

        public Panel GetViewPanel() {
            return View.viewPanel;
        }

        public void refreshQuestion(SqlNotificationEventArgs eventArgs)
        {
            this.demoThread = new Thread(new ThreadStart(this.ThreadProcSafe));

            this.demoThread.Start();
            System.Console.WriteLine(eventArgs.Info);
        }
        private void ThreadProcSafe()
        {
            this.SetText();
        }
        private void SetText()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.View.VraagBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.View.Invoke(d);
            }
            else
            {
                if (this.View.VraagBox.SelectedIndex != -1)
                {
                    MultipleChoiceQuestion question = MasterController.DB.GetQuestion(Exam.Questionnaire.Questions.SingleOrDefault(s => s.ID == Exam.CurrentQuestion).ID);

                    tblResult result = new tblResult();
                    result.answer = question.AnswerOptions[this.View.VraagBox.SelectedIndex].ID;
                    result.student = ((Student)(MasterController.User)).StudentNr;
                    result.exam = Exam.Examnr;
                    result.question = question.ID;

                    System.Console.WriteLine(result.answer + ", " + result.student + ", " + result.exam + ", " + result.question);

                    MasterController.DB.InsertResult(result);
                }

                this.View.VraagBox.Items.Clear();
                setExam(Exam.Examnr);
            }
        }

        public void setExam(int examID)
        {

            this.Exam = MasterController.DB.GetExam(examID);

            if (Exam.CurrentQuestion != null)
            {


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
