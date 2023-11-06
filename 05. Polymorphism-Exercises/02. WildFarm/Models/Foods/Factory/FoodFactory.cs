using E03.WildFarm.Models.Foods.Contracts;
using E03.WildFarm.Models.Foods.Entities;
using System;

namespace E03.WildFarm.Models.Foods.Factory
{
   public class FoodFactory
    {
        public IFood ProduceFood(string type, int quantity)
        {
            IFood food;

            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new InvalidCastException
                    ("Invalid food type!");
            }

            return food;
        }
    }
}
