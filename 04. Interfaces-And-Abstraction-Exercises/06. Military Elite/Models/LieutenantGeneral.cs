using System.Text;
using System.Collections.Generic;

using E06.Elite.Constraints;

namespace E06.Elite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<Private> privates;
        public LieutenantGeneral(int id, string firstName, string LastName, decimal salary) 
            : base(id, firstName, LastName, salary)
        {
            this.privates = new List<Private>();
        }

        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();

        public void AddPrivate(Private privateSoldier)
        {
            this.privates.Add(privateSoldier);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var person in this.Privates)
            {
                result.AppendLine(" " + person.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
