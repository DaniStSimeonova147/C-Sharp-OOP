using System;

using E02.FerrariCar.Constraints;
using E02.FerrariCar.Models;

namespace E02.FerrariCar
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            string driver = Console.ReadLine();

            ICar car = new Ferrari(driver);

            Console.WriteLine(car.ToString());
        }
    }
}
