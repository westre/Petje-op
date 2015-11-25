using System;

namespace PetjeOp
{
    public class Answer
    {
        public readonly int id;
        public String Description { get; set; }
        public Answer(int id, String Description)
        {
            this.id = id;
            this.Description = Description;
        }
    }
}