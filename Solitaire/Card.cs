using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    public class Card
    {
        private string suit;
        private int value;
        private string type;

        public Card(string suit, string type, int value)
        {
            this.value = value;
            this.suit = suit;
            this.type = type;
        }
        public string getSuit() { return suit; }

        public string getType() { return type; }

        override
        public String ToString()
        {
            return this.type + " of " + this.suit;
        }

        public int getValue()
        {
            return this.value;
        }

        public string getDisplay()
        {
            return this.type + this.suit[0] + " " ;
        }



    }

}
