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
}