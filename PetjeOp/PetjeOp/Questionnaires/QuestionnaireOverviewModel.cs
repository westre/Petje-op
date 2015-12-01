using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp.Questionnaires
{
    public class QuestionnaireOverviewModel
    {
        public string Name { get; set; }
        public List<Questionnaire> Questionnaires { get; set; }
        public List<Subject> Subjects { get; set; } 
    }
}
