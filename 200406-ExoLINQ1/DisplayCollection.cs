using System;

namespace ExoLINQ1
{
    public class DisplayCollection<T>
    {
        public static void DisplayTableContent(T[] table)
        {
            foreach (T i in table)
            {
                Console.Write($"{i,5}");
            }

            Console.WriteLine($"\n-----");
        }
        
    }
}