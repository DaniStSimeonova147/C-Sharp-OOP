using System.Linq;
using System.Collections.Generic;

using MXGP.Repositories.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Repositories
{
   public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public bool Remove(IRider model)
        {
            return this.riders.Remove(model);
        }
        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.riders.ToList();
        }

        public IRider GetByName(string name)
        {
            return this.riders.FirstOrDefault(m => m.Name == name);
        }

    }
}
