namespace _05CardCompareTo
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var firstCardRank = (CardRanks)Enum.Parse(typeof(CardRanks), Console.ReadLine());
            var firstCardSuit = (CardSuits)Enum.Parse(typeof(CardSuits), Console.ReadLine());
            var firstCard = new Card(firstCardRank, firstCardSuit);

            var secondCardRank = (CardRanks)Enum.Parse(typeof(CardRanks), Console.ReadLine());
            var secondCardSuit = (CardSuits)Enum.Parse(typeof(CardSuits), Console.ReadLine());
            var secondCard = new Card(secondCardRank, secondCardSuit);

            if (firstCard.CompareTo(secondCard) > 0)
            {
                Console.WriteLine(firstCard);
            }
            else if (firstCard.CompareTo(secondCard) < 0)
            {
                Console.WriteLine(secondCard);
            }
            else
            {
                Console.WriteLine(secondCard);
            }
        }
    }
}
