using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _200429_Exo03_Calculatrice.Interfaces;

namespace _200429_Exo03_Calculatrice
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, ICalculatorDisplayable
	{
		private static Calculator calculator;
		public MainWindow()
		{
			calculator = new Calculator(this);

			InitializeComponent();

			calculator.ClearAllOps();
		}

		public void UpdateDisplayWithResult()
		{
			LblDisplay.Content = calculator.Result;
		}

		public void UpdateDisplayWithOperand()
		{
			LblDisplay.Content = calculator.DisplayableOperand;
		}

		private void Btn0_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('0');
		}

		private void Btn1_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('1');
		}

		private void Btn2_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('2');
		}

		private void Btn3_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('3');
		}

		private void Btn4_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('4');
		}

		private void Btn5_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('5');
		}

		private void Btn6_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('6');
		}

		private void Btn7_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('7');
		}

		private void Btn8_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('8');
		}

		private void Btn9_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('9');
		}

		private void BtnReturn_Click(object sender, RoutedEventArgs e)
		{
			calculator.RemoveDigit();
		}

		private void BtnOpPlus_Click(object sender, RoutedEventArgs e)
		{
			calculator.SetOperation('+');
		}

		private void BtnOpMult_Click(object sender, RoutedEventArgs e)
		{
			calculator.SetOperation('*');
		}

		private void BtnOpDiv_Click(object sender, RoutedEventArgs e)
		{
			calculator.SetOperation('/');
		}

		private void BtnOpSub_Click(object sender, RoutedEventArgs e)
		{
			calculator.SetOperation('-');
		}

		private void BtnOpEqual_Click(object sender, RoutedEventArgs e)
		{
			calculator.SetOperation('=');
		}

		private void BtnDecimalDot_Click(object sender, RoutedEventArgs e)
		{
			calculator.AddDigit('.');
		}

		private void BtnSignInversion_Click(object sender, RoutedEventArgs e)
		{
			calculator.InvertSign();
		}

		private void BtnClear_Click(object sender, RoutedEventArgs e)
		{
			calculator.ClearAllOps();
		}
	}
}
