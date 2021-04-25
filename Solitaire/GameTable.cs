using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    public class GameTable
    {
        public Stack<Card> deck = new Stack<Card>();
        public Stack<Card> faceUpDeck = new Stack<Card>();

        // game board rows
        public List<Card> faceUp1 = new List<Card>();
        public List<Card> faceUp2 = new List<Card>();
        public List<Card> faceDown2 = new List<Card>();
        public List<Card> faceUp3 = new List<Card>();
        public List<Card> faceDown3 = new List<Card>();
        public List<Card> faceUp4 = new List<Card>();
        public List<Card> faceDown4 = new List<Card>();
        public List<Card> faceUp5 = new List<Card>();
        public List<Card> faceDown5 = new List<Card>();
        public List<Card> faceUp6 = new List<Card>();
        public List<Card> faceDown6 = new List<Card>();
        public List<Card> faceUp7 = new List<Card>();
        public List<Card> faceDown7 = new List<Card>();
        public List<Card> heartAce = new List<Card>();
        public List<Card> clubAce = new List<Card>();
        public List<Card> spadeAce = new List<Card>();
        public List<Card> diamondAce = new List<Card>();

        //public List<List<Card>> faceUp = new List<List<Card>>();
        //public List<List<Card>> faceDown = new List<List<Card>>();


        public GameTable()
        {
            //for (int i = 0; i < 7; i++)
            //{
            //    faceUp[i] = new List<Card>();
            //    faceDown[i] = new List<Card>();
            //}
            deck = new Deck().getDeck();
            faceUp1.Add(deck.Pop());
            faceUp2.Add(deck.Pop());
            faceDown2.Add(deck.Pop());
            faceUp3.Add(deck.Pop());
            for (int i = 0; i < 2; i++){
                faceDown3.Add(deck.Pop());
            }
            faceUp4.Add(deck.Pop());
            for (int i = 0; i < 3; i++)
            {
                faceDown4.Add(deck.Pop());
            }
            faceUp5.Add(deck.Pop());
            for (int i = 0; i < 4; i++)
            {
                faceDown5.Add(deck.Pop());
            }
            faceUp6.Add(deck.Pop());
            for (int i = 0; i < 5; i++)
            {
                faceDown6.Add(deck.Pop());
            }
            faceUp7.Add(deck.Pop());
            for (int i = 0; i < 6; i++)
            {
                faceDown7.Add(deck.Pop());
            }
        }
        // displays the rows
        // Xs's are blank cards
        public void DeckFlip()
        {
            if (deck.Count != 0)
            {
                Card c = deck.Pop();
                faceUpDeck.Push(c);
            }
            else
            {
                Console.WriteLine("Deck is empty");
            }
        }

        public void StackFlip(int row)
        {
            if (row == 2)
            {
                if (faceDown2.Count != 0)
                {
                    Card c = faceDown2[0];
                    faceDown2.Remove(c);
                    faceUp2.Add(c);
                }
            }
        }
        public void Display()
        {
            // deck
            Console.Write("0: ");
            foreach (Card c in faceUpDeck)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            // rows
            Console.Write("1: ");
            foreach (Card c in faceUp1)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("2: ");
            foreach (Card c in faceDown2)
            {
                Console.Write("x ");
            }
            foreach (Card c in faceUp2)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("3: ");
            foreach (Card c in faceDown3)
            {
                Console.Write("x ");
            }
            foreach (Card c in faceUp3)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("4: ");
            foreach (Card c in faceDown4)
            {
                Console.Write("x ");
            }
            foreach (Card c in faceUp4)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("5: ");
            foreach (Card c in faceDown5)
            {
                Console.Write("x ");
            }
            foreach (Card c in faceUp5)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("6: ");
            foreach (Card c in faceDown6)
            {
                Console.Write("x ");
            }
            foreach (Card c in faceUp6)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("7: ");
            foreach (Card c in faceDown7)
            {
                Console.Write("x ");
            }
            foreach (Card c in faceUp7)
            {
                Console.Write(c.getDisplay());
            }
        }
    }

}
