namespace _08CardGame
{
    using System;
    public class Card : IComparable<Card>
    {
        public Card(CardRanks rank, CardSuits suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public CardRanks Rank { get; }

        public CardSuits Suit { get; }

        public int Power => (int) this.Rank + (int) this.Suit;





        public override bool Equals(object obj)
        {
            var other = obj as Card;

            if (this.Suit != other?.Suit)
            {
                return false;
            }

            return this.Rank == other?.Rank;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + this.Rank.GetHashCode();
            hash = (hash * 7) + this.Suit.GetHashCode();

            return hash;
        }

        public int CompareTo(Card other)
        {
            var result = (int) this.Suit.CompareTo((int)other.Suit);

            if (result == 0)
            {
                result = (int)this.Rank.CompareTo((int)other.Rank);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
        }
    }
}
