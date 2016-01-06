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

            examOverviewTeacherDetailView.lblStarttime.Text = "Starttijd: " + Exam.Starttime.ToString();
            examOverviewTeacherDetailView.lblEndtime.Text = "Eindtijd: " + Exam.Endtime.ToString();
            examOverviewTeacherDetailView.lblDuration.Text = "Looptijd: " + differenceMinutes + " minuten";
            examOverviewTeacherDetailView.lblSubject.Text = "Vak: " + Exam.Questionnaire.Subject.Name;
            examOverviewTeacherDetailView.lblExecutedBy.Text = "Wordt afgenomen door: " + Exam.Lecture.Class;
            examOverviewTeacherDetailView.lblPlannedInBy.Text = "Ingepland door: " + Exam.Questionnaire.Author;
        }

        private void ExamOverviewTeacherDetailDialog_Load(object sender, EventArgs e) {

        }
    }
}
