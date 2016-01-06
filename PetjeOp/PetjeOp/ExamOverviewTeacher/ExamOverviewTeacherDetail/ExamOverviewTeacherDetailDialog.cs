using System;
using System.Windows.Forms;
using Calendar.NET;

namespace PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail {
    public partial class ExamOverviewTeacherDetailDialog : Form {
        public CustomEvent Event { get; set; }
        public ExamOverviewTeacherController TeacherController { get; set; }
        public Exam Exam { get; set; }

        private enum DialogOption {
            START_TIME,
            END_TIME,
            LECTURE,
            QUESTIONNAIRE
        }

        public ExamOverviewTeacherDetailDialog(ExamOverviewTeacherController teacherController, CustomEvent @event) {
            TeacherController = teacherController;
            Event = @event;
            Exam = (Exam)Event.Tag;

            InitializeComponent();

            UpdateView();
        }

        private void UpdateView() {
            double differenceMinutes = (Exam.Endtime - Exam.Starttime).TotalMinutes;

            examOverviewTeacherDetailView.lblTitle.Text = Exam.Questionnaire.Name;
            examOverviewTeacherDetailView.lblStarttime.Text = "Starttijd: " + Exam.Starttime.ToString();
            examOverviewTeacherDetailView.lblEndtime.Text = "Eindtijd: " + Exam.Endtime.ToString();
            examOverviewTeacherDetailView.lblDuration.Text = "Looptijd: " + string.Format("{0:n2}", differenceMinutes) + " minuten";
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

        public void StartTimeEdit() {
            ShowDateTimeDialog("Starttime", DialogOption.START_TIME);
            // todo: update database
        }

        public void EndTimeEdit() {
            ShowDateTimeDialog("Endtime", DialogOption.END_TIME);
            // todo: update database
        }

        public void LectureEdit() {
            ShowListBoxDialog("Lecture", DialogOption.LECTURE);
            // todo: update database
        }

        public void QuestionnaireEdit() {
            ShowListBoxDialog("Questionnaire", DialogOption.QUESTIONNAIRE);
            // todo: update database
        }

        private void ShowDateTimeDialog(string title, DialogOption timeOption) {
            Form prompt = new Form();
            prompt.Width = 250;
            prompt.Height = 200;
            prompt.Text = title;

            Label textLabel = new Label() { Left = 10, Top = 20, Text = title };

            DateTimePicker datePicker = new DateTimePicker() { Left = 10, Top = 50 };

            DateTimePicker timePicker = new DateTimePicker() { Left = 10, Top = 80 };
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;

            Button confirmation = new Button() { Text = "OK", Left = 10, Width = 100, Top = 110 };
            confirmation.Click += (sender, e) => {
                DateTime newDate = datePicker.Value.Date + timePicker.Value.TimeOfDay;

                if (timeOption == DialogOption.START_TIME) {
                    if(newDate > Exam.Endtime || newDate < DateTime.Now) {
                        MessageBox.Show("Ongeldige datum");
                    }
                    else {
                        Exam.Starttime = newDate;
                        prompt.Close();
                    }
                }
                else if (timeOption == DialogOption.END_TIME) {
                    if(newDate < Exam.Starttime) {
                        MessageBox.Show("Ongeldige datum");
                    }
                    else {
                        Exam.Endtime = newDate;
                        prompt.Close();
                    }        
                }
     
                UpdateView();
            };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);

            prompt.Controls.Add(datePicker);
            prompt.Controls.Add(timePicker);

            prompt.ShowDialog();
        }

        private void ShowListBoxDialog(string title, DialogOption option) {
            Form prompt = new Form();
            prompt.Width = 400;
            prompt.Height = 540;
            prompt.Text = title;

            Label textLabel = new Label() { Left = 10, Top = 20, Text = title };

            ListBox listBox = new ListBox() { Left = 10, Top = 50, Width = 360, Height = 400 };

            if(option == DialogOption.LECTURE) {
                foreach(Lecture lecture in TeacherController.MasterController.DB.GetAllLectures()) {
                    listBox.Items.Add(lecture);
                }
            }
            else if (option == DialogOption.QUESTIONNAIRE) {
                foreach (Questionnaire questionnaire in TeacherController.MasterController.DB.GetAllQuestionnaires()) {
                    listBox.Items.Add(questionnaire);
                }
            }

            Button confirmation = new Button() { Text = "OK", Left = 10, Width = 100, Top = 470 };
            confirmation.Click += (sender, e) => {
                if(option == DialogOption.LECTURE) {
                    Lecture selectedLecture = (Lecture)listBox.SelectedItem;
                    Exam.Lecture = selectedLecture;
                }
                else if (option == DialogOption.QUESTIONNAIRE) {
                    Questionnaire selectedQuestionnaire = (Questionnaire)listBox.SelectedItem;
                    Exam.Questionnaire = selectedQuestionnaire;
                }

                prompt.Close();
                UpdateView();
            };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);

            prompt.Controls.Add(listBox);

            prompt.ShowDialog();
        }
    }
}
