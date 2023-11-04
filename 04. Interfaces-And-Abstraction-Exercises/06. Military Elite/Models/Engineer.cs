using System.Text;
using System.Collections.Generic;

using E06.Elite.Constraints;

namespace E06.Elite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;
        public Engineer(int id, string firstName, string LastName, decimal salary, string corp) 
            : base(id, firstName, LastName, salary, corp)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs.AsReadOnly();

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (var repair in repairs)
            {
                result.AppendLine(" " + repair.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
