using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public class Lecture
    {
        int ID { get; set; }
        private Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public Subject Subject { get; set; }

        public Lecture(int id, Teacher teacher, Class Class, Subject subject)
        {
            ID = id;
            Teacher = teacher;
            this.Class = Class;
            Subject = subject;
        }
    }
}
