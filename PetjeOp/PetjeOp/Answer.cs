using System;

namespace PetjeOp
{
    public class Answer
    {
        public int ID { get; set; }
        public String Description { get; set; }
        public Answer(String Description)
        {
            this.Description = Description;
        }
    }
}