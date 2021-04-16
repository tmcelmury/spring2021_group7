using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public int value;
        public string suit;

        public Card(int value, string suit)
        {
            this.value = value;
            this.suit = suit;
<<<<<<< Updated upstream
=======
        }
        public Card(string suit, string type, int value)
        {
            this.value = value;
            this.suit = suit;
            this.type = type;
>>>>>>> Stashed changes
        }
        public int getValue() { return value; }
        public void setValue(int value){this.value = value;}
        public string getSuit() { return suit; }
        public void setSuit(string suit) { this.suit = suit; }

        


    }
    
}














