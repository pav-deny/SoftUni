using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : RegularSoldier, ISpecialisedSoldier
    {
        private string corps;

        public string Corps
        {
            get => corps;
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid corps");
                }
                corps = value;
            }
        }

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps; // validation happens here
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nCorps: {Corps}";
        }
    }
}
