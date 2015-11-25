using System;

namespace PetjeOp
{
    public class Answer
    {
        public readonly int id;
        public String Description { get; set; }
        public Answer(String Description, int id = 0) // Nog veranderen!, default verwijderen voor DB
        {
            this.id = id;
            this.Description = Description;
        }
    }
}