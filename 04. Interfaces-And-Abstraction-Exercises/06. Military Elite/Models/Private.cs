using E06.Elite.Constraints;

namespace E06.Elite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string LastName, decimal salary) 
            : base(id, firstName, LastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get;private set; }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:f2}";
        }

    }
}
