using System;
using System.Collections.Generic;
using System.IO;

namespace ExoLINQ7
{
    public class FileUtils
    {
        private string Path { get; set; }
        private string FileName { get; set; }
        public string FullPath => Path + FileName;
        StreamReader read;
        private StreamWriter st;

        public FileUtils(string path, string fileNameName)
        {
            Path = path;
            FileName = fileNameName;
        }

        public string ReadFile()
        {
            string line = "";
            string text = "";


            try
            {
                read = new StreamReader(Path + FileName);
                
                while(line != null)
                {
                    line = read.ReadLine();
                    if(line != null)
                    {
                        text = text + (line + Environment.NewLine);
                    }
                }
                read.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Fichier non trouvé");
                Console.WriteLine(e.Message);
            }

            return text;
        }

        public List<string> ReadFileToList()
        {
            string line = "";
            string text = "";
            List<string> tempList = new List<string>();


            try
            {
                read = new StreamReader(Path + FileName);
                
                while(line != null)
                {
                    line = read.ReadLine();
                    
                    if(line != null)
                    {
                        text = text + (line + Environment.NewLine);
                        tempList.Add(line);
                    }
                }
                read.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Fichier non trouvé");
                Console.WriteLine(e.Message);
            }

            return tempList;
        }

        public string ReadLine(int number)
        {
            if (number < 1) number = 1;
            
            string line = "";
            
            read = new StreamReader(Path + FileName);

            try
            {
                for (int i = 1; i < number; i++)
                {
                    if (read.EndOfStream) break;
                    ;

                    read.ReadLine();
                }

                line = read.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return line;
        }
        

        public void WriteFile(string text)
        {
            try
            {
                st = new StreamWriter(Path + FileName, false);
                st.WriteLine(text);
            }
            catch (Exception var)
            {
                Console.WriteLine("Fichier non trouvé");
                Console.WriteLine(var.Message);
            }
            finally
            {
                st.Close();
            }
        }

        public void AppendFile(string line)
        {
            try
            {
                st = new StreamWriter(Path + FileName, true);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                st.Close();
            }
        }
    }
}