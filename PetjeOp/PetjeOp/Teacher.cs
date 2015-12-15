using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public class Teacher : Person
    {
        public String TeacherNr { get; set; }

        public Teacher() { }

        public Teacher(string teacherNr, string firstName, string surName) : base(firstName, surName)
        {
            this.TeacherNr = teacherNr;
        }

        public override string ToString()
        {
            return FirstName + " " + SurName;
        }
    }
}
