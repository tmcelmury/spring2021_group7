using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        private Hand hand;
        private int id;
        //private int number;
        private int points = 0;

        public int GetId() { return id; }
        public void SetId(int id) { this.id = id; }

        public void Hit(Card card)
        {
            //TODO: needs method to add cards to hand
           // hand.add(card);
        }
        public bool Bust()
        {
           if (this.Points() > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Points()
        {

            //TODO: needs a way to see cards in hand or should points be in hand?
            //int points = 0;
            foreach(Card card in this.hand.getHand())
            {
                this.points += card.getValue();
            }
            //foreach (Cards card in this.hand.cards)
            //{
            //    points += card.point;
            //}
            //return points;
            return 10;
        }
    }
}
