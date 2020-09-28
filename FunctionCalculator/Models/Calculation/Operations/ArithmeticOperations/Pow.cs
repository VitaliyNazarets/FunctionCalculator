using FunctionCalculator.Models.Calculation.Operations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.ArithmeticOperations
{
    public class Pow : BinaryOperation
    {
        public Pow(UniversalOperation leftArg, UniversalOperation rightArg) : base(leftArg, rightArg) { }

        public override double Operation()
        {
            return Math.Pow(LeftArgument.Operation(), RightArgument.Operation());
        }
    }
}
