using System;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<string> list = new();

            for (int i = 0; i < count; i++)
            {
                list.Add(Console.ReadLine());
            }

            list.Sort();

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i+1}.{list[i]}");
            }
        }
    }
}
