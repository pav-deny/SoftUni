using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Select(w => w = w.ToLower()).ToArray(); ;

            Dictionary<string, int> wordsOccurrences = new();
            
            foreach (string word in words)
            {
                if (wordsOccurrences.ContainsKey(word))
                {
                    wordsOccurrences[word]++;
                }
                else
                {
                    wordsOccurrences.Add(word, 1);
                }
            }

            foreach ((string word, int occurances) in wordsOccurrences)
            {
                if (occurances % 2 == 0)
                {
                    continue;
                }

                Console.Write($"{word} ");
            }
        }
    }
}
