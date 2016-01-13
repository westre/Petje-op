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

            //Stop de gegevens van de geselecteerde exam in een nieuw object, zodat deze wel bewaard blijven.
            LocallyEditedExam = new Exam(Exam.Examnr, Exam.Questionnaire, Exam.Starttime, Exam.Endtime, Exam.Lecture);
            InitializeComponent();
            UpdateView();
        }

        private void UpdateView() {
            double differenceMinutes = (LocallyEditedExam.Endtime - LocallyEditedExam.Starttime).TotalMinutes;

            //Zet de tekst van alle labels naar correcte gegevens uit de model.
            examOverviewTeacherDetailView.lblTitle.Text = LocallyEditedExam.Questionnaire.Name;
            examOverviewTeacherDetailView.lblStarttime.Text = "Starttijd: " + LocallyEditedExam.Starttime.ToString();
            examOverviewTeacherDetailView.lblEndtime.Text = "Eindtijd: " + LocallyEditedExam.Endtime.ToString();
            examOverviewTeacherDetailView.lblDuration.Text = "Looptijd: " + string.Format("{0:n0}", differenceMinutes) + " minuten";
            examOverviewTeacherDetailView.lblSubject.Text = "Vak: " + LocallyEditedExam.Lecture.Subject.Name;
            examOverviewTeacherDetailView.lblExecutedBy.Text = "Wordt afgenomen door: " + LocallyEditedExam.Lecture.Teacher;
            examOverviewTeacherDetailView.lblPlannedInBy.Text = "Vragenlijst gemaakt door: " + LocallyEditedExam.Questionnaire.Author;
            examOverviewTeacherDetailView.lblForClass.Text = "Voor: " + LocallyEditedExam.Lecture.Class.Code;

            //Wanneer de starttijd kleiner is dan de datum van nu, kan je de exam niet meer verbeteren.
            if (LocallyEditedExam.Starttime < DateTime.Now)
                examOverviewTeacherDetailView.btnEditExam.Enabled = false;
        }

        public void EditExam() {
            //Wanneer er een examgeedit moet worden, maak een nieuwe controller aan, geef deze de gegevens mee en set dan de controller.
            EditExamController mmc = (EditExamController)TeacherController.MasterController.GetController(typeof(EditExamController));
            mmc.Model.Event = Event;
            mmc.Model.Exam = (Exam)Event.Tag;
            mmc.Model.LocallyEditedExam = new Exam(Exam.Examnr, Exam.Questionnaire, Exam.Starttime, Exam.Endtime, Exam.Lecture);
            mmc.Init();
            TeacherController.MasterController.SetController(mmc);
            Close();
        }
    }
}
