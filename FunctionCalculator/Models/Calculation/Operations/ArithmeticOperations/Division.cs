using FunctionCalculator.Models.Calculation.Operations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.ArithmeticOperations
{
    public class Division : BinaryOperation
    {
        public Division(UniversalOperation leftArg, UniversalOperation rightArg) : base(leftArg, rightArg) { }

        public override double Operation()
        {
            if (RightArgument.Operation() != 0)
                return LeftArgument.Operation() / RightArgument.Operation();
            else
                throw new DivideByZeroException("Divizion by zero");
        }
    }
}
