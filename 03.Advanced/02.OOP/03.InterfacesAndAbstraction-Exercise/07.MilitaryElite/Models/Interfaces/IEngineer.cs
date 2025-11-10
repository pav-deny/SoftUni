using System.Collections.Generic;

namespace MilitaryElite.Models.Interfaces
{
    public interface IEngineer : ISpecializedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
