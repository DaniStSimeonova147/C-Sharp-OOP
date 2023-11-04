using System.Collections.Generic;

namespace E06.Elite.Constraints
{
    interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
