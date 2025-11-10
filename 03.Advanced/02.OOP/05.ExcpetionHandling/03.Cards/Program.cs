using System.Text;

namespace _03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new();

            foreach (string str in input)
            {
                string[] cardData = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string face = cardData[0], suit = cardData[1];

                try
                { 
                    Card card = CreateCard(face, suit);
                    cards.Add(card);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Card card in cards)
                Console.Write($"{card} ");
        }

        static Card CreateCard(string face, string suit)
        {
            Card card = new(face, suit);
            return card;
        }
    }

    public class Card
    {
        private static readonly HashSet<string> validFaces = new() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private static readonly Dictionary<string, string> suits = new()
        {
            {"S", "\u2660"},
            {"H", "\u2665"},
            {"D", "\u2666"},
            {"C", "\u2663"}
        };


        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            private set
            {
                if (!validFaces.Contains(value))
                    throw new ArgumentException("Invalid card!");

                face = value;
            }
        }
        public string Suit
        {
            get => suit;
            private set
            {
                if (!suits.ContainsKey(value))
                    throw new ArgumentException("Invalid card!");

                suit = value;
            }
        }

        public override string ToString() => $"[{this.Face}{suits[suit]}]";
    }
}
