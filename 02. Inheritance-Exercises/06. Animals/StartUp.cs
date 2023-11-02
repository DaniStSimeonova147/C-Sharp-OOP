using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();

            string currentAnimal = Console.ReadLine();

            while (currentAnimal != "Beast!")
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = input[0];
                int age = int.Parse(input[1]);
                string gender = input[2];

                try
                {
                    switch (currentAnimal)
                    {
                        case "Cat":
                            animals.Add(new Cats.Cat(name, age, gender));
                            break;
                        case "Kitten":
                            animals.Add(new Cats.Kitten(name, age));
                            break;
                        case "Tomcat":
                            animals.Add(new Cats.Tomcat(name, age));
                            break;
                        case "Dog":
                            animals.Add(new Dogs.Dog(name, age, gender));
                            break;
                        case "Frog":
                            animals.Add(new Frogs.Frog(name, age, gender));
                            break;

                        default:
                            break;
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                currentAnimal = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(string.Join(" ", animal));
            }
        }
    }
}
