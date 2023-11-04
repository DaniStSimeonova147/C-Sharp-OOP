using System.Collections.Generic;

namespace E06.Elite.Constraints
{
    interface ICommando : ISpecialisedSoldier
    { 
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
