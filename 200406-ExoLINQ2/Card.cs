using System.Collections;

namespace ExoLINQ2
{
    public class Card
    {
        public CARDCOLOR Color { get; set; }
        public CARDVALUES Value { get; set; }

        public Card(CARDCOLOR color, CARDVALUES value)
        {
            Color = color;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} of {Color}";
        }
    }
}