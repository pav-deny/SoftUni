using MilitaryElite.Models.Abstract;
using MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : RegularSoldier, ILieutenantGeneral
    {
        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary, IReadOnlyCollection<IPrivate> privates) 
            : base(firstName, lastName, id, salary) 
        { 
            this.Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates {get; private set;}

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine("Privates:");

            foreach (IPrivate priv in Privates)
            {
                sb.AppendLine($" {priv.ToString()}");
            }

            return sb.ToString().Trim('\n');
        }
    }
}
