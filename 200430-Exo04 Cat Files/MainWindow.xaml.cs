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
using System.IO;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace _200430_Exo04_Cat_Files
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<MyFile> filePaths = new ObservableCollection<MyFile>();
		public MainWindow()
		{
			InitializeComponent();

			LbFileList.ItemsSource = filePaths;
		}

		public void Update()
		{
			LbFileList.Items.Refresh();
		}
		public void AddFile(string newPath)
		{
			filePaths.Add(new MyFile(newPath));
			Update();
		}
		public void PopulateFileList()
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();

				openFileDialog.Multiselect = true;
				openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

				if (Directory.Exists("D:\\")) openFileDialog.InitialDirectory = "d:\\";

				if (openFileDialog.ShowDialog() == true)
				{

					foreach (var item in openFileDialog.FileNames)
					{
						// Should be checking if items already exist in the list later.
						AddFile(item);
					}
				}
			}
			catch (Exception e)
			{

				Console.WriteLine(e.Message); ;
			}
		}

		private void BtnOpenFiles_Click(object sender, RoutedEventArgs e)
		{
			PopulateFileList();
		}

		private void LbFileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string MetaContent = null;
			foreach (MyFile item in LbFileList.SelectedItems)
			{
				MetaContent += item.Content;
				TxbContent.Text = MetaContent;
			}
		}

		private void BtnOpenInDialogs_Click(object sender, RoutedEventArgs e)
		{
			foreach (MyFile item in LbFileList.SelectedItems)
			{
				Window1 newDialog = new Window1();
				newDialog.Title = item.Path;
				newDialog.textBox.Text = item.Content;
				newDialog.Show();
			}
		}

		private void BtnSaveMultiInFile_Click(object sender, RoutedEventArgs e)
		{
			string MetaContent = null;
			MyFile MultiFile = null;

			foreach (MyFile item in LbFileList.SelectedItems)
			{
				MetaContent += item.Content;
			}

			try
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

				if (saveFileDialog.ShowDialog() == true)
				{
					MultiFile = new MyFile(saveFileDialog.FileName);
					MultiFile.Content = MetaContent;
					MultiFile.SaveContent();
				}


			}
			catch (Exception except)
			{
				MessageBox.Show(this, except.Message, "Saveing files gone wild!");
			}
		}
	}
}
