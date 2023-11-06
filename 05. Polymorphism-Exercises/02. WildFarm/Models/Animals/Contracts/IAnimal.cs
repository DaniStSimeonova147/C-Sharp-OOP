using E03.WildFarm.Models.Foods.Contracts;

namespace E03.WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string AskFood();

        void Feed(IFood food);
    }
}
