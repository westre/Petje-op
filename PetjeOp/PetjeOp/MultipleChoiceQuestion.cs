using System;
using System.Collections.Generic;

namespace PetjeOp
{
    public class MultipleChoiceQuestion : Question
    {
        // ******************************************************************** // 
        // Een lijst, die alle antwoord-opties bevat. Deze antwoord-opties
        // bevatten een "Description en een "CorrectAnswer" veld.
        // ******************************************************************** // 
        public List<Answer> AnswerOptions { get; set; }

        // MultipleChoiceQuestion Constructor
        public MultipleChoiceQuestion(String description) : base(description)
        {
            AnswerOptions = new List<Answer>();
            base.ID = -1;
        }

        // Voegt een antwoord-optie toe aan de "MultipleChoiceQuestion" lijst.
        public void AddAnswerOption(String Description, int ID)
        {
            AnswerOptions.Add(new Answer(Description));
        }

        //Voegt een lijst antwoordopties toe aan de lijst
        public void AddAnswerOptions(List<Answer> answers)
        {
            foreach (Answer ans in answers)
            {
                AnswerOptions.Add(ans);
            }
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
        public override string ToString()
        {
            return Description;
        }

        public Answer GetAnswer(string desc) {
            foreach(Answer answer in AnswerOptions) {
                if (desc == answer.Description)
                    return answer;
            }
            return null;
        }
    }
    }
    
