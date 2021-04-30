using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        public Suit suit { get; set; }    // suit
        public int value { get; set; }  // blackjack value
        public Face rank { get; set; }   // face value
        public Color color { get; set; }    // keeps track of color

        // card constructor
        public Card(Suit suit, Face rank)
        {
            this.suit = suit;
            this.rank = rank;

            if (rank == Face.jack || rank == Face.queen || rank == Face.king)
            {
                value = 10;
            }
            else
            {
                switch (rank)
                {
                    case Face.ace:
                        value = 1;
                        break;
                    case Face.two:
                        value = 2;
                        break;
                    case Face.three:
                        value = 3;
                        break;
                    case Face.four:
                        value = 4;
                        break;
                    case Face.five:
                        value = 5;
                        break;
                    case Face.six:
                        value = 6;
                        break;
                    case Face.seven:
                        value = 7;
                        break;
                    case Face.eight:
                        value = 8;
                        break;
                    case Face.nine:
                        value = 9;
                        break;
                    case Face.ten:
                        value = 10;
                        break;
                }
            }

            if (this.suit.Equals(Suit.clubs) || this.suit.Equals(Suit.spades)) 
            {
                color = Color.black; 
            }
            else { color = Color.red; }
        }


        /*
        public Suit getSuit() { return this.suit; }

        override
        public String ToString()    // used to print card name
        {
            return this.rank + " of " + this.suit;
        }

        public Face getRank() { return ; }

        public int getValue() { return this.value; }
        public Color getColor()
        {
            if(this.suit.Equals(Suit.clubs) || this.suit.Equals(Suit.spades)) { return Color.black; }
            else { return Color.red; }
        } */
        
    }

}
