namespace _08CardGame
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var deck = new Deck();

            var firstPersonName = Console.ReadLine();
            var firstPerson = new Person(firstPersonName);

            var secondPersonName = Console.ReadLine();
            var secondPerson =new Person(secondPersonName);

            while (firstPerson.CardsCount != 5 || secondPerson.CardsCount != 5)
            {
                var currentPerson = firstPerson;

                if (firstPerson.CardsCount == 5)
                {
                    currentPerson = secondPerson;
                }

                var cardInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var cardRank = (CardRanks)Enum.Parse(typeof(CardRanks), cardInfo[0]);
                    var cardSuit = (CardSuits)Enum.Parse(typeof(CardSuits), cardInfo[2]);
                    var card = new Card(cardRank, cardSuit);

                    if (deck.ContainsCard(card))
                    {
                        deck.RemoveCard(card);
                        currentPerson.AddCard(card);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            Console.WriteLine(
                firstPerson.CompareTo(secondPerson) > 0 
                ? firstPerson : secondPerson);
        }
    }
}
