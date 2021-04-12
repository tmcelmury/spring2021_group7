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
        public string Suit;
        public int point;
        public Cards(int s, int v)
        {
            v = value;
            switch (s)
            {
                case 1: // If s == 1, then set the Suit to Clubs
                    Suit = "♣";
                    break;
                case 2: // If s == 2, then set the Suit to Diamonds
                    Suit = "♦";
                    break;
                case 3: // If s == 3, then set the Suit to Hearts
                    Suit = "♥";
                    break;
                case 4: // If s == 4, then set the Suit to Spades
                    Suit = "♠";
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














