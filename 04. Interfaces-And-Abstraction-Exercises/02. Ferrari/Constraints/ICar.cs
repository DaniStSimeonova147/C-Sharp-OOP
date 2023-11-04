namespace E02.FerrariCar.Constraints
{
   public interface ICar
    {
        string Model { get; }

        string Driver { get; }

        string Gas();

        string Brakes();
    }
}
