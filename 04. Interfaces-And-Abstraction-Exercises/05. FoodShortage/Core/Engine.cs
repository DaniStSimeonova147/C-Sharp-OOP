using System;
using System.Linq;
using System.Collections.Generic;

using E05.FoodShortage.Constraints;
using E05.FoodShortage.Models;

namespace E05.FoodShortage.Core
{
   public class Engine
    {
        private List<IBuyer> buyers;

        public Engine()
        {
            buyers = new List<IBuyer>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (tokens.Length == 3)
                {
                    string group = tokens[2];

                    Rebel rebel = new Rebel(name, age, group);

                    buyers.Add(rebel);
                }
                else if (tokens.Length == 4)
                {
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    buyers.Add(citizen);
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string name = command;

                if (buyers.FirstOrDefault(b => b.Name == name) != null)
                {
                    buyers.FirstOrDefault(b => b.Name == name).BuyFood();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
