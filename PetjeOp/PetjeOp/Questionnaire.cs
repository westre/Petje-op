using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp
{
    class Questionnaire
    {
        public string Name { get; set; }
        private List<Question> questions;

        // Constructor voor de klasse maakt alvast een lege lijst aan
        public Questionnaire(string n)
        {
            Name = n;
            questions = new List<Question>();
        }

        // Voeg een vraag aan de lijst toe
        public void addQuestion(Question q)
        {
            questions.Add(q);
        }

        // Verwijder een vraag uit de lijst
        public void deleteQuestion(int i)
        {
            questions.RemoveAt(i);
        }

        // Weergeeft de vragen in de vragenlijst
        public void listQuestions()
        {
            foreach (Question q in questions)
            {
                Console.WriteLine(q);
            }
        }
    }
}
