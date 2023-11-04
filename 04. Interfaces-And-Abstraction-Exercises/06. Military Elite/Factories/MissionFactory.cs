using E06.Elite.Models;

namespace E06.Elite.Factories
{
    public class MissionFactory
    {
        public Mission MakeMission(string codeName, string state)
        {
            Mission mission = new Mission(codeName, state);

            return mission;
        }
    }
}
