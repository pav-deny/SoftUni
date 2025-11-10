using MilitaryElite.Models.Abstract;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, int id, int codeNumber) 
            : base(firstName, lastName, id)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber {get; private set;}

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Code Number: {CodeNumber}";
        }
    }
}
