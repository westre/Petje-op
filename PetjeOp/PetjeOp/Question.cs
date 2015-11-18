using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp
{
    public abstract class Question
    {
        public String Description { get; set; }
        private List<Media> Media;

        // ******************************************************************** //
        // Als er een tijdslimiet ingesteld is voor de vraag, dan wordt
        // deze opgeslagen in het veld: "TimeRestriction." Het veld
        // "RemainingTimeRestriction" wordt gebruikt om de nog
        // beschikbare tijd in op te slaan.
        // ******************************************************************** //
        private DateTime TimeRestriction;
        private DateTime RemainingTimeRestriction;

        //* Constructor van "Question". Als parameter alleen de beschrijving.  *//
        public Question(String description)
        {
            this.Description = description;
        }

        //* Voegt een "Media" object toe aan de "Question."                    *//
        public void AddMedia(String Name, String Url, Media.MediaType Type)
        {
            Media.Add(new Media(Name, Url, Type));
        }

        //* Verwijdert een "Media" item van de "Question" lijst.               *//
        public void RemoveMedia(int Media)
        {
            this.Media.RemoveAt(Media);
        }

        //* Zet een "TimeRestriction" voor de "Question."                      *//
        public void SetTimeRestriction(DateTime TimeRestricton)
        {
            this.TimeRestriction = TimeRestricton;
            this.RemainingTimeRestriction = TimeRestricton;
        }

        //* Verwijdert de "TimeRestriction" van de "Question."                 *//
        public void ClearTimeRestriction()
        {
            this.TimeRestriction = new DateTime();
            this.RemainingTimeRestriction = new DateTime();
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
        public List<AnswerOption> AnswerOptions { get; set; }

        //* MultipleChoiceQuestion Constructor                                 *//
        public MultipleChoiceQuestion(String description) : base(description)
        {
        }

        //* Voegt een antwoord-optie toe aan de "MultipleChoiceQuestion" lijst.*//
        public void AddAnswerOption(String Description, Boolean RightAnswer)
        {
            AnswerOptions.Add(new AnswerOption(Description, RightAnswer));
        }
        //* Verwijdert een "AnswerOption" van de "MultipleChoiceQuestion" lijst.*//
        public void DeleteAnswerOption(int Option)
        {
            AnswerOptions.RemoveAt(Option);
        }

        public struct AnswerOption
        {
            public Boolean RightAnswer { get; set; }
            public String Description { get; set; }
            public AnswerOption(String Description, Boolean RightAnswer)
            {
                this.Description = Description;
                this.RightAnswer = RightAnswer;
            }
        }
        public void AnswerOptionsPrintList()
        {
            foreach (AnswerOption Option in this.AnswerOptions)
            {
                System.Console.WriteLine(Option.Description + ", " + Option.RightAnswer);
            }
        }
    }

    // TODO uitschrijven >> Yoran
    public class Media
    {
        public String Name { get; }
        public String Url { get; }
        public MediaType Type { get; }

        public Media(String Name, String Url, MediaType Type)
        {
            this.Name = Name;
            this.Url = Url;
            this.Type = Type;
        }

        public enum MediaType
        {
            image,
            video,
            youtube
        }
    }
}
