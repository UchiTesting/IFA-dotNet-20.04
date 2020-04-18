using System;
using System.Collections.Generic;
using System.Linq;

namespace ExoLINQ2
{
    /// <summary>
    /// Écrivez un programme qui contiens un deck de 54 cartes melangé
    /// une carte contiens une couleur et une valeur
    /// Ecrivez les requetes pour trouvez :
    /// toute les cartes d'une certaine couleur
    /// toutes les cartes > 10
    /// toutes les cartes classées par couleur et par valeur
    /// --
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("!");

            Deck deck = new Deck();

            deck.Cards.AddRange(CreateCards());

            deck.Shuffle();

            DisplayCardCollection(deck);

            IEnumerable<Card> cardQuery1 = from card in deck
                                           //where ((Card)card).Color == CARDCOLOR.CLUBS
                                           where card.Color == CARDCOLOR.CLUBS
                                           select card;
            Console.WriteLine("Query 1: ");
            DisplayCardCollection(cardQuery1);
            
            IEnumerable<Card> cardQuery2 = from card in deck
                                           where card.Value > (CARDVALUES)8
                                           select card;
            Console.WriteLine("Query 2: ");
            DisplayCardCollection(cardQuery2);

            IEnumerable<Card> cardQuery3 = from card in deck
                                           orderby card.Value ascending
                                           orderby card.Color ascending
                                           select card;
            Console.WriteLine("Query 3: ");
            DisplayCardCollection(cardQuery3);



        }



        public static Card CreateRandomCard()
        {
            Random rnd = new Random();
            return new Card(((CARDCOLOR)rnd.Next(0, 4)), ((CARDVALUES)rnd.Next(0, 13)));

        }

        public static Card CreateCard(int color, int value)
        {
            if (color > 3 || value > 13) // Guard Clause
                throw new Exception($"Color is {color}. Value is {value}. One of them at least is out of bounds.");
            CARDCOLOR cARDCOLOR = (CARDCOLOR)color;
            CARDVALUES cARDVALUES = (CARDVALUES)value;

            Card tmpCard = new Card(cARDCOLOR, cARDVALUES);

            return tmpCard;

        }

        public static List<Card> CreateCards()
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {

                    cards.Add(CreateCard(i, j));
                }
            }

            return cards;
        }

        public static void DisplayCardCollection(IEnumerable<Card> cardSet)
        {
            foreach (var item in cardSet)
            {
                Console.WriteLine($"Card -> {item}");
            }
        }
    }
}