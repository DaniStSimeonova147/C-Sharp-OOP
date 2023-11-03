using E05.FootballTeamGenerator.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace E05.FootballTeamGenerator.Models
{
    public class Stat
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                ValidateStat(value, nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                ValidateStat(value, nameof(this.Sprint));

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                ValidateStat(value, nameof(this.Dribble));

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            set
            {
                ValidateStat(value, nameof(this.Passing));

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.passing;
            }
            private set
            {
                ValidateStat(value, nameof(this.Shooting));

                this.shooting = value;
            }
        }

        public int SumTotalStats()
        {
            
              int sum = this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting;

            return sum;
            
        }

        private void ValidateStat(int value, string name)
        {
            if (value < MinStatValue || value > MaxStatValue)
            {
                throw new AggregateException
                    (string.Format(ExeptionMessages.InvalidStatExeption, name, MinStatValue, MaxStatValue));
            }
        }
    }
}
