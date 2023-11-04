using System;
using System.Text;
using System.Collections.Generic;

using E06.Elite.Constraints;
using System.Linq;

namespace E06.Elite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;
        public Commando(int id, string firstName, string LastName, decimal salary, string corp) 
            : base(id, firstName, LastName, salary, corp)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();

        public void AddMission(IMission mission)
        {
            if (this.missions.Any(m => m.CodeName == mission.CodeName))
            {
                int index = this.missions.FindIndex(m => m.CodeName == mission.CodeName);
                this.missions[index].CompleteMission();
            }
            else
            {
                if (mission.State != null)
                {
                    this.missions.Add(mission);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mission in missions)
            {
                result.AppendLine(" " + mission.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
