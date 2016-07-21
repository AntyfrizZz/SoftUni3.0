namespace _08CardGame
{
    using System.Collections.Generic;

    public class Deck
    {
        private HashSet<Card> deck;

        public Deck()
        {
            this.deck = new HashSet<Card>();

            for (int i = 0; i < 40; i += 13)
            {
                for (int j = 2; j < 15; j++)
                {
                    var suit = (CardSuits)i;
                    var rank = (CardRanks)j;

                    var card = new Card(rank, suit);

                    this.deck.Add(card);
                }
            }
        }

        public bool ContainsCard(Card card)
        {
            return this.deck.Contains(card);
        }

        public void RemoveCard(Card card)
        {
            this.deck.Remove(card);
        }
    }
}
