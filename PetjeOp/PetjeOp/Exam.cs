using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp {
    public class Exam
    {
        public int Examnr { get; set; }
        public Questionnaire questionnaire;
        public int qstnn;
        public DateTime? starttime;
        public DateTime? endtime;
        public int Groupnr { get; set; }
        public List<Result> results;
       

        public int? CurrenQuestion { get; set; }

        public Exam(int ex, Questionnaire qu, DateTime? st, DateTime? et, int gnr)
        {
            Examnr = ex;
            questionnaire = qu;
            starttime = st;
            endtime = et;
            Groupnr = gnr;
            results = new List<Result>();
           

        }

        public Exam(int ex, int qu)
        {
            Examnr = ex;
            qstnn = qu;

        }

        public Exam(int id, Questionnaire questionnaire)
        {
            Examnr = id;
            this.questionnaire = questionnaire;
        }

        public override string ToString()
        {
            return "VRAGENLIJST : " + questionnaire.Name + ", VAK : "  + questionnaire.Subject + ", BEGIN : " + starttime + ", EIND : " + endtime;
        }
    }

}