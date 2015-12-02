using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public class Result
    {
        public int examID;
        public int answerID;
        public int questionID;

        public Result(int examID, int answerID, int questionID)
        {
            this.examID = examID;
            this.answerID = answerID;
            this.questionID = questionID;
        }
        public override string ToString()
        {
            return "";
        }
    }

}