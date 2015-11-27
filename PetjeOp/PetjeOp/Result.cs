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

        public Result(int i, double p)
        {
            Index = i;
            Percentage = p;
        }

        public override string ToString()
        {
            return Index + " - " + Percentage;
        }
    }

}
