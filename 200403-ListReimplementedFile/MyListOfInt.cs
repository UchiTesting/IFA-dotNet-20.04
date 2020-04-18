using System;
using System.Collections;
using System.IO;

namespace ListReimplementedFile
{
    public class MyListOfInt : IEnumerable
    {
        string FilePath { get; set; }
        //public int[] TheListOfInt = new int[0];
        public int ListLength { get; set; }

        public MyListOfInt()
        {
            FilePath = "ListOfInt.txt";
            ListLength = 0;
            this.Clear();
        }

        public void Add(string filePath, int i)
        {
            AppendFile(filePath, i.ToString());
        }

        public void Add(int i) { Add(FilePath, i); }
        // TODO
        public void RemoveAt(int idx)
        {

            Console.WriteLine($"Element to be removed: {ReadLine(FilePath, idx)}");
            StreamReader streamReader = new StreamReader(FilePath);

            if (idx >= GetNumberOfLines(FilePath))
                return; // Guard clause could become an exception

            string FilePathTmp = "ListOfIntTmp.txt";

            try
            {
                for (int i = 0; i < idx; i++)
                {
                    AppendFile(FilePathTmp, ReadLine(FilePath, i));
                }
                // This code is awful :O
                for (int i = idx+1; i < (GetNumberOfLines(FilePath)- idx); i++)
                {
                    AppendFile(FilePathTmp, ReadLine(FilePath, i));
                }

                Clear();
                File.Copy(FilePathTmp, FilePath);

            }
            catch (IOException ioe)
            {

                Console.WriteLine($"Exception: {ioe.Message}"); ;
            }
        }
        public void Clear()
        {
            WriteFile(FilePath, string.Empty);
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public string ReadLine(string filePath)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filePath);
                return streamReader.ReadLine();
            }
            catch (IOException ioe) { Console.WriteLine(ioe.Message); }
            finally { streamReader.Close(); }

            return null;
        }
        public string ReadLine(string filePath, int lineNumber)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filePath);
                for (int i = 0; i < lineNumber; i++)
                {
                    if (!streamReader.EndOfStream) streamReader.ReadLine();
                }
                return streamReader.ReadLine();
            }
            catch (IOException ioe) { Console.WriteLine(ioe.Message); }
            finally { streamReader.Close(); }

            return null;
        }
        public void ReadFile(string filePath)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(filePath);
                if (!streamReader.EndOfStream) streamReader.ReadToEnd();
            }
            catch (IOException ioe) { Console.WriteLine(ioe.Message); }
            finally { streamReader.Close(); }
        }

        public int GetNumberOfLines(string filePath)
        {
            StreamReader streamReader;
            int nbLines = 0;
            try
            {
                streamReader = new StreamReader(filePath);
                while (!streamReader.EndOfStream)
                {
                    streamReader.ReadLine();
                    nbLines++;
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

            return nbLines;
        }
        public void WriteFile(string filePath, string content)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(filePath, false);
                streamWriter.Write($"{content}\n");
            }
            catch (IOException ioe) { Console.WriteLine(ioe.Message); }
            finally { streamWriter.Close(); }
        }
        public void AppendFile(string filePath, string content)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(filePath, true);
                streamWriter.Write($"{content}\n");
            }
            catch (IOException ioe) { Console.WriteLine(ioe.Message); }
            finally { streamWriter.Close(); }
        }
    }
}