using E05.FootballTeamGenerator.Exeptions;
using System;
namespace E05.FootballTeamGenerator.Models
{
   public class Player
    {
        private string name;
        private Stat stats;
        public Player(string name, Stat stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException
                        (ExeptionMessages.EmptyNameExeption);
                }
                this.name = value;
            }
        }

        public Stat Stats
        {
            get
            {
                return this.stats;
            }
            private set
            {
                this.stats = value;
            }
        }
        public double AvarageStat => this.Stats.SumTotalStats() / 5.0;
    }
}
