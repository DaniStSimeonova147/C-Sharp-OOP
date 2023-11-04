using System;

using E03.Telephony.Exceptions;
using E03.Telephony.Models;

namespace E03.Telephony.Core
{
    public class Engine
    {
        private Smartphone smartphone;
        public Engine()
        {
            this.smartphone = new Smartphone();
        }

        public void Run()
        {
            string[] numbers = Console.ReadLine().Split();

            string[] urls = Console.ReadLine().Split();

            CallNumbers(numbers);
            BrowseInternet(urls);
        }
        private void CallNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Cal(number));
                }
                catch (InvalidNumberException ine)
                {
                    Console.WriteLine(ine.Message);
                }

            }
        }

        private void BrowseInternet(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (InvalidUrlException iue)
                {
                    Console.WriteLine(iue.Message);
                }

            }
        }

    }
}
