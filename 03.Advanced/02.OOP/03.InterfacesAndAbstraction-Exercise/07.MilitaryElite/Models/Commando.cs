using MilitaryElite.Models.Abstract;
using MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    internal class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string firstName, string lastName, int id, decimal salary, string corps, IReadOnlyCollection<IMission> missions)
            : base(firstName, lastName, id, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}\nCorps: {Corps}");
            sb.AppendLine("Missions:");

            foreach (IMission mission in Missions)
            {
                sb.AppendLine($" {mission.ToString()}");
            }

            return sb.ToString().Trim('\n');
        }
    }
}
