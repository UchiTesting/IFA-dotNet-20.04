using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace _200430_Exo04_Cat_Files
{
	class MyFile : INotifyPropertyChanged
	{
		public string Path { get; set; }
		public string Content { get; set; }

		public MyFile(string path)
		{
			Path = path;
			Content = File.ReadAllText(path);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
		}

		public void SaveContent()
		{
			try
			{
				File.WriteAllText(Path, Content);
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public override string ToString()
		{
			return Path; // File is identified by its path. Moreover it's needed for Listbox which invokes ToString() to display its elements.
		}
	}
}
