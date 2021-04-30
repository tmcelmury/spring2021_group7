using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    /**
     * Created by Group 7 (Spring 2021)
     * 
     * This class models a Player object.
     * A player has a list of cards (hand) and an ID.
     */
    public class Player
    {
        private List<Card> hand;
        private int id;

        public Player(int id)
        {
            this.hand = new List<Card>();
            this.id = id;
        }
        public int GetId() { return id; }

        /**
         * This Busted method determines whether or not a player has "busted".
         * It returns true if the player has busted, false otherwise.
         */
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

        /**
         * This CalculateScore method calculates and returns the player's score.
         */
        public int CalculateScore()
        {
            int points = 0;
            bool hasAce = false;
            foreach (Card card in this.hand)
            {
                int cardValue = card.GetValue();


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

        /**
         * This AddCardToHand method adds a card to the player's hand.
         */
        public void AddCardToHand(Card card)
        {
            this.hand.Add(card);
        }

        public List<Card> getHand() { return this.hand; }
    }
}