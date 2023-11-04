namespace E05.FoodShortage.Constraints
{
   public interface IBuyer
    {
        string Name { get; }

        int Age { get; }

        void BuyFood();

        int Food { get; }
    }
}
