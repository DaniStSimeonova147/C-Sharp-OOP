using E04.PizzaCalories.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace E04.PizzaCalories.Models
{
   public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) ||value.Length > 15)
                {
                    throw new ArgumentException
                        (ExeptionMessage.InvalidPizzaNameExeption);
                }

                this.name = value;
            }
        }
        public Dough Dough
        {
            get
            {
                return this.dough;
            }
            private set
            {
                this.dough = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException
                    (ExeptionMessage.NumbersOfToppingsExeption);
            }

            this.toppings.Add(topping);
        }
        public override string ToString()
        {
            double callories = 0;

            callories += this.dough.Callories();
            foreach (var topping in toppings)
            {
                callories += topping.Callories();
            }

            return $"{this.Name} - {callories:f2} Calories.";
        }

    }
}
