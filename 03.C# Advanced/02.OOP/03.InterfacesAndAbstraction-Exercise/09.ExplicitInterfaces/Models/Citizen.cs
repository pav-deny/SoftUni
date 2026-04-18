using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        // Common properties
        public string Name { get; private set; }
        public string Country { get; private set; }
        public int Age { get; private set; }

        // Constructor
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        // Explicit IResident implementation
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

        // Explicit IPerson implementation
        string IPerson.GetName()
        {
            return Name;
        }
    }
}
