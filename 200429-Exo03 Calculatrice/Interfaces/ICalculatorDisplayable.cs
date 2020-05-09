using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200429_Exo03_Calculatrice.Interfaces
{
	public interface ICalculatorDisplayable
	{
		void UpdateDisplayWithResult();
		void UpdateDisplayWithOperand();
	}
}
