using Calendar.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetjeOp {
    public class EditExamModel {
        public CustomEvent Event { get; set; }
        public Exam Exam { get; set; }
        public Exam LocallyEditedExam { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Class> Classes { get; set; }
    }
}