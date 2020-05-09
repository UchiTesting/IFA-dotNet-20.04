using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using _200429_Exo03_Calculatrice.Interfaces;

namespace _200429_Exo03_Calculatrice
{
	class Calculator
	{

		public double Result { get; set; }
		public double Operand { get; set; }
		public string DisplayableOperand { get; set; }
		public char Operation { get; set; }

		private readonly ICalculatorDisplayable _calculatorDisplayable;

		public Calculator(ICalculatorDisplayable calculatorDisplayable)
		{
			Result = 0;
			Operand = 0;
			DisplayableOperand = "0";
		  // La toute première opération doit être une addition pour stocker correctement la valeur dans resultat. Elle sera ensuite écrasé par l'utilisation des boutons de la calculatrice.
			Operation = '+';

			_calculatorDisplayable = calculatorDisplayable;
		}

		public double add(double operand)
		{
			Result += operand;
			return Result;
		}

		public double sub(double operand)
		{
			Result -= operand;
			return Result;
		}

		public double mult(double operand)
		{
			Result *= operand;
			return Result;
		}
		public double div(double operand)
		{
			if (operand != 0)
			{
				Result /= operand;
				return Result;
			}
			else
			{
				throw new DivideByZeroException("You can't divide by 0 you muppet!");
			}
		}

		public void SetOperation(char op)
		{
			ApplyOperation();
			Operation = op;
			UpdateDisplayWithResult();
		}

		private void ApplyOperation()
		{
			Operand = double.Parse(DisplayableOperand, System.Globalization.CultureInfo.InvariantCulture);

			switch (Operation)
			{
				case '+':
					add(Operand);
					break;
				case '-':
					sub(Operand);
					break;
				case '*':
					mult(Operand);
					break;
				case '/':
					div(Operand);
					break;
				case '=': // placeholder
					break;
				default:
					Result = Operand;
					break;
			}

			ClearOperand();
		}

		public void ClearOperand()
		{
			Operand = 0;
			DisplayableOperand = "0";
			_calculatorDisplayable.UpdateDisplayWithOperand();
		}

		private void UpdateDisplayWithResult()
		{
			_calculatorDisplayable.UpdateDisplayWithResult();
		}

		public void AddDigit(char digit)
		{

			if (Operation == '=')
			{
				ClearAllOps();
			}

			if (DisplayableOperand == "0")
			{
				if (digit == '.')
					DisplayableOperand += digit;
				else
					DisplayableOperand = digit.ToString();
			}
			else
			{
				if (digit != '.')
				{
					DisplayableOperand += digit;
				}
				else
				{
					if (!DisplayableOperand.Contains('.'))
					{
						DisplayableOperand += digit;
					}
				}
			}

			UpdateDisplayWithOperand();
		}

		public void RemoveDigit()
		{
			if (DisplayableOperand.Length > 1)
			{
				DisplayableOperand = DisplayableOperand.Substring(0, DisplayableOperand.Length - 1);
				//Operand = double.Parse(DisplayableOperand.Substring(0, DisplayableOperand.Length - 1));
			}
			else
			{
				ClearOperand();
			}

			UpdateDisplayWithOperand();
		}

		public void InvertSign()
		{
			if (Operation == '=')
			{
				Result = -Result;
				UpdateDisplayWithResult();
			}
			else
			{
				if (DisplayableOperand[0] == '-')
					DisplayableOperand = DisplayableOperand.Substring(1, DisplayableOperand.Length - 1);
				else
					DisplayableOperand = "-" + DisplayableOperand;

				UpdateDisplayWithOperand();
			}
		}
		private void UpdateDisplayWithOperand()
		{
			_calculatorDisplayable.UpdateDisplayWithOperand();
		}

		public void ClearAllOps()
		{
			Result = 0;
			ClearOperand();
			Operation = '+';
			_calculatorDisplayable.UpdateDisplayWithResult(); // Indifférent. On aurait pu afficher l'opérande.
		}
	}
}
