using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {

        public Suit suit { get; set; }
        public int value { get; set; }
        public Face rank { get; set; }
        public Color color { get; set; }

        public Card(Suit suit, Face rank)
        {
            this.suit = suit;
            this.rank = rank;
            if (this.suit == Suit.clubs || this.suit == Suit.spades)
            {
                color = Color.black;
            }
            else { color = Color.red; }
            
            if (rank == Face.jack || rank == Face.queen || rank == Face.king) { value = 10; }
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
        }
        /*
        public string getSuit() { return suit; }

        public string getType() { return type; }

        public int getRank() { return rank; }

        public string getColor() { return color; }

        override
        public string ToString()
        {
            return this.type + " of " + this.suit;
        }

        public int getValue()
        {
            return this.value;
        }

        public string getDisplay()
        {
            return this.type + this.suit[0] + " ";
        }

        public string getPngDisplay()
        {
            if (this.type == "10")
            {
                return "10" + this.suit[0];
            }
            else
            {
                return this.type[0].ToString() + this.suit[0];
            }
        } */



    }

}
