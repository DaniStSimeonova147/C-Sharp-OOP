﻿using E03.WildFarm.Models.Foods.Entities;
using System;
using System.Collections.Generic;

namespace E03.WildFarm.Models.Animals.Entities
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        protected override List<Type> PrefferedFoodTypes =>
            new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 0.40;

        public override string AskFood()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
