using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    /**
     * Created by Group 7 (Spring 2021)
     * 
     * This class models a card object from a standard 52-card deck.
     */
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
        public string GetSuit() { return suit; }

        public new string GetType() { return type; }

        public int GetRank() { return rank; }

        public string GetColor() { return color; }

        public int GetValue() { return this.value; }

        public string GetDisplay() { return this.type + this.suit[0] + " " ; }

        override
        public string ToString() { return this.type + " of " + this.suit; }
    }

}
