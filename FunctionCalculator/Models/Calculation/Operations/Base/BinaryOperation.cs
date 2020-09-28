using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation.Operations.Base
{
	public abstract class BinaryOperation : UniversalOperation
	{
		protected UniversalOperation LeftArgument { get; set; } 
		protected UniversalOperation RightArgument { get; set; }
		public BinaryOperation(UniversalOperation leftOperation, UniversalOperation rightOperation)
		{
			LeftArgument = leftOperation;
			RightArgument = rightOperation;
		}
	}
}
