namespace _01CardSuit
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Card Suits:");

            var suits = Enum.GetValues(typeof(CardSuits));

            foreach (var suit in suits)
            {
                Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
            }
        }
    }
}
