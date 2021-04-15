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
        
        public int getValue() { return value; }
        public void setValue(int value){this.value = value;}
        public string getSuit() { return suit; }
        public void setSuit(string suit) { this.suit = suit; }

        


    }
    
}














