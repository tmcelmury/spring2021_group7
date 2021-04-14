using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Cards
    {
        public int value;
        public string suit;
        public int points;

        private int getValue() { return value; }
        private void setValue(int value){ this.value = value; }
        private char getSuit() { return suit; }
        private void setSuit(string suit) { this.suit = suit; }
        private int getPoints() { return points; }
        private void setPoints(int points) { this.points = points; }

        public Cards(int s, int v)
        {
            v = value;
            switch (s)
            {
                case 1: // If s == 1, then set the suit to Clubs
                    suit = "♣";
                    break;
                case 2: // If s == 2, then set the suit to Diamonds
                    suit = "♦";
                    break;
                case 3: // If s == 3, then set the suit to Hearts
                    suit = "♥";
                    break;
                case 4: // If s == 4, then set the suit to Spades
                    suit = "♠";
                    break;
            }
            if (v > 10)
            {
                point = 10;

            }
            else if (v == 1)
            {
                point = 11;
            }
            else
            {
                point = value;
            }
        }

        public static Cards[] generator()
        {
            Cards[] Deck = new Cards[52];
            int counter = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 14; y++)
                {
                    Deck[counter] = new Cards(x, y);
                    counter++;
                }
            }
            return Deck;

        }




    }
    
}














