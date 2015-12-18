using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public Person()
        {
            
        }

        public Person(string firstName, string surName)
        {
            this.FirstName = firstName;
            this.SurName = surName;
        }
    }
}
