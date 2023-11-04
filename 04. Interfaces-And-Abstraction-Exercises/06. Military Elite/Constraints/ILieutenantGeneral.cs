using System.Collections.Generic;

namespace E06.Elite.Constraints
{
  public  interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
