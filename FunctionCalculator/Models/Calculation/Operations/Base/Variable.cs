using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.Base
{
    class Variable : UniversalOperation
    {
        private double _value = default;
        public Variable()
        {
        }

        public void SetValue(double value)
		{
            _value = value;
		}

        public override double Operation()
        {
            return _value;
        }
    }
}
