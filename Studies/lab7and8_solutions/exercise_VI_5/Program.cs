using System;

namespace exercise_VI_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player("Krzysztof", 1000);
            Console.WriteLine(p);
            Console.WriteLine();

            Card c = Card.GetRandomCard();
            Console.WriteLine(c);
            Console.WriteLine();

            Card[] deck24 = Card.getDeck();
            foreach (Card card in deck24) Console.WriteLine(card);
        }
    }

    struct Player
    {
        public string Name { get; set; }
        public short Rank { get; set; }

        public Player(string name, short rank)
        {
            Name = name;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"Player {Name}, rank: {Rank}";
        }
    }

    struct Card
    {
        public enum CardColor : byte { HEARTS, DIAMONDS, CLUBS, SPADES }
        public enum CardValue : byte { NINE, JACK=2, QUEEN, KING, TEN=10, ACE }

        public CardColor Color { get; set; }
        public CardValue Value { get; set; }

        public Card(CardColor color, CardValue value)
        {
            this.Color = color;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{Value} of {Color}";
        }

        public static Card GetRandomCard()
        {
            Random r = new Random();
            CardColor c = (CardColor)r.Next(4);

            CardValue[] values = { CardValue.NINE, CardValue.JACK,
                CardValue.QUEEN, CardValue.KING, CardValue.TEN, CardValue.ACE };
            CardValue v = values[r.Next(values.Length)];

            return new Card(c, v);
        }

        public static Card[] getDeck()
        {
            Card[] deck = new Card[24];

            CardValue[] values = { CardValue.NINE, CardValue.JACK,
                CardValue.QUEEN, CardValue.KING, CardValue.TEN, CardValue.ACE };
            for (byte i = 0; i < 4; i++)
            {
                for (byte j = 0; j < values.Length; j++)
                {
                    Card c = new Card((CardColor)i, values[j]);
                    deck[i*values.Length + j] = c;
                }
            }
            return deck;
        }

    }

}
