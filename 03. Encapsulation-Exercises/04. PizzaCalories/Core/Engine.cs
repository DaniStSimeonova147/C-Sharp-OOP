using E04.PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E04.PizzaCalories.Core
{
   public class Engine
    {
        public void Run()
        {
            try
            {
                string[] inputPizza = Console.ReadLine().Split();

                string pizzaName = inputPizza[1];

                string[] inputDough = Console.ReadLine().Split();

                string flour = inputDough[1];
                string backeType = inputDough[2];
                double weight = double.Parse(inputDough[3]);

                Dough dough = new Dough(flour, backeType, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string line = Console.ReadLine();

                while (line != "END")
                {
                    string[] inputTopping = line.Split();

                    string type = inputTopping[1];
                    double weightTopping = double.Parse(inputTopping[2]);

                    Topping topping = new Topping(type, weightTopping);

                    pizza.AddTopping(topping);

                    line = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
        }
    }
}
