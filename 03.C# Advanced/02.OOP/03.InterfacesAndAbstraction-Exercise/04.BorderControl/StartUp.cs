using System;
using System.Collections.Generic;
using System.Linq;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IIdentifiable passer = null;
            List<IIdentifiable> passers = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 3)
                {
                    passer = new Citizen(data[0], int.Parse(data[1]), data[2]);
                }
                else
                {
                    passer = new Robot(data[0], data[1]);
                }

                passers.Add(passer);
            }

            string fakesEndings = Console.ReadLine();

            List<IIdentifiable> fakeIds = passers.Where(p => p.Id.EndsWith(fakesEndings)).ToList();

            foreach (IIdentifiable faker in fakeIds)
                Console.WriteLine(faker.Id);
        }
    }
}
