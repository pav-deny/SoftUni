using MilitaryElite.Models.Interfaces;
using System;

namespace MilitaryElite.Models.Abstract
{
    public abstract class SpecialisedSoldier : RegularSoldier, ISpecializedSoldier
    {
        private string corps;

        protected SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, string corps) 
            : base(firstName, lastName, id, salary)
        {
            Corps = corps;
        }

        public string Corps
        {
            get => corps;
            private set
            {
                if (value != "Airforces" && value != "Marines")
                    throw new ArgumentException("Invalid corps!");

                corps = value;
            }
        }
    }
}
