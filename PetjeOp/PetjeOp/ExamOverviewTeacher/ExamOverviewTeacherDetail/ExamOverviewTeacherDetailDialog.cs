using System;
using System.Windows.Forms;
using Calendar.NET;

namespace PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail {
    public partial class ExamOverviewTeacherDetailDialog : Form {
        public CustomEvent Event { get; set; }
        public ExamOverviewTeacherController TeacherController { get; set; }
        public Exam Exam { get; set; }

        public ExamOverviewTeacherDetailDialog(ExamOverviewTeacherController teacherController, CustomEvent @event) {
            TeacherController = teacherController;
            Event = @event;
            Exam = (Exam)Event.Tag;

            InitializeComponent();

            double differenceMinutes = (Exam.Endtime - Exam.Starttime).TotalMinutes;

            examOverviewTeacherDetailView.lblTitle.Text = Exam.Questionnaire.Name;
            examOverviewTeacherDetailView.lblStarttime.Text = "Starttijd: " + Exam.Starttime.ToString();
            examOverviewTeacherDetailView.lblEndtime.Text = "Eindtijd: " + Exam.Endtime.ToString();
            examOverviewTeacherDetailView.lblDuration.Text = "Looptijd: " + differenceMinutes + " minuten";
            examOverviewTeacherDetailView.lblSubject.Text = "Vak: " + Exam.Questionnaire.Subject.Name;
            examOverviewTeacherDetailView.lblExecutedBy.Text = "Wordt afgenomen door: " + Exam.Lecture.Teacher;
            examOverviewTeacherDetailView.lblPlannedInBy.Text = "Ingepland door: " + Exam.Questionnaire.Author;
            examOverviewTeacherDetailView.lblForClass.Text = "Voor: " + Exam.Lecture.Class.Code;
        }

        private void ExamOverviewTeacherDetailDialog_Load(object sender, EventArgs e) {

        }

        public void EditClicked() {
            MessageBox.Show("EditClicked");
        }

        public void RemoveClicked() {
            MessageBox.Show("RemoveClicked");
        }
    }
}
