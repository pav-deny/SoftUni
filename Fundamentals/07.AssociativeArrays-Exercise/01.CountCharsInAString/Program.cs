using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<char, int> charsOccurances = new();

            foreach (string str in strings)
            {
                foreach (char c in str)
                {
                    if (charsOccurances.ContainsKey(c))
                    {
                        charsOccurances[c]++;
                    }

                    else
                    {
                        charsOccurances.Add(c, 1);
                    }
                }
            }

            foreach ((char c, int occurance) in charsOccurances)
            {
                Console.WriteLine($"{c} -> {occurance}");
            }
        }
    }
}
