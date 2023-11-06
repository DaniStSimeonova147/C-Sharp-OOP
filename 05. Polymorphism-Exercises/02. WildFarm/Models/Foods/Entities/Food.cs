using E03.WildFarm.Models.Foods.Contracts;

namespace E03.WildFarm.Models.Foods.Entities
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
