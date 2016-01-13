using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        //Krijg alle data uit de database
        public void GetAllData()
        {
            Model.Subjects = MasterController.DB.GetSubjects();
            Model.Classes = MasterController.DB.GetAllClasses();
        }

        //Vull de vakken combobox met data.
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

        public void QuestionnaireEdit()
        {
            ShowListBoxDialog("Questionnaire", DialogOption.QUESTIONNAIRE);
        }

        //Wanneer de klas veranderd is, update de gegevens.
        internal void ClassChanged() {
            if(((EditExamView)GetView()).cbClass.SelectedItem != null) {
                Model.LocallyEditedExam.Lecture.Class = (Class)((EditExamView)GetView()).cbClass.SelectedItem;
                ((EditExamView)GetView()).lblForClass.Text = "Klas: " + ((EditExamView)GetView()).cbClass.SelectedItem;
            }
            
        }

        //Wanneer het vak veranderd is, update de gegevens.
        internal void SubjectChanged() {
            if(((EditExamView)GetView()).cbSubject.SelectedItem != null) {
                Model.LocallyEditedExam.Lecture.Subject = (Subject)((EditExamView)GetView()).cbSubject.SelectedItem;
                ((EditExamView)GetView()).lblSubject.Text = "Vak: " + ((EditExamView)GetView()).cbSubject.SelectedItem;
            }
        }

        //Wanneer er op edit is geklikt, sla al de data op.
        public void EditClicked()
        {
            //Zet de nieuwe klas in de model.
            Class newClass = (Class)View.cbClass.SelectedItem;
            if (View.cbClass.SelectedItem == null) {
                newClass = Model.LocallyEditedExam.Lecture.Class;
            }
            
            //Zet het nieuwe vak in de model.
            Subject newSubject = (Subject)View.cbSubject.SelectedItem;
            if (View.cbSubject.SelectedItem == null) {
                newSubject = Model.LocallyEditedExam.Lecture.Subject;
            }

            //Maak indien nodig een nieuwe lecture aan als gegeven voor de nieuwe les.
            Lecture newLecture = new Lecture(0, (Teacher)MasterController.User, newClass, newSubject);
            Lecture dbLecture = MasterController.DB.CheckLecture(newLecture);
            //Bestaat de lecture die we proberen tee maken?
            if (dbLecture != null)
            {
                //De lecture bestaat al, gebruik deze.
                newLecture = dbLecture;
            }
            else
            {
                //De lecture bestaat niet, maak een nieuwe aan.
                tblLecture tblLecture = MasterController.DB.AddLecture(newLecture);
                Teacher newTeacher = new Teacher(tblLecture.tblTeacher.nr, tblLecture.tblTeacher.firstname, tblLecture.tblTeacher.surname);
                Class newActualClass = new Class(tblLecture.@class);
                Subject newActualSubject = new Subject(tblLecture.tblSubject.id, tblLecture.tblSubject.name);
                Lecture newActualLecture = new Lecture(tblLecture.id, newTeacher, newActualClass, newActualSubject);
                newLecture = newActualLecture;
            }
            //Maak de overige benodigde gegevens voor Exam.
            Model.LocallyEditedExam.Lecture = newLecture;
            Model.Exam = Model.LocallyEditedExam;
            Model.Event.Tag = Model.Exam;
            //Voeg de nieuwe exam toe aan de database.
            MasterController.DB.UpdateExam(Model.Exam);

            //Verander de kleur van elke label in zwart en kijk hoeveel dingen er veranderd zijn.
            int changeCount = 0;
            foreach (Control control in ((EditExamView)GetView()).Controls) {
                if (control is Label) {
                    if (!((Label)control).ForeColor.ToArgb().Equals(Color.Black.ToArgb())) {
                        changeCount++;
                    }
                    ((Label)control).ForeColor = Color.Black;
                }
            }

            //Maak een messagebox aan met alle dingen die gewijzigd zijn en ook de hoeveelheid hierbij.
            string changes = "wijziging";
            if (changeCount > 1 || changeCount == 0)
                changes += "en";
            MessageBox.Show("Wijziging toegepast");
        }

        //Wanneer er op de verwijderknop is geklikt.
        public void RemoveClicked() {
            //Haal alle resultaten uit de database.
            List<Result> results = MasterController.DB.GetResultsByExamId(Model.LocallyEditedExam.Examnr);
            if (results.Count == 0)
            {
                //Wanneer er geen resultaten aan een exam zijn gekoppeld, verwijder deze exam.
                MasterController.DB.DeleteExam(Model.Exam.Examnr);
                //Laat de gebruiker weten dat de exam is verwijderd.
                MessageBox.Show("Afnamemoment is verwijderd");

                //Verander de controller naar de ExamOverviewController aangezien deze exam verwijderd is.
                ExamOverviewTeacherController cont = (ExamOverviewTeacherController)MasterController.GetController(typeof(ExamOverviewTeacherController));
                cont.Load();
                MasterController.SetController(cont);
            }
            else {
                //Wanneer er wel resultaten aan een exam zijn gekoppeld, laat de gebruiker weten dat deze exam niet verwijderd kan worden.
                MessageBox.Show("Kan niet worden verwijderd, er zijn resultaten gevonden!");
            }
        }

        public override UserControl GetView() {
            return View;
        }

        public void Init() {
            UpdateView();
        }
        
        //Maak een eigen DateTimeDialog
        private void ShowDateTimeDialog(string title, DialogOption timeOption) {
            //Initialisatie en design voor de dialog
            Form prompt = new Form();
            prompt.Width = 250;
            prompt.Height = 200;
            prompt.Text = title;
            Label textLabel = new Label() { Left = 10, Top = 20, Text = title };
            DateTimePicker datePicker = new DateTimePicker() { Left = 10, Top = 50 };
            DateTimePicker timePicker = new DateTimePicker() { Left = 10, Top = 80 };
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;

            //Wanneer starttime is geselecteerd, verander de schermgegevens naar de modelgegevens
            if (timeOption == DialogOption.START_TIME) {
                datePicker.MinDate = DateTime.Now;
                datePicker.Value = Model.LocallyEditedExam.Starttime;
                timePicker.Value = Model.LocallyEditedExam.Starttime;
            }
            //Wanneer endtime is geselecteerd, verander de schermgegevens naar de modelgegevens
            else if (timeOption == DialogOption.END_TIME) {
                datePicker.MinDate = Model.LocallyEditedExam.Starttime;
                datePicker.Value = Model.LocallyEditedExam.Endtime;
                timePicker.Value = Model.LocallyEditedExam.Endtime;
            }

            //Wanneer er op OK is geklikt
            Button confirmation = new Button() { Text = "OK", Left = 10, Width = 100, Top = 110 };
            confirmation.Click += (sender, e) => {
                DateTime newDate = datePicker.Value.Date + timePicker.Value.TimeOfDay;
                //Check of de einddatum klopt
                if (timeOption == DialogOption.START_TIME) {
                    if (newDate > Model.LocallyEditedExam.Endtime || newDate < DateTime.Now) {
                        MessageBox.Show("Ongeldige datum");
                    }
                    else {
                        Model.LocallyEditedExam.Starttime = newDate;
                        prompt.Close();
                    }
                }
                //Check of de startdatum klopt
                else if (timeOption == DialogOption.END_TIME) {
                    if (newDate < Model.LocallyEditedExam.Starttime) {
                        MessageBox.Show("Ongeldige datum");
                    }
                    else {
                        Model.LocallyEditedExam.Endtime = newDate;
                        prompt.Close();
                    }
                }
                //Werk de gegevens bij
                UpdateView();
            };

            //Voeg de controls toe aan de prompt en laat hierna de dialog zien.
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(datePicker);
            prompt.Controls.Add(timePicker);
            prompt.ShowDialog();
        }

        //Zorg dat de view geupdate is naar de goede gegevens.
        private void UpdateView() {
            double differenceMinutes = (Model.LocallyEditedExam.Endtime - Model.LocallyEditedExam.Starttime).TotalMinutes;
            //Zet alle labels naar data in de model.
            ((EditExamView)GetView()).lblTitle.Text = Model.LocallyEditedExam.Questionnaire.Name;
            ((EditExamView)GetView()).lblStarttime.Text = "Starttijd: " + Model.LocallyEditedExam.Starttime;
            ((EditExamView)GetView()).lblEndtime.Text = "Eindtijd: " + Model.LocallyEditedExam.Endtime;
            ((EditExamView)GetView()).lblDuration.Text = "Looptijd: " + string.Format("{0:n2}", differenceMinutes) + " minuten";
            ((EditExamView)GetView()).lblSubject.Text = "Vak: " + Model.LocallyEditedExam.Lecture.Subject;
            ((EditExamView)GetView()).lblExecutedBy.Text = "Wordt afgenomen door: " + Model.LocallyEditedExam.Lecture.Teacher;
            ((EditExamView)GetView()).lblPlannedInBy.Text = "Ingepland door: " + Model.LocallyEditedExam.Questionnaire.Author;
            ((EditExamView)GetView()).lblForClass.Text = "Voor: " + Model.LocallyEditedExam.Lecture.Class.Code;
            ((EditExamView)GetView()).cbClass.Text = Model.LocallyEditedExam.Lecture.Class.Code;

            //Selecteer de item in de klascombobox die in de model geselecteerd is. (locallyeditedexam)
            for (int index = 0; index < ((EditExamView)GetView()).cbClass.Items.Count; index++) {
                Class tempClass = (Class)((EditExamView)GetView()).cbClass.Items[index];
                if (tempClass.Code == Model.LocallyEditedExam.Lecture.Class.Code) {
                    ((EditExamView)GetView()).cbClass.SelectedIndex = index;
                }
            }

            //Selecteer de item in de vakcombobox die in de model geselecteerd is. (locallyeditedexam)
            ((EditExamView)GetView()).cbSubject.Text = Model.LocallyEditedExam.Lecture.Subject.Name;
            for(int index = 0; index < ((EditExamView)GetView()).cbSubject.Items.Count; index++) {
                Subject tempSubject = (Subject)((EditExamView)GetView()).cbSubject.Items[index];
                if(tempSubject.Id == Model.LocallyEditedExam.Lecture.Subject.Id) {
                    ((EditExamView)GetView()).cbSubject.SelectedIndex = index;
                }
            }
            
            //Krijg alle resultaten bij de examID
            List <Result> results = MasterController.DB.GetResultsByExamId(Model.LocallyEditedExam.Examnr);
            //Als er resultaten zijn, enable de remove knop. Zo niet, disable de remove knop.
            if(results.Count == 0) {
                ((EditExamView)GetView()).btnRemove.Enabled = true;
            }
            else {
                ((EditExamView)GetView()).btnRemove.Enabled = false;
            }
        }

        //Maak een eigen ShowListBoxDialog
        private void ShowListBoxDialog(string title, DialogOption option) {
            //Initialisatie & design voor de dialog.
            Form prompt = new Form();
            prompt.Width = 400;
            prompt.Height = 540;
            prompt.Text = title;
            Label textLabel = new Label() { Left = 10, Top = 20, Text = title };
            ListBox listBox = new ListBox() { Left = 10, Top = 50, Width = 360, Height = 400 };
            Button confirmation = new Button() { Text = "OK", Left = 10, Width = 100, Top = 470 };

            if (option == DialogOption.LECTURE)
            {
                //Haal de lectures uit de database en voeg ze toe aan de listbox wanneer er lecture geselecteerd is.
                foreach (Lecture lecture in MasterController.DB.GetAllLectures()) {
                    listBox.Items.Add(lecture);
                }
            }
            else if (option == DialogOption.QUESTIONNAIRE)
            {
                //Haal de questionnaires uit de database en voeg ze toe aan de listbox wanneer er questionnaire geselecteerd is.
                foreach (Questionnaire questionnaire in MasterController.DB.GetAllQuestionnaires()) {
                    listBox.Items.Add(questionnaire);
                }
            }

            //Buttonclick event.
            confirmation.Click += (sender, e) => {
                if (option == DialogOption.LECTURE) {
                    //Wanneer lecture is geselecteerd, zet de model lecture naar de geselecteerde lecture.
                    Lecture selectedLecture = (Lecture)listBox.SelectedItem;
                    Model.LocallyEditedExam.Lecture = selectedLecture;
                }
                else if (option == DialogOption.QUESTIONNAIRE)
                {
                    //Wanneer questionnaire is geselecteerd, zet de model questionnaire naar de geselecteerde questionnaire.
                    Questionnaire selectedQuestionnaire = (Questionnaire)listBox.SelectedItem;
                    Model.LocallyEditedExam.Questionnaire = selectedQuestionnaire;
                }

                prompt.Close();
                UpdateView();
            };

            //Voeg de controls toe aan de prompt en laat de dialog zien.
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(listBox);
            prompt.ShowDialog();
        }
    }
}