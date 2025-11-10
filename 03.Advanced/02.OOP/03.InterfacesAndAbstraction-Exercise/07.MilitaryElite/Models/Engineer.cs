using MilitaryElite.Models.Abstract;
using MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string firstName, string lastName, int id, decimal salary, string corps, IReadOnlyCollection<IRepair> repairs) 
            : base(firstName, lastName, id, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs {get; private set;}

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}\nCorps: {Corps}");
            sb.AppendLine("Repairs:");

            foreach (IRepair repair in Repairs)
            {
                sb.AppendLine($" {repair.ToString()}");
            }

            return sb.ToString().Trim('\n');
        }
    }
}
