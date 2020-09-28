using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.Base
{
	class Number : UniversalOperation
	{
        private readonly double _value;
        public Number(double value)
        {
            _value = value;
        }

        public override double Operation()
        {
            return _value;
        }
    }
}
