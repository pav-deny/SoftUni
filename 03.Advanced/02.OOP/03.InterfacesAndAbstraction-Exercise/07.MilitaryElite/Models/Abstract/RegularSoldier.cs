namespace MilitaryElite.Models.Abstract
{
    public abstract class RegularSoldier : Soldier
    {
        protected RegularSoldier(string firstName, string lastName, int id, decimal salary) 
            : base(firstName, lastName, id) 
        { 
            Salary = salary;
        }
        
        public decimal Salary { get;  private set; }
    }
}
