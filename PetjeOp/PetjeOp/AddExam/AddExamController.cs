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

        public void GetAllData()
        {
            Model.Subjects = MasterController.DB.GetAllSubjects();
            Model.Questionnaires = MasterController.DB.GetAllQuestionnaires();
            Model.Classes = MasterController.DB.GetAllClasses();
        }

        public void FillSubjectsCb()
        {
            View.cbSubjects.Items.Clear();
            foreach (Subject s in Model.Subjects)
            {
                View.cbSubjects.Items.Add(s);
            }
        }

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

        public void CheckLabels()
        {
            bool SubjectValidation= false;
            bool QuestionnaireValidation = false;
            bool ClassValidation = false;
            bool BegintimeValidation = false;
            bool EndtimeValidation = false;

            if (View.cbSubjects.SelectedIndex != -1)
            {
                SubjectValidation = true;
                View.lblSubjectError.Text = "";
            }
            else
            {
                SubjectValidation = false;
                View.lblSubjectError.Text = "Selecteer een onderwerp!";
            }
            if (View.cbClasses.SelectedIndex != -1)
            {
                ClassValidation = true;
                View.lblClassError.Text = "";
            }
            else
            {
                ClassValidation = false;
                View.lblClassError.Text = "Selecteer een klas!";
            }
            if (View.cbQuestionnaires.SelectedIndex != -1)
            {
                QuestionnaireValidation = true;
                View.lblQuestionnaireError.Text = "";
            }
            else
            {
                QuestionnaireValidation = false;
                View.lblQuestionnaireError.Text = "Selecteer een vragenlijst!";
            }

            if (View.dtpStarttimeDate.Value.Year > DateTime.Now.Year)
            {
                BegintimeValidation = true;
                View.lblStarttimeError.Text = "";
            }else if (View.dtpStarttimeDate.Value.Year == DateTime.Now.Year &&
                View.dtpStarttimeDate.Value.Month > DateTime.Now.Month)
            {
                BegintimeValidation = true;
                View.lblStarttimeError.Text = "";
            }
            else if (View.dtpStarttimeDate.Value.Year == DateTime.Now.Year &&
               View.dtpStarttimeDate.Value.Month == DateTime.Now.Month &&
               View.dtpStarttimeDate.Value.Day > DateTime.Now.Day)
            {
                BegintimeValidation = true;
                View.lblStarttimeError.Text = "";
            }
            else if (View.dtpStarttimeDate.Value.Year == DateTime.Now.Year &&
                     View.dtpStarttimeDate.Value.Month == DateTime.Now.Month &&
                     View.dtpStarttimeDate.Value.Day == DateTime.Now.Day)
            {
                if (View.dtpStarttimeTime.Value.TimeOfDay > DateTime.Now.TimeOfDay)
                {
                    BegintimeValidation = true;
                    View.lblStarttimeError.Text = "";
                }
                else
                {
                    BegintimeValidation = false;
                    View.lblStarttimeError.Text = "Selecteer een goede tijd!";
                }
            }
            else
            {
                BegintimeValidation = false;
                View.lblStarttimeError.Text = "Selecteer een goede tijd!";
            }

            if (View.dtpEndtimeTime.Value.TimeOfDay > View.dtpStarttimeTime.Value.TimeOfDay)
            {
                if (View.dtpStarttimeTime.Value.AddHours(1).TimeOfDay > View.dtpEndtimeTime.Value.TimeOfDay)
                {
                    EndtimeValidation = false;
                    View.lblEndtimeError.Text = "Een les duurt minimaal een uur!";
                }
                else
                {
                    EndtimeValidation = true;
                    View.lblEndtimeError.Text = "";
                }
            }
            else
            {
                EndtimeValidation = false;
                View.lblEndtimeError.Text = "Selecteer een goede tijd!";
            }

            if (SubjectValidation && QuestionnaireValidation && ClassValidation && BegintimeValidation &&
                EndtimeValidation)
            {
                View.btnSaveExam.Enabled = true;
            }
            else
            {
                View.btnSaveExam.Enabled = false;
            }
        }

        public void SaveExam()
        {
            Lecture selectedLecture = new Lecture(0, (Teacher)MasterController.User, (Class)View.cbClasses.SelectedItem, (Subject)View.cbSubjects.SelectedItem);

            Lecture dbLecture = MasterController.DB.CheckLecture(selectedLecture);

            if (dbLecture != null)
            {
                selectedLecture = dbLecture;
            }
            else
            {
                tblLecture newLecture = MasterController.DB.AddLecture(selectedLecture);
                selectedLecture = newLecture;
                //Lecture newActualLecture = new Lecture(newLecture.id, newLecture.tblTeacher, newLecture.@class, new);
            }
            Questionnaire selectedQuestionnaire = (Questionnaire)View.cbQuestionnaires.SelectedItem;
            DateTime selectedStartTime = new DateTime(View.dtpStarttimeDate.Value.Year, View.dtpStarttimeDate.Value.Month, View.dtpStarttimeDate.Value.Day, View.dtpStarttimeTime.Value.Hour, View.dtpStarttimeTime.Value.Minute, View.dtpStarttimeTime.Value.Second);
            DateTime selectedEndTime = new DateTime(View.dtpStarttimeDate.Value.Year, View.dtpStarttimeDate.Value.Month, View.dtpStarttimeDate.Value.Day, View.dtpEndtimeTime.Value.Hour, View.dtpEndtimeTime.Value.Minute, View.dtpEndtimeTime.Value.Second);
            Exam currentExam = new Exam(0, selectedQuestionnaire,selectedStartTime, selectedEndTime, selectedLecture);
            MasterController.DB.AddExam(currentExam);
        }
    }
}