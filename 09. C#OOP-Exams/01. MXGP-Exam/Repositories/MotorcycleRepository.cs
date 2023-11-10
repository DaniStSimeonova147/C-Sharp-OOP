using System.Linq;
using System.Collections.Generic;

using MXGP.Repositories.Contracts;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            this.motorcycles.Add(model);
        }

        public bool Remove(IMotorcycle model)
        {
          return this.motorcycles.Remove(model);
        }
        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.motorcycles.ToList();
        }

        public IMotorcycle GetByName(string name)
        {
          return this.motorcycles.FirstOrDefault(m => m.Model == name);
        }

    }
}
