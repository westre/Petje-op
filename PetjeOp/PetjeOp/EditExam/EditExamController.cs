using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class EditExamController : Controller {
        public EditExamView View { get; set; }
        public EditExamModel Model { get; set; }

        private enum DialogOption {
            START_TIME,
            END_TIME,
            LECTURE,
            QUESTIONNAIRE
        }

        public EditExamController(MasterController masterController) : base(masterController) {
            Model = new EditExamModel();
            View = new EditExamView(this);
        }

        public void GetAllData()
        {
            Model.Subjects = MasterController.DB.GetSubjects();
            Model.Classes = MasterController.DB.GetAllClasses();
        }

        public void FillSubjectsCb()
        {
            View.cbSubject.Items.Clear();
            View.cbClass.Items.Clear();
            foreach (Subject s in Model.Subjects)
            {
                View.cbSubject.Items.Add(s);
            }
            foreach (Class c in Model.Classes)
            {
                View.cbClass.Items.Add(c);
            }
        }
        public void StartTimeEdit() {
            ShowDateTimeDialog("Starttime", DialogOption.START_TIME);
        }

        public void EndTimeEdit() {
            ShowDateTimeDialog("Endtime", DialogOption.END_TIME);
        }

        public void LectureEdit() {
            ShowListBoxDialog("Lecture", DialogOption.LECTURE);
        }

        public void QuestionnaireEdit() {
            ShowListBoxDialog("Questionnaire", DialogOption.QUESTIONNAIRE);
        }

        public void EditClicked()
        {
            Class newClass = (Class)View.cbClass.SelectedItem;
            Subject newSubject = (Subject)View.cbSubject.SelectedItem;
            Lecture newLecture = new Lecture(0, (Teacher)MasterController.User, newClass, newSubject);
            Lecture dbLecture = MasterController.DB.CheckLecture(newLecture);
            if (dbLecture != null)
            {
                newLecture = dbLecture;
            }
            else
            {
                tblLecture tblLecture = MasterController.DB.AddLecture(newLecture);
                Teacher newTeacher = new Teacher(tblLecture.tblTeacher.nr, tblLecture.tblTeacher.firstname, tblLecture.tblTeacher.surname);
                Class newActualClass = new Class(tblLecture.@class);
                Subject newActualSubject = new Subject(tblLecture.tblSubject.id, tblLecture.tblSubject.name);
                Lecture newActualLecture = new Lecture(tblLecture.id, newTeacher, newActualClass, newActualSubject);
                newLecture = newActualLecture;
            }

            Model.LocallyEditedExam.Lecture = newLecture;

            Model.Exam = Model.LocallyEditedExam;
            Model.Event.Tag = Model.Exam;

            MasterController.DB.UpdateExam(Model.Exam);

            int changeCount = 0;
            foreach (Control control in ((EditExamView)GetView()).Controls) {
                if (control is Label) {
                    if (!((Label)control).ForeColor.ToArgb().Equals(Color.Black.ToArgb())) {
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
            List<Result> results = MasterController.DB.GetResultsByExamId(Model.LocallyEditedExam.Examnr);
            if (results.Count == 0) {
                MasterController.DB.DeleteExam(Model.Exam.Examnr);
                MessageBox.Show("Afnamemoment is verwijderd");

                ExamOverviewTeacherController cont = (ExamOverviewTeacherController)MasterController.GetController(typeof(ExamOverviewTeacherController));
                cont.Load();
                MasterController.SetController(cont);
            }
            else {
                MessageBox.Show("Kan niet worden verwijderd, er zijn resultaten gevonden!");
            }
        }

        public override UserControl GetView() {
            return View;
        }

        public void Init() {
            UpdateView();
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
                datePicker.Value = Model.LocallyEditedExam.Starttime;
                timePicker.Value = Model.LocallyEditedExam.Starttime;
            }
            else if (timeOption == DialogOption.END_TIME) {
                datePicker.MinDate = Model.LocallyEditedExam.Starttime;
                datePicker.Value = Model.LocallyEditedExam.Endtime;
                timePicker.Value = Model.LocallyEditedExam.Endtime;
            }

            Button confirmation = new Button() { Text = "OK", Left = 10, Width = 100, Top = 110 };
            confirmation.Click += (sender, e) => {
                DateTime newDate = datePicker.Value.Date + timePicker.Value.TimeOfDay;

                if (timeOption == DialogOption.START_TIME) {
                    if (newDate > Model.LocallyEditedExam.Endtime || newDate < DateTime.Now) {
                        MessageBox.Show("Ongeldige datum");
                    }
                    else {
                        Model.LocallyEditedExam.Starttime = newDate;
                        ((EditExamView)GetView()).lblStarttime.ForeColor = Color.DarkOrange;
                        ((EditExamView)GetView()).lblDuration.ForeColor = Color.DarkOrange;
                        prompt.Close();
                    }
                }
                else if (timeOption == DialogOption.END_TIME) {
                    if (newDate < Model.LocallyEditedExam.Starttime) {
                        MessageBox.Show("Ongeldige datum");
                    }
                    else {
                        Model.LocallyEditedExam.Endtime = newDate;
                        ((EditExamView)GetView()).lblEndtime.ForeColor = Color.DarkOrange;
                        ((EditExamView)GetView()).lblDuration.ForeColor = Color.DarkOrange;
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

        private void UpdateView() {
            double differenceMinutes = (Model.LocallyEditedExam.Endtime - Model.LocallyEditedExam.Starttime).TotalMinutes;

            ((EditExamView)GetView()).lblTitle.Text = Model.LocallyEditedExam.Questionnaire.Name;
            ((EditExamView)GetView()).lblStarttime.Text = "Starttijd: " + Model.LocallyEditedExam.Starttime.ToString();
            ((EditExamView)GetView()).lblEndtime.Text = "Eindtijd: " + Model.LocallyEditedExam.Endtime.ToString();
            ((EditExamView)GetView()).lblDuration.Text = "Looptijd: " + string.Format("{0:n2}", differenceMinutes) + " minuten";
            ((EditExamView)GetView()).lblSubject.Text = "Vak: " + Model.LocallyEditedExam.Questionnaire.Subject.Name;
            ((EditExamView)GetView()).lblExecutedBy.Text = "Wordt afgenomen door: " + Model.LocallyEditedExam.Lecture.Teacher;
            ((EditExamView)GetView()).lblPlannedInBy.Text = "Ingepland door: " + Model.LocallyEditedExam.Questionnaire.Author;
            ((EditExamView)GetView()).lblForClass.Text = "Voor: " + Model.LocallyEditedExam.Lecture.Class.Code;

            List<Result> results = MasterController.DB.GetResultsByExamId(Model.LocallyEditedExam.Examnr);
            if(results.Count == 0) {
                ((EditExamView)GetView()).btnRemove.Enabled = true;
            }
            else {
                ((EditExamView)GetView()).btnRemove.Enabled = false;
            }
        }

        private void ShowListBoxDialog(string title, DialogOption option) {
            Form prompt = new Form();
            prompt.Width = 400;
            prompt.Height = 540;
            prompt.Text = title;

            Label textLabel = new Label() { Left = 10, Top = 20, Text = title };

            ListBox listBox = new ListBox() { Left = 10, Top = 50, Width = 360, Height = 400 };

            if (option == DialogOption.LECTURE) {
                foreach (Lecture lecture in MasterController.DB.GetAllLectures()) {
                    listBox.Items.Add(lecture);
                }
            }
            else if (option == DialogOption.QUESTIONNAIRE) {
                foreach (Questionnaire questionnaire in MasterController.DB.GetAllQuestionnaires()) {
                    listBox.Items.Add(questionnaire);
                }
            }

            Button confirmation = new Button() { Text = "OK", Left = 10, Width = 100, Top = 470 };
            confirmation.Click += (sender, e) => {
                if (option == DialogOption.LECTURE) {
                    Lecture selectedLecture = (Lecture)listBox.SelectedItem;
                    Model.LocallyEditedExam.Lecture = selectedLecture;
                    ((EditExamView)GetView()).lblExecutedBy.ForeColor = Color.DarkOrange;
                    ((EditExamView)GetView()).lblForClass.ForeColor = Color.DarkOrange;
                }
                else if (option == DialogOption.QUESTIONNAIRE) {
                    Questionnaire selectedQuestionnaire = (Questionnaire)listBox.SelectedItem;
                    Model.LocallyEditedExam.Questionnaire = selectedQuestionnaire;
                    ((EditExamView)GetView()).lblTitle.ForeColor = Color.DarkOrange;
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