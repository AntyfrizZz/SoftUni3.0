namespace _07DeckOfCards
{
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var result = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    var suit = (CardSuits)i;
                    var rank = (CardRanks)j;

                    var card = new Card(rank, suit);
                    result.AppendLine(card.ToString());
                }
            }

            System.Console.Write(result);
        }
    }
}
