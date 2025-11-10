namespace MilitaryElite.Models.Interfaces
{
    public interface ISpecializedSoldier : IPrivate
    {
        string Corps { get; } //Airforces, Marines
    }
}
