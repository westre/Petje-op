using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp
{
    public abstract class Question
    {
        public String ID { get; set; }
        public String Description { get; set; }

        // "Answer" is het goede antwoord op de vraag.           
        public Answer Answer { get; set; }

        // De lijst bevat de media, die bij de vraag hoord.
        private List<Media> Media;

        // ******************************************************************** //
        // Als er een tijdslimiet ingesteld is voor de vraag, dan wordt
        // deze opgeslagen in het veld: "TimeRestriction." Het veld
        // "RemainingTimeRestriction" wordt gebruikt om de nog
        // beschikbare tijd in op te slaan.
        // ******************************************************************** //
        private DateTime TimeRestriction;
        private DateTime RemainingTimeRestriction;

        // Constructor van "Question". Als parameter alleen de beschrijving.
        public Question(String description)
        {
            this.Description = description;
        }

        // Zet een "TimeRestriction" voor de "Question."              
        public void TimeRestrictionSet(DateTime TimeRestricton)
        {
            this.TimeRestriction = TimeRestricton;
            this.RemainingTimeRestriction = TimeRestricton;
        }

        // Verwijdert de "TimeRestriction" van de "Question."          
        public void TimeRestrictionClear()
        {
            this.TimeRestriction = new DateTime();
            this.RemainingTimeRestriction = new DateTime();
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
    }

    public class MultipleChoiceQuestion : Question
    {
        // ******************************************************************** // 
        // Een lijst, die alle antwoord-opties bevat. Deze antwoord-opties
        // bevatten een "Description en een "RightAnswer" veld.
        // ******************************************************************** // 
        public List<Answer> AnswerOptions { get; }

        // MultipleChoiceQuestion Constructor
        public MultipleChoiceQuestion(String description) : base(description)
        {
        }

        // Voegt een antwoord-optie toe aan de "MultipleChoiceQuestion" lijst.
        public void AddAnswerOption(String Description, int ID)
        {
            AnswerOptions.Add(new Answer(Description));
        }
        // Verwijdert een "AnswerOption" van de "MultipleChoiceQuestion" lijst.
        public void DeleteAnswerOption(int Option)
        {
            AnswerOptions.RemoveAt(Option);
        }

        // Print de vraag in de console met de antwoorden.             
        public void PrintQuestion()
        {
            System.Console.WriteLine(this.ID + ", " + this.Description + ":");
            foreach (Answer Option in this.AnswerOptions)
            {
                System.Console.WriteLine(Option.ID + ", " + Option.Description);
            }
        }
    }

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
