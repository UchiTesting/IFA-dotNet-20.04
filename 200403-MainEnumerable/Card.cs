namespace MainEnumerable
{
    public class Card
    {
        private CardIndexEnum Index { get; set; }
        public Card(CardIndexEnum idx)
        {
            Index = idx;
        }

        public override string ToString()
        {
            return $"Card name: {Index}";
        }
    }
}