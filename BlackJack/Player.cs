using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player
    {
        private List<Card> hand = new List<card>();
        private int id;

        public int GetId() { return id; }
        public void SetId(int id) { this.id = id; }

        public void Hit(Card card)
        {
            this.hand.Add(card);
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
            // 0 = Ace 1 0r 11 
            // 1 = 2 2
            // 2 = 3 3
            // 3 = 4 4
            // 4 = 5 5
            // 5 = 6 6 
            // 6 = 7 7
            // 7 = 8 8 
            // 8 = 9 9
            // 9 = 10 10 
            // 10 = J 10
            // 11 = Q 10 
            // 12 = K 10
            int points = 0;
            foreach(Card card in this.hand)
            {
                points += GetPoints(card,false);
            }
            if (points > 21 && ContainsAce(this.hand))
            {
                points = 0;
                foreach (Card card in this.hand)
                {
                    points += GetPoints(card, true);
                }
            }
            return points;
        }
        private int GetPoints(Card card, bool aceOne=false)
        {
            int points = 0;
            if (card.getValue() == 0)
            {
                if (aceOne)
                {
                    points += 1;
                }
                else
                {
                    points += 11;
                }
            }
            else if (card.getValue() >= 1 && card.getValue() <= 9)
            {
                points += card.getValue()+1;
            }
            else
            {
                points += 10;
            }
            return points;
        }
        private bool ContainsAce(List<Card> hand)
        {
            foreach(Card card in hand)
            {
                if(card.getValue() == 0)
                {
                    return true;
                }
            }
                return false;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }
    }
}
