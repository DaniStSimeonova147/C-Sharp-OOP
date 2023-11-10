using System;
using System.Linq;
using System.Collections.Generic;

using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private const int MIN_SYMBOLS_FOR_NAME = 5;

        private string name;
        private int laps;

        private readonly List<IRider> riders;

        public Race(string name, int laps)
        {
            this.riders = new List<IRider>();

            this.Name = name;
            this.Laps = laps;
        }
      public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_SYMBOLS_FOR_NAME)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MIN_SYMBOLS_FOR_NAME));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < 1 )
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, value));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders
            => this.riders.AsReadOnly();


        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(nameof(rider), ExceptionMessages.RiderInvalid);
            }
            if (rider.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }
            if (this.riders.Any(x => x.Name == rider.Name))
            {
                throw new ArgumentNullException(string.Format(nameof(rider), ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
