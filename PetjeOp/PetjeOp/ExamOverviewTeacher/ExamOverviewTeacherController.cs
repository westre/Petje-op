﻿using Calendar.NET;
using PetjeOp.ExamOverviewTeacher.ExamOverviewTeacherDetail;
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
            View.clnExams.CalendarItemClick += ClnExams_CalendarItemClick;
        }

        //Wanneer er op een calendar item is geklikt, open een dialog met de gegevens van deze exam.
        private void ClnExams_CalendarItemClick(CalendarEvent calendarEvent, Point point) {
            if(calendarEvent.Event is CustomEvent) {
                ExamOverviewTeacherDetailDialog dialog = new ExamOverviewTeacherDetailDialog(this, (CustomEvent)calendarEvent.Event);
                dialog.Show();
            }
        }

        public override UserControl GetView() {
            return View;
        }

        //Laad de calendar view
        public void Load() {
            //Eerst leegmaken
            View.clnExams.ClearCalendar();

            //Exams ophalen
            List<Exam> exams = MasterController.DB.GetExamsByTeacher(((Teacher)MasterController.User).TeacherNr);

            foreach (Exam exam in exams) {
                double difference = (exam.Endtime - exam.Starttime).TotalHours;
                double differenceMinutes = (exam.Endtime - exam.Starttime).TotalMinutes;

                //Toevoegen als CustomEvent
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
                    + "\nKlas: " + exam.Lecture.Class
                    + "\n\nStart: " + exam.Starttime
                    + "\nEind: " + exam.Endtime
                    + "\nDuur: " + differenceMinutes + " minuten"
                    + "\n\nGemaakt door: " + exam.Questionnaire.Author
                    + "\nAfname door: " + exam.Lecture.Teacher,
                    Tag = exam
                };

                //Voeg toe aan kalender
                View.clnExams.AddEvent(customEvent);
            }
        }

        //Ga naar AddExamController
        public void GoToAddExamController()
        {
            AddExamController aec = (AddExamController)MasterController.GetController(typeof(AddExamController));
            MasterController.SetController(aec);
        }
    }
}