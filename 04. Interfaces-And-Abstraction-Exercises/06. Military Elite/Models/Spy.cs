using System.Text;

using E06.Elite.Constraints;

namespace E06.Elite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string LastName, int codeNumber)
            : base(id, firstName, LastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine($"Code Number: {this.CodeNumber}");

            return result.ToString().TrimEnd();
        }
    }
}
