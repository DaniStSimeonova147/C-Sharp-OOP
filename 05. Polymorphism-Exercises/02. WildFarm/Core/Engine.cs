using E03.WildFarm.Models.Animals.Contracts;
using E03.WildFarm.Models.Animals.Entities;
using E03.WildFarm.Models.Foods.Contracts;
using E03.WildFarm.Models.Foods.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace E03.WildFarm.Core
{
   public class Engine
    {
        private List<Animal> animals;
        private FoodFactory FoodFactory;
        public Engine()
        {
            this.animals = new List<Animal>();
            this.FoodFactory = new FoodFactory();
        }

        public void Run()
        {
            string command = Console.ReadLine();


            while (command != "End")
            {
                string foodInput = Console.ReadLine();

                IAnimal animal = GetAnimal(command);

                IFood food = GetFood(foodInput);

                Console.WriteLine(animal.AskFood());
                try
                {
                    animal.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private IFood GetFood(string foodInput)
        {
            string[] foodTokens = foodInput.Split();

            string foodType = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            IFood food = this.FoodFactory.ProduceFood(foodType, quantity);

            return food;
        }

        private Animal GetAnimal(string command)
        {
            string[] animalTokens = command.Split();

            string type = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]);

            Animal animal;

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalTokens[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalTokens[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else 
            {
                string livingRegion = animalTokens[3];

                if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    string breed = animalTokens[4];

                    if (type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                    else
                    {
                        throw new InvalidOperationException
                            ("Invalid animal type!");
                    }
                }

            }
                this.animals.Add(animal);

                return animal;
        }
    }
}
