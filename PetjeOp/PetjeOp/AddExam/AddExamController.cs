using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class AddExamController : Controller
    {
        public AddExamView View { get; set; }
        public AddExamModel Model { get; set; }


        public AddExamController(MasterController masterController) : base(masterController)
        {
            Model = new AddExamModel();
            View = new AddExamView(this);
        }

        public override UserControl GetView()
        {
            return View;
        }

        //Alle data ophalen uit de database en stop ze in de model
        public void GetAllData()
        {
            Model.Subjects = MasterController.DB.GetSubjects();
            Model.Questionnaires = MasterController.DB.GetAllQuestionnaires();
            Model.Classes = MasterController.DB.GetAllClasses();
        }

        //Vul de subjects combobox met data uit de model
        public void FillSubjectsCb()
        {
            View.cbSubjects.Items.Clear();
            foreach (Subject s in Model.Subjects)
            {
                View.cbSubjects.Items.Add(s);
            }
        }

        //Vul de questionnaires & class combobox met data uit de model
        public void FillQuestionnaireAndClassCb()
        {

            View.cbClasses.Items.Clear();
            View.cbQuestionnaires.Items.Clear();

            foreach (Class c in Model.Classes)
            {
                View.cbClasses.Items.Add(c);
            }
            foreach (Questionnaire q in Model.Questionnaires)
            {
                if (q.Subject.Id == ((Subject)View.cbSubjects.SelectedItem).Id)
                {
                    View.cbQuestionnaires.Items.Add(q);
                }
            }
        }

        //Check if comboboxes enabled kunnen zijn, als er iets geselecteerd is: enabled = true.
        public bool CheckIfCbEnabled()
        {
            if (View.cbSubjects.SelectedIndex == -1)
            {
                View.cbQuestionnaires.Enabled = false;
                View.cbClasses.Enabled = false;
                return false;
            }
            else
            {
                View.cbQuestionnaires.Enabled = true;
                View.cbClasses.Enabled = true;
                return true;
            }
        }

        //Check errorlabels/buttons
        public void CheckLabels()
        {
            bool subjectValidation= false;
            bool questionnaireValidation = false;
            bool classValidation = false;
            bool begintimeValidation = false;
            bool endtimeValidation = false;

            //Controleer of er een subject geselecteerd is.
            if (View.cbSubjects.SelectedIndex != -1)
            {
                subjectValidation = true;
                View.lblSubjectError.Text = "";
            }
            else
            {
                subjectValidation = false;
                View.lblSubjectError.Text = "Selecteer een onderwerp!";
            }

            //Controleer of er een klas geselecteerd is.
            if (View.cbClasses.SelectedIndex != -1)
            {
                classValidation = true;
                View.lblClassError.Text = "";
            }
            else
            {
                classValidation = false;
                View.lblClassError.Text = "Selecteer een klas!";
            }

            //Controleer of er een vragenlijst geselecteerd is.
            if (View.cbQuestionnaires.SelectedIndex != -1)
            {
                questionnaireValidation = true;
                View.lblQuestionnaireError.Text = "";
            }
            else
            {
                questionnaireValidation = false;
                View.lblQuestionnaireError.Text = "Selecteer een vragenlijst!";
            }

            //Check of de waardes van de datetimepicker correct zijn, stap voor stap zodat je niets terug in de tijd kan selecteren.
            //Dit om bugs te voorkomen die je zou kunnen krijgen als je wacht na je een tijd hebt geselecteerd, het moet altijd later dan "nu" zijn.
            if (View.dtpStarttimeDate.Value.Year > DateTime.Now.Year)
            {
                begintimeValidation = true;
                View.lblStarttimeError.Text = "";
            }else if (View.dtpStarttimeDate.Value.Year == DateTime.Now.Year &&
                View.dtpStarttimeDate.Value.Month > DateTime.Now.Month)
            {
                begintimeValidation = true;
                View.lblStarttimeError.Text = "";
            }
            else if (View.dtpStarttimeDate.Value.Year == DateTime.Now.Year &&
               View.dtpStarttimeDate.Value.Month == DateTime.Now.Month &&
               View.dtpStarttimeDate.Value.Day > DateTime.Now.Day)
            {
                begintimeValidation = true;
                View.lblStarttimeError.Text = "";
            }
            else if (View.dtpStarttimeDate.Value.Year == DateTime.Now.Year &&
                     View.dtpStarttimeDate.Value.Month == DateTime.Now.Month &&
                     View.dtpStarttimeDate.Value.Day == DateTime.Now.Day)
            {
                //Check of de tijd van nu meer is dan de tijd van 'nu'
                if (View.dtpStarttimeTime.Value.TimeOfDay >= DateTime.Now.TimeOfDay)
                {
                    begintimeValidation = true;
                    View.lblStarttimeError.Text = "";
                }
                else
                {
                    begintimeValidation = false;
                    View.lblStarttimeError.Text = "Selecteer een goede tijd!";
                }
            }
            else
            {
                begintimeValidation = false;
                View.lblStarttimeError.Text = "Selecteer een goede tijd!";
            }

            //Kijk of de eindtijd later is dan de starttijd.
            if (View.dtpEndtimeTime.Value.TimeOfDay > View.dtpStarttimeTime.Value.TimeOfDay)
            {
                //Check of de les minimaal een uur duurt.
                if (View.dtpStarttimeTime.Value.AddHours(1).TimeOfDay >= View.dtpEndtimeTime.Value.TimeOfDay)
                {
                    endtimeValidation = false;
                    View.lblEndtimeError.Text = "Een les duurt langer dan een uur!";
                }
                else
                {
                    endtimeValidation = true;
                    View.lblEndtimeError.Text = "";
                }
            }
            else
            {
                endtimeValidation = false;
                View.lblEndtimeError.Text = "Selecteer een goede tijd!";
            }

            //Kijk of alle validaties kloppen.
            //Zo ja: Opslagknop beschikbaar.
            //Zo nee: Opslagknop niet beschikbaar.
            if (subjectValidation && questionnaireValidation && classValidation && begintimeValidation &&
                endtimeValidation)
            {
                View.btnSaveExam.Enabled = true;
            }
            else
            {
                View.btnSaveExam.Enabled = false;
            }
        }

        //Opslaan van een exam.
        public void SaveExam()
        {
            //Maak een nieuwe lecture aan met de gegevens uit de form.
            Lecture selectedLecture = new Lecture(0, (Teacher)MasterController.User, (Class)View.cbClasses.SelectedItem, (Subject)View.cbSubjects.SelectedItem);
            //Kijk of de lecture al in de database staat.
            Lecture dbLecture = MasterController.DB.CheckLecture(selectedLecture);
            //Als de lecture al in de database staat, selecteer deze. Zo niet: Maak een nieuwe lecture aan.
            if (dbLecture != null)
            {
                selectedLecture = dbLecture;
            }
            else
            {
                tblLecture newLecture = MasterController.DB.AddLecture(selectedLecture);
                Teacher newTeacher = new Teacher(newLecture.tblTeacher.nr, newLecture.tblTeacher.firstname, newLecture.tblTeacher.surname);
                Class newClass = new Class(newLecture.@class);
                Subject newSubject = new Subject(newLecture.tblSubject.id, newLecture.tblSubject.name);
                Lecture newActualLecture = new Lecture(newLecture.id, newTeacher, newClass, newSubject);
                selectedLecture = newActualLecture;
            }
            //Maak gegevens aan om een nieuwe exam te maken. (lecture was hier een deel van)
            Questionnaire selectedQuestionnaire = (Questionnaire)View.cbQuestionnaires.SelectedItem;
            DateTime selectedStartTime = new DateTime(View.dtpStarttimeDate.Value.Year, View.dtpStarttimeDate.Value.Month, View.dtpStarttimeDate.Value.Day, View.dtpStarttimeTime.Value.Hour, View.dtpStarttimeTime.Value.Minute, View.dtpStarttimeTime.Value.Second);
            DateTime selectedEndTime = new DateTime(View.dtpStarttimeDate.Value.Year, View.dtpStarttimeDate.Value.Month, View.dtpStarttimeDate.Value.Day, View.dtpEndtimeTime.Value.Hour, View.dtpEndtimeTime.Value.Minute, View.dtpEndtimeTime.Value.Second);
            //Maak de nieuwe exam aan met alle hiervoor gemaakte gegevens.
            Exam currentExam = new Exam(0, selectedQuestionnaire,selectedStartTime, selectedEndTime, selectedLecture);
            //Voeg de exam toe aan de database.
            MasterController.DB.AddExam(currentExam);
            //Laat een dialoogvenster zien dat de gebruiker er op wijst dat zijn data succesvol is toegevoegd.
            MessageBox.Show("De data is succesvol toegevoegd!");
            ClearControls();
            
        }

        //Clear alle controls, zet alle çomboboxes op de standaardwaarde en zet alle datetimepickers op de huidige tijd.
        public void ClearControls()
        {
            View.cbSubjects.SelectedIndex = -1;
            View.cbClasses.SelectedIndex = -1;
            View.cbQuestionnaires.SelectedIndex = -1;
            View.dtpEndtimeTime.Value = DateTime.Now;
            View.dtpEndtimeTime.MinDate = DateTime.Now;
            View.dtpStarttimeTime.Value = DateTime.Now;
            View.dtpStarttimeTime.MinDate = DateTime.Now;
            View.dtpStarttimeDate.Value = DateTime.Now;
            View.dtpStarttimeDate.MinDate = DateTime.Now;
        }
    }
}