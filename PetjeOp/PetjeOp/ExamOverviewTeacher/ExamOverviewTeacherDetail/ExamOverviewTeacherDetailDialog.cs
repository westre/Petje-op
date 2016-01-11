using System;
using System.Windows.Forms;
using Calendar.NET;
using System.Drawing;

namespace PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail {
    public partial class ExamOverviewTeacherDetailDialog : Form {
        public CustomEvent Event { get; set; }
        public ExamOverviewTeacherController TeacherController { get; set; }
        public Exam Exam { get; set; }
        private Exam LocallyEditedExam { get; set; }

        public ExamOverviewTeacherDetailDialog(ExamOverviewTeacherController teacherController, CustomEvent @event) {
            TeacherController = teacherController;
            Event = @event;
            Exam = (Exam)Event.Tag;

            // Geen referenties naar het originele object
            LocallyEditedExam = new Exam(Exam.Examnr, Exam.Questionnaire, Exam.Starttime, Exam.Endtime, Exam.Lecture);

            InitializeComponent();

            UpdateView();
        }

        private void UpdateView() {
            double differenceMinutes = (LocallyEditedExam.Endtime - LocallyEditedExam.Starttime).TotalMinutes;

            examOverviewTeacherDetailView.lblTitle.Text = LocallyEditedExam.Questionnaire.Name;
            examOverviewTeacherDetailView.lblStarttime.Text = "Starttijd: " + LocallyEditedExam.Starttime.ToString();
            examOverviewTeacherDetailView.lblEndtime.Text = "Eindtijd: " + LocallyEditedExam.Endtime.ToString();
            examOverviewTeacherDetailView.lblDuration.Text = "Looptijd: " + string.Format("{0:n0}", differenceMinutes) + " minuten";
            examOverviewTeacherDetailView.lblSubject.Text = "Vak: " + LocallyEditedExam.Questionnaire.Subject.Name;
            examOverviewTeacherDetailView.lblExecutedBy.Text = "Wordt afgenomen door: " + LocallyEditedExam.Lecture.Teacher;
            examOverviewTeacherDetailView.lblPlannedInBy.Text = "Vragenlijst gemaakt door: " + LocallyEditedExam.Questionnaire.Author;
            examOverviewTeacherDetailView.lblForClass.Text = "Voor: " + LocallyEditedExam.Lecture.Class.Code;

            if (LocallyEditedExam.Starttime < DateTime.Now)
                examOverviewTeacherDetailView.btnEditExam.Enabled = false;
        }

        private void ExamOverviewTeacherDetailDialog_Load(object sender, EventArgs e) {

        }

        public void EditExam() {
            EditExamController mmc = (EditExamController)TeacherController.MasterController.GetController(typeof(EditExamController));

            mmc.Model.Event = Event;
            mmc.Model.Exam = (Exam)Event.Tag;
            // Geen referenties naar het originele object
            mmc.Model.LocallyEditedExam = new Exam(Exam.Examnr, Exam.Questionnaire, Exam.Starttime, Exam.Endtime, Exam.Lecture);

            mmc.Init();

            TeacherController.MasterController.SetController(mmc);

            Close();
        }
    }
}
