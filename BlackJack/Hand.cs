using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack;

namespace BlackJack
{
    public class Hand
    {
        List<Card> hand;
        int totalPoints;

        public Hand()
        {
            this.hand = new List<Card>();
        }

        private int getPoints()
        {
            //Needs to be implemented
            return 0;
        }
        private void getCard() { return; }
        public static void Shuffle(ref Card[]Deck)
        {
            Random random = new Random();
            Card card;
            int number;
        }
        public void add(Card newCard)
        {
            // Needs to be implemented
            this.hand.Add(newCard);
            // adjust points depending on card value
        }
        private void remove(Card discard)
        {
            // Needs to be implemented
        }

        public List<Card> getHand()
        {
            return this.hand;
        }

    }
}
