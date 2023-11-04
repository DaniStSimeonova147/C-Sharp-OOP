using E02.FerrariCar.Constraints;

namespace E02.FerrariCar.Models
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Model { get; private set; }

        public string Driver { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Driver}";
        }
    }
}
