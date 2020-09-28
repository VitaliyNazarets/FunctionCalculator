using FunctionCalculator.Models.Calculation.Operations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.ArithmeticOperations
{
    public class Cosine : UnaryOperation
    {
        public Cosine(UniversalOperation Argument) : base(Argument) { }

        public override double Operation()
        {
            return Math.Cos(Argument.Operation());
        }
    }
}
