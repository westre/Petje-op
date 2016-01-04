using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public class Lecture
    {
        public int ID { get; set; }
        private Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public Subject Subject { get; set; }

        private string TeacherString { get; set; }
        public string ClassString { get; set; }
        public int SubjectInt { get; set; }

        public Lecture(int id, Teacher teacher, Class Class, Subject subject)
        {
            ID = id;
            Teacher = teacher;
            this.Class = Class;
            Subject = subject;
        }

        public Lecture(string teacher, int id, string cs, int subject)
        {
            TeacherString = teacher;
            ID = id;
            ClassString = cs;
            SubjectInt = subject;
        }
    }
}
