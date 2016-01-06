using Calendar.NET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetjeOp {
    public class ExamOverviewTeacherController : Controller {
        public ExamOverviewTeacherView View { get; set; }
        public ExamOverviewTeacherModel Model { get; set; }

        public ExamOverviewTeacherController(MasterController masterController) : base(masterController) {
            Model = new ExamOverviewTeacherModel();
            View = new ExamOverviewTeacherView(this);
        }

        public override UserControl GetView() {
            return View;
        }

        public void Load() {
            List<Exam> exams = MasterController.DB.GetExamsByTeacher(((Teacher)MasterController.User).TeacherNr);

            foreach (Exam exam in exams) {
                double difference = (exam.Endtime - exam.Starttime).TotalHours;
                double differenceMinutes = (exam.Endtime - exam.Starttime).TotalMinutes;

                CustomEvent customEvent = new CustomEvent {
                    Date = exam.Starttime,
                    EventText = exam.Questionnaire.Name,
                    EventFont = new Font("Verdana", 8, FontStyle.Regular),
                    Enabled = true,
                    EventColor = Color.FromArgb(0, 65, 150),
                    EventTextColor = Color.White,
                    EventLengthInHours = (float)difference,
                    CustomToolTipText =
                    "Vak: " + exam.Questionnaire.Subject.Name
                    + "\n\nStart: " + exam.Starttime.ToString() 
                    + "\nEind: " + exam.Endtime.ToString() 
                    + "\nDuur: " + differenceMinutes + " minuten"
                    + "\n\nGemaakt door: " + exam.Questionnaire.Author
                    + "\nWordt afgenomen door: " + exam.Lecture.Teacher
                };

                View.clnExams.AddEvent(customEvent);
            }
        }
    }
}