using MilitaryElite.Models.Abstract;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : RegularSoldier, IPrivate
    {
        public Private(string firstName, string lastName, int id, decimal salary)
            : base(firstName, lastName, id, salary) { }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
        }
    }
}
