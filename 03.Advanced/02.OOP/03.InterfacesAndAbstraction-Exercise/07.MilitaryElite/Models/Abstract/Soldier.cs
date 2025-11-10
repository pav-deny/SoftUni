using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models.Abstract
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string firstName, string lastName, int id)
        { 
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public int Id {get; private set;}
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
