using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack;

namespace BlackJack
{
    class Hand
    {
        Cards[] hand;
        int totalPoints;
        private int getPoints()
        {
            //Needs to be implemented
        }
        private void getCard() { return hand; }
        public static void Shuffle(ref Cards[]Deck)
        {
            Random random = new Random();
            Cards card;
            int number;
        }
        private void add(Cards newCard)
        {
            // Needs to be implemented
        }
        private void remove(Cards discard)
        {
            // Needs to be implemented
        }
    }
}
