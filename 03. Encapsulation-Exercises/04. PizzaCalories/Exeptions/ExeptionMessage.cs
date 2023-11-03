namespace E04.PizzaCalories.Exeptions
{
   public static class ExeptionMessage
    {
        public static string InvalidTypeOfDough = 
            "Invalid type of dough.";

        public static string InvalidDoughWeight =
            "Dough weight should be in the range [1..200].";

        public static string InvalidToppingType =
            "Cannot place {0} on top of your pizza.";

        public static string InvalidToppingWeight =
            "{0} weight should be in the range [1..50].";

        public static string InvalidPizzaNameExeption =
            "Pizza name should be between 1 and 15 symbols.";

        public static string NumbersOfToppingsExeption =
            "Number of toppings should be in range [0..10].";
    }
}
