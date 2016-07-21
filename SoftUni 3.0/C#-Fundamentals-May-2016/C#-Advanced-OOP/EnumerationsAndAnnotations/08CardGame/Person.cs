namespace _08CardGame
{
    using System;
    using System.Collections.Generic;

    public class Person : IComparable<Person>
    {
        private string name;
        private List<Card> cards;

        public Person(string name)
        {
            this.name = name;
            this.cards = new List<Card>();
        }

        public int CardsCount => this.cards.Count;

        public Card HighestPowerCard { get; private set; }

        public void AddCard(Card card)
        {
            this.cards.Add(card);

            if (this.HighestPowerCard == null)
            {
                this.HighestPowerCard = card;
            }
            else if (card.Power > this.HighestPowerCard.Power)
            {
                this.HighestPowerCard = card;
            }
        }

        public int CompareTo(Person other)
        {
            return this.HighestPowerCard.Power.CompareTo(other.HighestPowerCard.Power);
        }

        public override string ToString()
        {
            return $"{this.name} wins with {this.HighestPowerCard}.";
        }
    }
}
