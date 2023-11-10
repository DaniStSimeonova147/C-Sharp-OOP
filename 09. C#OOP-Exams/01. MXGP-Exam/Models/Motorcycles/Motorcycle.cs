using System;

using MXGP.Utilities.Messages;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private const int MIN_SYMBOLS_FOR_MODEL = 4;
        private string model;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_SYMBOLS_FOR_MODEL)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MIN_SYMBOLS_FOR_MODEL));
                }

                this.model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public  double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
