namespace _03CardPower
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

        public int Power => (int) this.CardRank + (int) this.CardSuit;

        public override string ToString()
        {
            return $"Card name: {this.CardRank} of {this.CardSuit}; Card power: {this.Power}";
        }
    }
}
