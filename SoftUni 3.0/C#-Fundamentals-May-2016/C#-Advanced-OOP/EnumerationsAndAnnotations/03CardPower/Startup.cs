namespace _03CardPower
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var cardRank = (CardRanks)Enum.Parse(typeof(CardRanks), Console.ReadLine());
            var cardSuit = (CardSuits)Enum.Parse(typeof(CardSuits), Console.ReadLine());

            var card = new Card(cardRank, cardSuit);

            Console.WriteLine(card);
        }
    }
}
