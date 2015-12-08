﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp
{
    public class Questionnaire
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public Subject Subject { get; set; }
        public Teacher Author { get; set;  }

        // Constructor voor de klasse maakt alvast een lege lijst van vragen aan
        public Questionnaire(string n)
        {
            Name = n;
            Questions = new List<Question>();
        }

        public Questionnaire(int id) {
            ID = id;
            Name = "";
            Questions = new List<Question>();
        }

        // Voeg een vraag aan de vragenlijst toe
        public void addQuestion(Question q)
        {
            Questions.Add(q);
        }

        // Verwijder een vraag uit de vragenlijst
        public void deleteQuestion(int i)
        {
            Questions.RemoveAt(i);
        }

        // Weergeeft de vragen in de vragenlijst
        public void listQuestions()
        {
            foreach (Question q in Questions)
            {
                Console.WriteLine(q);
            }
        }
        public override string ToString()
        {
            return Convert.ToString(ID);
        }
    }
}
