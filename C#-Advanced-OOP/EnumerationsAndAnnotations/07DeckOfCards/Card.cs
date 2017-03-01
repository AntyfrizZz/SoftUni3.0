namespace _07DeckOfCards
{
    public class Card
    {
        public Card(CardRanks cardRank, CardSuits cardSuit)
        {
            this.CardRank = cardRank;
            this.CardSuit = cardSuit;
        }

        public CardRanks CardRank { get; }

        public CardSuits CardSuit { get; }

        public override string ToString()
        {
            return $"{this.CardRank} of {this.CardSuit}";
        }
    }
}
