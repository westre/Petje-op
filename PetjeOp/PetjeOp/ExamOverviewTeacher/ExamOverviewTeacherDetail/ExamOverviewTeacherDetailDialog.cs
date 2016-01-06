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
            examOverviewTeacherDetailView.lblDuration.Text = "Looptijd: " + string.Format("{0:n2}", differenceMinutes) + " minuten";
            examOverviewTeacherDetailView.lblSubject.Text = "Vak: " + LocallyEditedExam.Questionnaire.Subject.Name;
            examOverviewTeacherDetailView.lblExecutedBy.Text = "Wordt afgenomen door: " + LocallyEditedExam.Lecture.Teacher;
            examOverviewTeacherDetailView.lblPlannedInBy.Text = "Ingepland door: " + LocallyEditedExam.Questionnaire.Author;
            examOverviewTeacherDetailView.lblForClass.Text = "Voor: " + LocallyEditedExam.Lecture.Class.Code;
        }

        private void ExamOverviewTeacherDetailDialog_Load(object sender, EventArgs e) {

        }

        public void EditClicked() {
            Exam = LocallyEditedExam;
            Event.Tag = Exam;

            TeacherController.MasterController.DB.UpdateExam(Exam);

            int changeCount = 0;
            foreach(Control control in examOverviewTeacherDetailView.Controls) {
                if(control is Label) {
                    if(!((Label)control).ForeColor.ToArgb().Equals(Color.Black.ToArgb())) {
                        changeCount++;
                    }
                    ((Label)control).ForeColor = Color.Black;
                }
            }

            string changes = "wijziging";
            if (changeCount > 1 || changeCount == 0)
                changes += "en";

            MessageBox.Show(changeCount + " " + changes + " toegepast");
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

            if (timeOption == DialogOption.START_TIME) {
                datePicker.MinDate = DateTime.Now;
                datePicker.Value = LocallyEditedExam.Starttime;
                timePicker.Value = LocallyEditedExam.Starttime;
            }
            else if(timeOption == DialogOption.END_TIME) {
                datePicker.MinDate = LocallyEditedExam.Starttime;
                datePicker.Value = LocallyEditedExam.Endtime;
                timePicker.Value = LocallyEditedExam.Endtime;
            }         

            Button confirmation = new Button() { Text = "OK", Left = 10, Width = 100, Top = 110 };
            confirmation.Click += (sender, e) => {
                DateTime newDate = datePicker.Value.Date + timePicker.Value.TimeOfDay;

                if (timeOption == DialogOption.START_TIME) {
                    if(newDate > LocallyEditedExam.Endtime || newDate < DateTime.Now) {
                        MessageBox.Show("Ongeldige datum");
                    }
                    else {
                        LocallyEditedExam.Starttime = newDate;
                        examOverviewTeacherDetailView.lblStarttime.ForeColor = Color.DarkOrange;
                        examOverviewTeacherDetailView.lblDuration.ForeColor = Color.DarkOrange;
                        prompt.Close();
                    }
                }
                else if (timeOption == DialogOption.END_TIME) {
                    if(newDate < LocallyEditedExam.Starttime) {
                        MessageBox.Show("Ongeldige datum");
                    }
                    else {
                        LocallyEditedExam.Endtime = newDate;
                        examOverviewTeacherDetailView.lblEndtime.ForeColor = Color.DarkOrange;
                        examOverviewTeacherDetailView.lblDuration.ForeColor = Color.DarkOrange;
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
                    LocallyEditedExam.Lecture = selectedLecture;
                    examOverviewTeacherDetailView.lblExecutedBy.ForeColor = Color.DarkOrange;
                    examOverviewTeacherDetailView.lblForClass.ForeColor = Color.DarkOrange;
                }
                else if (option == DialogOption.QUESTIONNAIRE) {
                    Questionnaire selectedQuestionnaire = (Questionnaire)listBox.SelectedItem;
                    LocallyEditedExam.Questionnaire = selectedQuestionnaire;
                    examOverviewTeacherDetailView.lblTitle.ForeColor = Color.DarkOrange;
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
