using System;

using MXGP.Utilities.Messages;
using MXGP.Models.Riders.Contracts;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private const int MIN_SYMBOLS_FOR_NAME = 5;

        private string name;

        public Rider(string name)
        {
            this.Name = name;
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


        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(nameof(motorcycle), ExceptionMessages.MotorcycleInvalid);
            }

            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
