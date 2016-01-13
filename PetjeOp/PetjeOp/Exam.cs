using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp {
    public class Exam
    {
        public int Examnr { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public Lecture Lecture { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public int LectureInt { get; set; }
        public Class Class { get; set; }

        public int? CurrentQuestion { get; set; }

        public Exam(int id, Questionnaire questionnaire)
        {
            Examnr = id;
            Questionnaire = questionnaire;
        }

        public Exam(int id, Questionnaire questionnaire, DateTime starttime, DateTime endtime, Lecture lecture)
        {
            Examnr = id;
            Questionnaire = questionnaire;
            Starttime = starttime;
            Endtime = endtime;
            Lecture = lecture;
        }

        public Exam(int id, Questionnaire questionnaire, DateTime starttime, DateTime endtime, int li)
        {
            Examnr = id;
            Questionnaire = questionnaire;
            Starttime = starttime;
            Endtime = endtime;
            LectureInt = li;
        }
    }

}