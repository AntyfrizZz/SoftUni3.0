namespace _05CardCompareTo
{
    using System;
    public class Card : IComparable<Card>
    {
        public Card(CardRanks cardRank, CardSuits cardSuit)
        {
            this.CardRank = cardRank;
            this.CardSuit = cardSuit;
        }

        public CardRanks CardRank { get; }

        public CardSuits CardSuit { get; }

        public int Power => (int) this.CardRank + (int) this.CardSuit;

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override string ToString()
        {
            return $"Card name: {this.CardRank} of {this.CardSuit}; Card power: {this.Power}";
        }
    }
}
