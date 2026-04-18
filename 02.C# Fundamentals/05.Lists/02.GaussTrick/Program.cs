using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            int originalCount = list.Count / 2;

            for (int i = 0; i < originalCount; i++)
            {
                int secondNumIndex = (list.Count - 1);
                list[i] += list[secondNumIndex];
                list.RemoveAt(secondNumIndex); 
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
