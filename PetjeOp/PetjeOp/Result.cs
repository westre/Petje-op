using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetjeOp
{
    public class Result
    {
        public int Index { get; set; }
        private double Percentage { get; set; }

        public override string ToString()
        {
            return Index + " - " + Percentage;
        }
    }

}
