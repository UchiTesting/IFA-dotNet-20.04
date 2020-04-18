using System;
using System.Collections.Generic;

namespace _200402_LambdaCalc
{
    class Program
    {
        public delegate int Operation(int i, int j);

        static int Sum(int a, int b) => a + b;
        static int Sub(int a, int b) => a - b;
        static int Mlt(int a, int b) => a * b;
        static int Div(int a, int b) => a / b;
        static int Mod(int a, int b) =>  a % b;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Operation add = Sum;
            Operation subtract = Sub;
            Operation multiply = Mlt;
            Operation divide = Div;
            Operation modulo = Mod;

            Random rnd = new Random();

            for (int i = 0; i < 15; i++)
            {
                int rndOp = rnd.Next(0, 5);
                Func<int, int, int> oper = Sum;
                switch (rndOp)
                {
                    case 0:
                        oper = Sum;
                        break;
                    case 1:
                        oper = Sub;
                        break;
                    case 2:
                        oper = Mlt;
                        break;
                    case 3:
                        oper = Div;
                        break;
                    case 4:
                        oper = Mod;
                        break;
                }

                DisplayOperation(rnd.Next(0, 100), rnd.Next(1, 100), oper);
            }
        }

        static void DisplayOperation(int a, int b, Func<int, int, int> op)
        {
            try
            {
                Console.WriteLine("A: {0}, B: {1}, OP: {2}, RES: {3}", a, b, op.Method, op.Invoke(a, b));
            }
            catch (FormatException)
            {
                Console.WriteLine("Quack!");
            }
        }

        static void CollectionLambda()
        {
            List<int> myInts = new List<int>();
            myInts.Add(1);
            myInts.Add(1);

            myInts.ForEach(n => { n += 1; n -= 1; });
        }

        
}
}

