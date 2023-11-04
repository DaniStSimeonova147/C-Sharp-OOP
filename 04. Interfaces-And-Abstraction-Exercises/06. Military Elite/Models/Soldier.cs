using E06.Elite.Constraints;

namespace E06.Elite.Models
{
    public class Soldier : ISoldier
    {
        public Soldier(int id, string firstName, string LastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = LastName;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
