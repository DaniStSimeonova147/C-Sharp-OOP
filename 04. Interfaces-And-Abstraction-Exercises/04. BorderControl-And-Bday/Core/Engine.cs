using System;
using System.Linq;
using System.Collections.Generic;

using E04.BorderControl.Models;
using E04.BorderControl.Constraints;

namespace E04.BorderControl.Core
{
   public class Engine
    {
        private List<IBirthable> entereds;

        public Engine()
        {
            entereds = new List<IBirthable>();
        }
        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] tokens = line.Split();

                string type = tokens[0];
                string name = tokens[1];

                if (type == "Citizen")
                {
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthdate = tokens[4];

                    Citizen citizen = new Citizen(name, age, id, birthdate);

                    entereds.Add(citizen);
                }
                else if (type == "Pet")
                {
                    string birthdate = tokens[2];

                    Pet pet = new Pet(name, birthdate);

                    entereds.Add(pet);
                }
                

                line = Console.ReadLine();
            }

            string code = Console.ReadLine();

            foreach (var item in entereds.Where(e => e.Birthdate.EndsWith(code)))
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}
