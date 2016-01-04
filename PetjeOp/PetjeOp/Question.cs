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

        // De lijst bevat de media, die bij de vraag hoort.
        private List<Media> Media;

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

        // Zet een "TimeRestriction" voor de "Question."              
        public void TimeRestrictionSet(TimeSpan TimeRestricton)
        {
            this.TimeRestriction = TimeRestricton;
            this.RemainingTimeRestriction = TimeRestricton;
        }

        // Verwijdert de "TimeRestriction" van de "Question."          
        public void TimeRestrictionClear()
        {
            this.TimeRestriction = new TimeSpan();
            this.RemainingTimeRestriction = new TimeSpan();
        }

        // Voegt een "Media" object toe aan de "Question."            
        public void MediaAdd(String Name, String Url, Media.MediaType Type)
        {
            Media.Add(new Media(Name, Url, Type));
        }

        // Verwijdert een "Media" item van de "Question" lijst.   
        public void MediaRemove(int Media)
        {
            this.Media.RemoveAt(Media);
        }

        public void MediaPrintList()
        {
            foreach (Media Media in this.Media)
            {
                System.Console.WriteLine(Media.Name + ", " + Media.Url + ", " + Media.Type);
            }
        }

        public int CompareTo(Question q)
        {
            return QuestionIndex.CompareTo(q.QuestionIndex);
        }
    }
}