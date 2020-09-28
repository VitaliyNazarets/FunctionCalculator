using FunctionCalculator.Models.Calculation.Operations.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.Constants
{
	public class E : UniversalOperation
	{
		private const double value = Math.E;
		public override double Operation()
		{
			return value;
		}
	}
}
