using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    public class Table
    {
        private List<CardStack>  tableau;   // The seven stacks of cards
        private Stack<Card>[] foundation;   // The four stacks on top
        private Stack<Card>   talon;        // The drawn cards
        private Deck          stock;        // The deck cards are drawn from

        public List<CardStack> Tableau { get => tableau; set => tableau = value; }
        public Stack<Card>[] Foundation { get => foundation; set => foundation = value; }
        public Stack<Card> Talon { get => talon; set => talon = value; }
        public Deck Stock { get => stock; set => stock = value; }

        public Table ()
        {

        }

        
    }
}
