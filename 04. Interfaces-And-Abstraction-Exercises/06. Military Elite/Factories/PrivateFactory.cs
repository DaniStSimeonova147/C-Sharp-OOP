using E06.Elite.Models;

namespace E06.Elite.Factories
{
   public class PrivateFactory
    {
        public Private MakePrivateSoldier(string[] args)
        {
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);

            Private privateSoldier = new Private(id, firstName, lastName, salary);

            return privateSoldier;
        }
    }
}
