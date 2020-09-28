using FunctionCalculator.Models.Calculation.Operations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.ArithmeticOperations
{
    public class Tangent : UnaryOperation
    {
        public Tangent(UniversalOperation Argument) : base(Argument) { }

        public override double Operation()
        {
            return Math.Tan(Argument.Operation());
        }
    }
}
