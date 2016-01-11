using System;
using System.Collections.Generic;

namespace PetjeOp
{
    public abstract class Question : IComparable<Question>
    {
        public int ID { get; set; }
        public int QuestionIndex { get; set; }
        public String Description { get; set; }

        // "Answer" is het goede antwoord op de vraag.           
        public Answer CorrectAnswer { get; set; }

        // ******************************************************************** //
        // Als er een tijdslimiet ingesteld is voor de vraag, dan wordt
        // deze opgeslagen in het veld: "TimeRestriction." Het veld
        // "RemainingTimeRestriction" wordt gebruikt om de nog
        // beschikbare tijd in op te slaan.
        // ******************************************************************** //
        public TimeSpan TimeRestriction { get; set; }
        private TimeSpan RemainingTimeRestriction;

        // Constructor van "Question". Als parameter alleen de beschrijving.
        public Question(String description)
        {
            this.Description = description;
        }

        public int CompareTo(Question q)
        {
            return QuestionIndex.CompareTo(q.QuestionIndex);
        }
    }
}