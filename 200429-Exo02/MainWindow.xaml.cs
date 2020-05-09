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
using Microsoft.Win32;
using System.IO;

namespace _200429_Exo02
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string path;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void BtnLoad_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				if (openFileDialog.ShowDialog() == true)
				{
					path = openFileDialog.FileName;

					string content = File.ReadAllText(path);

					TxbContent.Text = content;
					TbkFileName.Text = path;
				}
			}
			catch (Exception except)
			{

				MessageBox.Show($"Erreur lors du chargement du fichier {Environment.NewLine}{except.Message}");
			}
		}

		private void BtnSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{

				if (path is null)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

					if (saveFileDialog.ShowDialog() == true)
					{
						path = saveFileDialog.FileName;
						TbkFileName.Text = path;
					}

				}
				File.WriteAllText(path, TxbContent.Text);
			}
			catch (Exception exept)
			{

				Console.WriteLine(exept.Message);
			}

		}
	}
}
