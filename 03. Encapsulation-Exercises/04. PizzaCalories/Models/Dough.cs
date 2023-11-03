using E04.PizzaCalories.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace E04.PizzaCalories
{
   public  class Dough
    {
        private const double baseCalloriesPerGram = 2.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;


        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException
                        (ExeptionMessage.InvalidTypeOfDough);
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException
                        (ExeptionMessage.InvalidTypeOfDough);
                }

                this.bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException
                        (ExeptionMessage.InvalidDoughWeight);
                }

                this.weight = value;
            }
        }

        public double  Callories()
        {
            double modifier = baseCalloriesPerGram;

            if (this.FlourType.ToLower() == "white")
            {
                modifier *= 1.5;
            }
            else
            {
                modifier *= 1.0;
            }

            if (this.BakingTechnique.ToLower() == "crispy")
            {
                modifier *= 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                modifier *= 1.1;
            }
            else
            {
                modifier *= 1.0;
            }

            return modifier * this.Weight;
        }
    }
}
