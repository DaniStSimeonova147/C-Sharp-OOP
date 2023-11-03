using E03.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.ShoppingSpree.Core
{
    public class Engine
    {
        private List<Person> persons;

        private List<Product> products;
        public Engine()
        {
            this.persons = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                ReadPersonsInput();
                ReadProductsInput();

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string personName = commandTokens[0];
                    string productName = commandTokens[1];

                    Person person = this.persons
                        .FirstOrDefault(p => p.Name == personName);

                    Product product = this.products
                        .FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        person.BuyProduct(product);

                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }

                   

                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, this.persons));
        }

        private void ReadProductsInput()
        {
            string[] productTokens = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var productToken in productTokens)
            {
                string[] productInfo = productToken.Split("=");

                string name = productInfo[0];
                decimal price = decimal.Parse(productInfo[1]);

                Product product = new Product(name, price);

                this.products.Add(product);
            }
        }

        private void ReadPersonsInput()
        {
            string[] personTokens = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var personToken in personTokens)
            {
                string[] personInfo = personToken.Split("=");

                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                Person person = new Person(name, money);

                this.persons.Add(person);
            }
        }
    }
}
