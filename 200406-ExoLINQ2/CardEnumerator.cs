using System.Collections;
using System.Collections.Generic;

namespace ExoLINQ2
{
    public class CardEnumerator : IEnumerator<Card>
    {
        private List<Card> Cards { get; set; }
        private int position { get; set; }
        public Card Current => Cards[position];

        //object IEnumerator.Current => this.Current;
        object? IEnumerator.Current => this.Current;

        public CardEnumerator()
        {
            Cards = new List<Card>();
            Reset();
        }

        public CardEnumerator(List<Card> cards)
        {
            Cards = cards;
            Reset();
        }



        public bool MoveNext()
        {
            position++;
            return position < Cards.Count;
        }

        public void Reset()
        {
            position = -1;
        }



        public void Dispose() { }
    }
}