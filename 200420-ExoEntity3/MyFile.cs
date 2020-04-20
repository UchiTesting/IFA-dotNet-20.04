using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _200420_ExoEntity3
{
	class MyFile
	{
		public string Content { get; set; }
		public StreamReader sr { get; set; }

		public StreamWriter sw { get; set; }

		public string FullPath { get; set; }

		public MyFile()
		{
			FullPath = "MyFile.txt";
			Content = "This is the content of the file. It is here as a place holder. Might be refined later to become an actual file.";
		}

		public void ReadFile()
		{
			try
			{
				sr = new StreamReader(FullPath);

				Content = sr.ReadToEnd();

				sr.Close();
			}
			catch (IOException e)
			{

				Console.WriteLine(e.Message);
			}
		}

		public void WriteFile(string s)
		{
			try
			{
				sw = new StreamWriter(FullPath, false);

				sw.Write(s);

				sw.Close();
			}
			catch (IOException e)
			{
				Console.WriteLine(e.Message);

			}
		}

		public void AppendFile(string s)
		{
			try
			{
				sw = new StreamWriter(FullPath, true);

				sw.Write(s);

				sw.Close();
			}
			catch (IOException e)
			{
				Console.WriteLine(e.Message);

			}
		}

		public void DisplayFile()
		{
			Console.WriteLine(Content);
		}
	}
}
