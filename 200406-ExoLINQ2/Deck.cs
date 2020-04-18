using System;
using System.Collections;
using System.Collections.Generic;

namespace ExoLINQ2
{
    public class Deck : IEnumerable<Card>
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
        }

        public Card this[int i]
        {
            get { return Cards[i]; }
            set { Cards[i] = value; }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int index = rng.Next(0, Cards.Count);
                Card tmp = Cards[i];
                Cards[i] = Cards[index];
                Cards[index] = tmp;
            }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return new CardEnumerator(Cards);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}