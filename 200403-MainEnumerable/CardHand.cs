using System.Collections;
using System.Collections.Generic;

namespace MainEnumerable
{
    public class CardHand : IEnumerable<Card>
    {
        public List<Card> Cards { get; set; }

        public CardHand()
        {
            Cards = new List<Card>();
        }
        public CardHand(List<Card> cards)
        {
            Cards = cards;
        }
        
        public IEnumerator<Card> GetEnumerator()
        {
            return new CardHandEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddCard(Card c)
        {
            Cards.Add(c);
        }
    }
}