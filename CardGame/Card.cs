using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {

        private string suit;
        private int value;
        private string type;
        private int rank;
        private string color;

        public Card(string suit, string type, int value)
        {
            this.value = value;
            this.suit = suit;
            this.type = type;
            if (suit == "Clubs" || suit == "Spades")
            {
                this.color = "Black";
            }
            else
            {
                this.color = "Red";
            }
            if (value < 10)
            {
                rank = value;
            }
            else
                rank = type switch
                {
                    "10" => 10,
                    "Jack" => 11,
                    "Queen" => 12,
                    "King" => 13,
                    _ => rank
                };
        }
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
        }



    }

}
