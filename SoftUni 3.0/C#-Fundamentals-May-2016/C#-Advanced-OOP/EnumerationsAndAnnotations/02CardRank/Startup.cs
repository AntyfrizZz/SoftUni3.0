namespace _02CardRank
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Card Ranks:");

            var ranks = Enum.GetValues(typeof(CardRanks));

            foreach (var rank in ranks)
            {
                Console.WriteLine($"Ordinal value: {(int)rank}; Name value: {rank}");
            }
        }
    }
}
