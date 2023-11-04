using System;
using System.Text;

using E06.Elite.Constraints;

namespace E06.Elite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corp;
        public SpecialisedSoldier(int id, string firstName, string LastName, decimal salary, string corp) 
            : base(id, firstName, LastName, salary)
        {
            this.Corp = corp;
        }

        public string Corp
        {
            get
            {
                return this.corp;
            }
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid corp!");
                }

                this.corp = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corp}");

            return result.ToString().TrimEnd();
        }
    }
}
