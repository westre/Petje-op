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
        public DateTime starttime;
        public DateTime endtime;
        public string Groupnr { get; set; }
        public List<Result> results;

        public Exam(int ex, Questionnaire qu, DateTime st, DateTime et, string gnr)
        {
            Examnr = ex;
            questionnaire = qu;
            starttime = st;
            endtime = et;
            Groupnr = gnr;
            results = new List<Result>();

        }

        public Exam()
        {

        }
        public override string ToString()
        {
            return "Afnamemoment " + Examnr + " : " + questionnaire + " - " + starttime + " - " + endtime + " " + Groupnr;
        }
    }
    
}
