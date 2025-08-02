using System;
using System.Collections.Generic;

namespace _01.AdvertisementMessage
{
    internal class Program
    {
        static void Main()
        {
            int messagesCount = int.Parse(Console.ReadLine());

            List<AdMessage> messages = new();

            for (int i = 0; i < messagesCount; i++)
            {
                AdMessage message = new();

                messages.Add(message);
            }

            foreach (AdMessage m in messages)
            {
                Console.WriteLine(AdMessage.GetMessage(m));
            }
        }
    }

    public class AdMessage
    {
        public string[] Phrases
        {
            get
            {
                string[] phrasesArr = { "Excellent product.", "Such a great product.", "I always use that product.",
                    "Best product of its category.", "Exceptional product.", "I can't live without this product." };

                return phrasesArr;
            }
        }

        public string[] Events
        {
            get
            {
                string[] eventsArr = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                    "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

                return eventsArr;
            }
        }

        public string[] Authors
        {
            get
            {
                string[] authorsArr = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

                return authorsArr;
            }
        }

        public string[] Cities
        {
            get
            {
                string[] citiesArr = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

                return citiesArr;
            }
        }

        public Random Rnd { get { return new(); } }

        public int PhraseIndex { get { return Rnd.Next(0, 6); } }

        public int EventIndex { get { return Rnd.Next(0, 6); } }

        public int AuthorIndex { get { return Rnd.Next(0, 8); } }

        public int CityIndex { get { return Rnd.Next(0, 5); } }

        public AdMessage()
        {

        }

        public static string GetMessage(AdMessage message)
        {
            string phrase = message.Phrases[message.PhraseIndex];
            string @event = message.Events[message.EventIndex];
            string author = message.Authors[message.AuthorIndex];
            string city = message.Cities[message.CityIndex];

            string finalMessage = $"{phrase} {@event} {author} - {city}";

            return finalMessage;
        }

    }
}