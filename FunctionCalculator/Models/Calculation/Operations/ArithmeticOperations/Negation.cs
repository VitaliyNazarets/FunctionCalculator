using FunctionCalculator.Models.Calculation.Operations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.ArithmeticOperations
{
    public class Negation : UnaryOperation
    {
        public Negation(UniversalOperation negate) : base(negate) { }

        public override double Operation()
        {
            return -Argument.Operation();
        }
    }
}
