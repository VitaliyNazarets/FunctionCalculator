using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.Base
{
	public abstract class UnaryOperation : UniversalOperation
	{
		protected UniversalOperation Argument { get; set; }
		public UnaryOperation(UniversalOperation operation)
		{
			Argument = operation;
		}
	}
}
