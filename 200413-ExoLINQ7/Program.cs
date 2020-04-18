using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExoLINQ7
{
    class Program
    {
        /*
         * Dans fichiez texte :

selectionez toutes lettres communes à tous les mots dans une phrase aleatoire
         */
        private static string CurrentDirectory = Directory.GetCurrentDirectory() + "\\";
        private static string RelativeFileName = "..\\..\\..\\LINQ_EX7.txt";
        private static string FullPath => CurrentDirectory + RelativeFileName;
        static FileUtils fu = new FileUtils(CurrentDirectory, RelativeFileName);

        static void Main(string[] args)
        {
            if (!File.Exists(FullPath)) WriteFile();

            List<string> FileContent = fu.ReadFileToList();

            Console.WriteLine("Lines starting with A");
            LinesStartingWithA(FileContent);

            Console.WriteLine("Letter Frequency");
            MeanPerLetter(FileContent);

            Console.WriteLine($"Mean letters per line {MeanLettersPerLine(FileContent)}");

            Console.WriteLine("Vowels per line");
            VowelsPerLine(FileContent);
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////// ///
        static void WriteFile()
        {
            StringBuilder sampleText = new StringBuilder();

            sampleText.AppendLine("J'aime la glace a la vanille");
            sampleText.AppendLine("Arthur couillère ! gueula le roi Burgonde...");
            sampleText.AppendLine("Lorem bidullum et cie...");
            sampleText.AppendLine(
                "Avec autant de griffes de dragon, c'est étonnant que vous n'ayez pas ruiné le royaume!");
            sampleText.AppendLine("");
            sampleText.AppendLine("Addi");

            fu.WriteFile(sampleText.ToString());
        }

        // Selectionez toute les lignes qui commence par un a
        public static void LinesStartingWithA(List<string> list)
        {
            var query = from item in list
                orderby item
                where item.ToLower().StartsWith('a')
                select item;

            foreach (var s in query)
            {
                Console.WriteLine($"{s}");
            }
        }

        // Selectionez toutes lettres communes à tous les mots dans une phrase aleatoire
        public static void CommonLettersToAllWords(List<string> list)
        {
            // var query = from item in list
        }

        // Calculez la moyene des lettres par lignes
        static int MeanLettersPerLine(List<string> list)
        {
            int sum = 0;
            list.ForEach(l=>sum+= l.Length);
            return sum / list.Count;
        }
        public static void MeanPerLetter(List<string> list)
        {
            list.ForEach(LetterFrequency);
        }

        // Calclulez le nombre de voyelles par ligne
        public static void VowelsPerLine(List<string> list)
        {
            list.ForEach(VowelsInLine);
        }

        static void VowelsInLine(string line)
        {
            line = line.ToLower();

            int[] c = new int[6];
            string headers = "aeiouy";

            // Console.WriteLine($"Stats for line: {line.Substring(0,linePreviewLength)}...");
            Console.WriteLine($"Stats for line: {line}...");

            // Filling table with occurences.
            foreach (char t in line)
            {
                switch (t)
                {
                    case 'a':
                        c[0]++;
                        break;
                    case 'e':
                        c[1]++;
                        break;
                    case 'i':
                        c[2]++;
                        break;
                    case 'o':
                        c[3]++;
                        break;
                    case 'u':
                        c[4]++;
                        break;
                    case 'y':
                        c[5]++;
                        break;
                }
            }

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != 0)
                    Console.Write($"| {headers[i]} {c[i],3} ");
            }

            Console.Write($"|{Environment.NewLine}");
        }

        static void LetterFrequency(string line)
        {
            LetterFrequency(line, 13);
        }

        static void LetterFrequency(string line, int desiredLineLength = 13)
        {
            if (line.Length == 0) return;

            int linePreviewLength = (line.Length >= 10) ? 10 : line.Length;

            line = line.ToLower();

            int[] c = new int[26];

            // Console.WriteLine($"Stats for line: {line.Substring(0,linePreviewLength)}...");
            Console.WriteLine($"Stats for line: {line}...");
            // Filling table with occurences.
            foreach (char t in line)
            {
                // if (t>=a && t <= z)
                // if (Char.IsLetter(t)) <- Not reliable...
                if (t >= 'a' && t <= 'z')
                    c[((int) t) - ((int) 'a')]++;
            }

            // Displaying table
            Displaytable(c);
        }

        private static void Displaytable(int[] c, int desiredLineLength = 13)
        {
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != 0)
                    Console.Write($"| {((char) (i + 97))} {c[i],3} ");
                if ((i + 1) % desiredLineLength == 0 && i > desiredLineLength - 2)
                    Console.Write("|" + Environment.NewLine);
            }
        }
    }
}