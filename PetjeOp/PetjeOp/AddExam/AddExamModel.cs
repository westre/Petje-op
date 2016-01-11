using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp {
    public class AddExamModel {
        public string Name { get; set; }
        public List<Questionnaire> Questionnaires { get; set; }
        public List<Class> Classes { get; set; }
        public List<Subject> Subjects { get; set; }
        public DateTime TimeNow { get; set; }
    }
}