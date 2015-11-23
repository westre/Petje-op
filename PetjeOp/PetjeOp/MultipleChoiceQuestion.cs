using System;
using System.Collections.Generic;

namespace PetjeOp
{

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
}
