using System.Collections.Generic;

namespace PetjeOp.Questionnaires
{
    public class QuestionnaireOverviewModel
    {
        public string Name { get; set; }
        public List<Questionnaire> AllQuestionnaires { get; set; }
        public List<Questionnaire> ListQuestionnaires { get; set; }
        public List<Subject> Subjects { get; set; } 
        public List<Teacher> Teachers { get; set; }
    }
}
