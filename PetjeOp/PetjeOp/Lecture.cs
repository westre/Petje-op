using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public class Lecture
    {
        public int ID { get; set; }
        public string teacher;
        public string cs;
        public int subject;

        public Lecture(int I, string t, string c, int s)
        {
            ID = I;
            teacher = t;
            cs = c;
            subject = s;
        }

    }
}
