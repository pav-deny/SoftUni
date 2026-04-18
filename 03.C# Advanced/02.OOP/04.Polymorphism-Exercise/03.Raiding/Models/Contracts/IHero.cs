namespace Raiding.Models.Contracts
{
    public interface IHero
    {
        string Name { get; }
        int Power { get; }

        abstract string CastAbility();
    }
}
