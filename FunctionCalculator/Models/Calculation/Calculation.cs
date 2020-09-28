using FunctionCalculator.Models.Calculation.Operations.ArithmeticOperations;
using FunctionCalculator.Models.Calculation.Operations.Base;
using FunctionCalculator.Models.Calculation.Operations.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionCalculator.Models.Calculation
{
	class Calculation
	{
		private string _currentExpression;
		private int position;
		private Variable X {get; set;}
		public Calculation()
		{
			X = new Variable();
		}
		public void SetX(double x)
		{
					X.SetValue(x);
		}
		public double Calculate()
		{
			position = 0;
			UniversalOperation result = ParsingAnExpression_LowPriority();
			return result.Operation();
		}
		public double Calculate(string curExp)
		{
			position = 0;
			_currentExpression = curExp.ToLower().Replace(" ", "").Replace("\t", "").Replace("\n", "");
			UniversalOperation result = ParsingAnExpression_LowPriority();
			return result.Operation();
		}

		private UniversalOperation ParsingAnExpression_LowPriority()
		{
			UniversalOperation result = ParsingAnExpression_MediumPriority();

			while (true)
			{
				if (MatchSearch('+'))
				{
					result = new Addition(result, ParsingAnExpression_MediumPriority());
				}
				else if (MatchSearch('-'))
				{
					result = new Subtraction(result, ParsingAnExpression_MediumPriority());
				}
				else
				{
					return result;
				}
			}
		}

		private UniversalOperation ParsingAnExpression_MediumPriority()
		{
			UniversalOperation result = ParsingAnExpression_HighPriority();
			while (true)
			{
				//You can use this for multiplicatio, division, moduloDivision

				if (MatchSearch('*'))
				{
					result = new Multiply(result, ParsingAnExpression_MediumPriority());
				}
				else if (MatchSearch('%'))
				{
					result = new Division(result, ParsingAnExpression_MediumPriority());
				}
				else if (MatchSearch('/') || MatchSearch('÷'))
				{
					result = new Division(result, ParsingAnExpression_MediumPriority());
				}
				else
				{
					return result;
				}
			}
		}

		private UniversalOperation ParsingAnExpression_HighPriority()
		{
			UniversalOperation result = ParsingAnExpression_VeryHighPriority();
			while (true)
			{
				if (MatchSearch('^'))
				{
					result = new Pow(result, ParsingAnExpression_HighPriority());
				}
				else 
				{
					return result;
				}
			}
		}

		private UniversalOperation ParsingAnExpression_VeryHighPriority()
		{
			UniversalOperation result;

			if (MatchSearch('-'))
			{
				result = new Negation(ParsingAnExpression_LowPriority());
			}
			else if (MatchSearch('('))
			{
				result = ParsingAnExpression_LowPriority();

				if (!MatchSearch(')'))
				{
					throw new System.Exception("Missing ')'");
				}
			}
			else if (MatchSearch('x'))
				return X;
			else if (position < _currentExpression.Length && char.IsDigit(_currentExpression[position]))
			{
				result = ParsingAnExpression_Number();
			}
			#region Functions
			else if (MatchSearch("sin("))
			{
				result = new Sinus(ParsingAnExpression_LowPriority());
				if (!MatchSearch(')'))
				{
					throw new System.Exception("Missing ')' for sin");
				}
			}
			else if (MatchSearch("cos("))
			{
				result = new Cosine(ParsingAnExpression_LowPriority());
				if (!MatchSearch(')'))
				{
					throw new System.Exception("Missing ')' for cos");
				}
			}
			else if (MatchSearch("tan("))
			{
				result = new Tangent(ParsingAnExpression_LowPriority());
				if (!MatchSearch(')'))
				{
					throw new System.Exception("Missing ')' for tan");
				}
			}
			else if (MatchSearch("sqrt("))
			{
				result = new Sqrt(ParsingAnExpression_LowPriority());
				if (!MatchSearch(')'))
				{
					throw new System.Exception("Missing ')' for sqrt");
				}
			}
			else if (MatchSearch("exp("))
			{
				result = new Exp(ParsingAnExpression_LowPriority());
				if (!MatchSearch(')'))
				{
					throw new System.Exception("Missing ')' for exp");
				}
			}
			else if (MatchSearch("ln("))
			{
				result = new Ln(ParsingAnExpression_LowPriority());
				if (!MatchSearch(')'))
				{
					throw new System.Exception("Missing ')' for ln");
				}
			}
			#endregion
			#region Constants
			else if (MatchSearch("PI"))
			{
				return new PI();
			}
			else if (MatchSearch("E"))
				return new E();
			#endregion
			else
			{
				throw new System.Exception("Can't parse character at pos " + position.ToString() + "");
			}
			return result;
		}


		private UniversalOperation ParsingAnExpression_Number()
		{
			double val = 0.0;
			int startPosition = position;

			//Find out the size of the number to parse
			while (position < _currentExpression.Length && (char.IsDigit(_currentExpression[position]) || _currentExpression[position] == '.'))
			{
				position++;
			}
			try
			{
				val = double.Parse(_currentExpression.Substring(startPosition, position - startPosition));
			}
			catch (System.Exception e)
			{
				System.Console.WriteLine("The number is not parsed...");
				System.Console.WriteLine(e);
			}

			return new Number(val);
		}

		private bool MatchSearch(string str)
		{

			if (_currentExpression.Substring(position).StartsWith(str))
			{
				position += str.Length;
				return true;
			}
			else
			{
				return false;
			}
		}
		
		private bool MatchSearch(char ch)
		{
			if (position >= _currentExpression.Length)
			{
				return false;
			}
			if (_currentExpression[position] == ch)
			{
				position++;
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
