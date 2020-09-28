using FunctionCalculator.Models.Calculation.Operations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.ArithmeticOperations
{
    public class Exp : UnaryOperation
    {
        public Exp(UniversalOperation Argument) : base(Argument) { }

        public override double Operation()
        {
            return Math.Exp(Argument.Operation());
        }
    }
}
