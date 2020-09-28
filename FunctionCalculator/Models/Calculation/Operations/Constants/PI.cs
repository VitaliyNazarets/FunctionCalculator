using FunctionCalculator.Models.Calculation.Operations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.Constants
{
	class PI : UniversalOperation
	{
		private const double value = Math.PI;
		public override double Operation()
		{
			return value;
		}
	}
}
