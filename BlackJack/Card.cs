using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        public int value;
        public string suit;
        public int points;

        public int getValue() { return value; }
        private void setValue(int value){this.value = value;}
        private string getSuit() { return suit; }
        private void setSuit(string suit) { this.suit = suit; }
        private int getPoints() { return points; }
        private void setPoints(int points) { this.points = points; }

        public Card(int s, int v)
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
                points = 10;

            }
            else if (v == 1)
            {
                points = 11;
            }
            else
            {
                points = value;
            }
        }

        public static Card[] generator()
        {
            Card[] Deck = new Card[52];
            int counter = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 14; y++)
                {
                    Deck[counter] = new Card(x, y);
                    counter++;
                }
            }
            return Deck;

        }


    }
    
}














