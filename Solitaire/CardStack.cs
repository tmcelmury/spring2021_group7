using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    public class CardStack
    {
        private List<Card>  cards;
        private Stack<Card> fdCards;  // Face down cards

        public List<Card> Cards { get => cards; set => cards = value; }
        public Stack<Card> FdCards { get => fdCards; set => fdCards = value; }

        public CardStack()
        {
            this.Cards = new List<Card>();
            this.FdCards = new Stack<Card>();
        }

        public void AddFDCard(Card c)
        {

        }
    }
}
