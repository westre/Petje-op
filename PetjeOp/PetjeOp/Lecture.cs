using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public class Lecture
    {
        int ID { get; set; }
        string teacher;
        string cs;
        int subject;

        public Lecture(int I, string t, string c, int s)
        {
            ID = I;
            teacher = t;
            cs = c;
            subject = s;
        }

    }
}
