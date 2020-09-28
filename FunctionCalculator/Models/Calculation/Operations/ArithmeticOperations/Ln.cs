using FunctionCalculator.Models.Calculation.Operations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.ArithmeticOperations
{
    public class Ln : UnaryOperation
    {
        public Ln(UniversalOperation Argument) : base(Argument) { }

        public override double Operation()
        {
            return Math.Log(Argument.Operation());
        }
    }
}
