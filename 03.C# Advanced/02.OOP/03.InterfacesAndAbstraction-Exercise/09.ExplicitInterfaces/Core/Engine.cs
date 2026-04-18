using ExplicitInterfaces.Core.Interaces;
using ExplicitInterfaces.IO.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;
            var citizens = new List<Citizen>();

            while ((input = reader.ReadLine()) != "End")
            {
                // Parse input: "<name> <country> <age>"
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = parts[0];
                string country = parts[1];
                int age = int.Parse(parts[2]);

                // Create Citizen
                Citizen citizen = new Citizen(name, country, age);
                citizens.Add(citizen);
            }

            // Print each citizen's IPerson and IResident names
            foreach (var citizen in citizens)
            {
                writer.WriteLine(((IPerson)citizen).GetName());     // Just the name
                writer.WriteLine(((IResident)citizen).GetName());   // Mr/Ms/Mrs + name
            }
        }
    }
}
