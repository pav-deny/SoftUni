using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, IBuyer> buyersByName = new();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IBuyer buyer = null;

                if (data.Length == 4)
                {
                    buyer = new Citizen(data[0], int.Parse(data[1]), data[2], data[3]);
                }
                else
                {
                    buyer = new Rebell(data[0], int.Parse(data[1]), data[2]);
                }

                buyersByName.Add(data[0], buyer);
            }

            string name = string.Empty;
            while ((name = Console.ReadLine()) != "End")
            {
                if (!buyersByName.ContainsKey(name))
                    continue;

                IBuyer buyer = buyersByName[name];
                buyer.BuyFood();
            }

            Console.WriteLine(buyersByName.Sum(b => b.Value.Food));
        }
    }
}
