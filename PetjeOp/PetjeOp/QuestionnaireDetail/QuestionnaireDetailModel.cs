using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp {
    public class QuestionnaireDetailModel {
        public string Name { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public List<Questionnaire> Questionnaires { get; set; } 
    }
}
