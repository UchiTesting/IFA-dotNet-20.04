using System;
using System.Collections;
using System.Collections.Generic;

namespace MainEnumerable
{
    public class CardHandEnumerator : IEnumerator<Card>
    {
        private CardHand Hand { get; set; }
        private int _index;
        private Card current;
        public Card Current {
            get
            {
                try
                {
                    return Hand.Cards[_index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
            set { current = value; }
        }

        public CardHandEnumerator(CardHand hand)
        {
            Hand = hand;
            Reset();
        }

        public bool MoveNext()
        {
            if (_index >= Hand.Cards.Count-1)
                return false;
 
            _index++;

            Current = (_index < Hand.Cards.Count) ? Hand.Cards[_index] : null;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }


        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}