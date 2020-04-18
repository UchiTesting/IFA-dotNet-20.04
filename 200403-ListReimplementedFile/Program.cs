using System;

namespace ListReimplementedFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MyListOfInt myListOfInt = new MyListOfInt();

            for (int i = 0; i < 10; i++)
            {
                myListOfInt.Add(i);
            }
            
            myListOfInt.RemoveAt(0);

            //Console.WriteLine(myListOfInt[0]);
        }
    }
}