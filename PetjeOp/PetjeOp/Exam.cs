using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public class Exam
    {
        public int Examnr { get; set; }
        public Questionnaire questionnaire;
        public int qstnn;
        public DateTime starttime;
        public DateTime endtime;
        public string Groupnr { get; set; }
        public List<Result> results;

        public Exam(int ex, int qu, DateTime st, DateTime et, string gnr)
        {
            Examnr = ex;
            qstnn = qu;
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
            return "Examennummer : " + Examnr + ", vragenlijstnummer: " + questionnaire;
        }
    }
    
}
