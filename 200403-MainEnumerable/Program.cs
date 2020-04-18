using System;

namespace MainEnumerable
//03 04 2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Enumerable.");
            
            CardHand myHand = new CardHand();
            
            // Create a few cards
            Card Jake = new Card(CardIndexEnum.J);
            Card Queen = new Card(CardIndexEnum.Q);
            Card King = new Card(CardIndexEnum.K);
            myHand.AddCard(Jake);
            myHand.AddCard(Queen);
            myHand.AddCard(King);
            Console.WriteLine($"This is Jake : {Jake}");
            Console.WriteLine($"This is Queen : {Queen}");
            Console.WriteLine($"This is King : {King}");
            
            foreach (Card card in myHand)
            {
                Console.WriteLine($"Outer Loop { card }");
            }
        }
    }
}