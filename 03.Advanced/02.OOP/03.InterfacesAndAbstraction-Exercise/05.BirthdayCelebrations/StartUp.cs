using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IBirthable birthable = null;
            List<IBirthable> birthables = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Citizen")
                {
                    birthable = new Citizen(data[1], int.Parse(data[2]), data[3], data[4]);
                }
                else if (data[0] == "Pet")
                {
                    birthable = new Pet(data[1], data[2]);
                }
                else
                {
                    continue;
                }

                birthables.Add(birthable);
            }

            string year = Console.ReadLine();

            List<IBirthable> matches = birthables.Where(b => b.BirthDate.EndsWith(year)).ToList();

            foreach (IBirthable match in matches)
                Console.WriteLine(match.BirthDate);
        }
    }
}
