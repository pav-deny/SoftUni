using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] parts = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string filterType = parts[1];
                string parameter = parts[2];

                string filterKey = $"{filterType};{parameter}";

                if (command == "Add filter")
                {
                    Predicate<string> predicate = null;

                    if (filterType == "Starts with")
                        predicate = x => x.StartsWith(parameter);

                    else if (filterType == "Ends with")
                        predicate = x => x.EndsWith(parameter);

                    else if (filterType == "Length")
                        predicate = x => x.Length == int.Parse(parameter);

                    else if (filterType == "Contains")
                        predicate = x => x.Contains(parameter);

                    filters[filterKey] = predicate;
                }
                else if (command == "Remove filter")
                {
                    filters.Remove(filterKey);
                }
            }

            foreach (var predicate in filters.Values)
            {
                guests.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(' ', guests));
        }
    }
}
