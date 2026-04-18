using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, uint> resourcesQuantities = new();


            string input = string.Empty;
            while ((input = Console.ReadLine()) != "stop")
            {
                string resource = input;

                if(!resourcesQuantities.ContainsKey(resource))
                {
                    resourcesQuantities.Add(resource, default);
                }

                uint quantaty = uint.Parse(Console.ReadLine());
                resourcesQuantities[resource] += quantaty;
            }

            foreach (KeyValuePair<string, uint> resourceQuantity in resourcesQuantities)
            {
                Console.WriteLine($"{resourceQuantity.Key} -> {resourceQuantity.Value}");
            }

        }
    }
}
