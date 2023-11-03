using E04.PizzaCalories.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace E04.PizzaCalories.Models
{
   public  class Topping
    {
        private const double BASE_CALLORIES_PER_GRAM = 2;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException
                        (string.Format(ExeptionMessage.InvalidToppingType, value));
                }

                this.type = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException
                        (string.Format(ExeptionMessage.InvalidToppingWeight, this.Type));
                }

                this.weight = value;
            }
        }

        public double Callories()
        {
            double modifier = BASE_CALLORIES_PER_GRAM;

            if (this.Type.ToLower() == "meat")
            {
                modifier *= 1.2;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                modifier *= 0.8;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                modifier *= 1.1;
            }
            else
            {
                modifier *= 0.9;
            }

            return modifier * this.Weight;
        }
    }
}
