using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        private List<Card> hand;
        private int id;

        public Player()
        {
            this.hand = new List<Card>();
        }
        public int GetId() { return id; }
        public void SetId(int id) { this.id = id; }

        public bool Busted()
        {
            if (this.CalculateScore() > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CalculateScore()
        {
            int points = 0;
            bool hasAce = false;
            foreach (Card card in this.hand)
            {
                int cardValue = card.getValue();


                //if their is a card with value 1 (ace) in hand
                //and the player doesn't already have an ace
                //then the ace will be treated as an 11 and hasAce is updated
                if (cardValue == 1 && !hasAce)
                {
                    hasAce = true;
                    cardValue = 11;
                }
                points += cardValue;

                //if we have an ace and have busted
                //we revert the ace back to 1 point in an attempt to "unbust"
                if (points > 21 && hasAce)
                {
                    points -= 10;
                    hasAce = false;
                }
            }
            return points;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void AddCardToHand(Card card)
        {
            this.hand.Add(card);
        }

        public List<Card> getHand()
        {
            return this.hand;
        }
    }
}
