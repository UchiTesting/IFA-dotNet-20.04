using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExoLINQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Liste source.");
            int[] numbers = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            
            DisplayTable(numbers);
            // DisplayCollection<int>.DisplayTableContent(numbers);

            Console.WriteLine("Multiples de 2.");
            IEnumerable<int> numQuery = from num in numbers
                where (num % 2) == 0
                select num;

            DisplayTable(numQuery);

            Console.WriteLine("Multiples de 5");

            IEnumerable<int> numQuery2 = from num in numbers
                where (num % 5) == 0
                select num;
            
            DisplayTable(numQuery2);

            Console.WriteLine("Valeurs par 10");
            IEnumerable<int> numQuery3 = from num in numbers
                select num * 10;
            
            DisplayTable(numQuery3);
        }

        public static void DisplayTable(int[] table)
        {
            foreach (int i in table)
            {
                Console.Write($"{i,5}");
            }

            Console.WriteLine($"\n-----");
        }
        
        public static void DisplayTable(IEnumerable<int> table)
        {
            foreach (int i in table)
            {
                Console.Write($"{i,5}");
            }

            Console.WriteLine($"\n-----");
        }
    }
}