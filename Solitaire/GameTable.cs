﻿using System;
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

        public List<Card> heartAce = new List<Card>();
        public List<Card> clubAce = new List<Card>();
        public List<Card> spadeAce = new List<Card>();
        public List<Card> diamondAce = new List<Card>();

        public List<List<Card>> faceUp = new List<List<Card>>();
        public List<List<Card>> faceDown = new List<List<Card>>();


        public GameTable()
        {
            for (int i = 0; i <= 7; i++)
            {
                faceUp.Add(new List<Card>());
                faceDown.Add(new List<Card>());
            }
            deck = new Deck().getDeck();
            faceUp[1].Add(deck.Pop());
            faceUp[2].Add(deck.Pop());
            faceDown[2].Add(deck.Pop());
            faceUp[3].Add(deck.Pop());
            for (int i = 0; i < 2; i++)
            {
                faceDown[3].Add(deck.Pop());
            }
            faceUp[4].Add(deck.Pop());
            for (int i = 0; i < 3; i++)
            {
                faceDown[4].Add(deck.Pop());
            }
            faceUp[5].Add(deck.Pop());
            for (int i = 0; i < 4; i++)
            {
                faceDown[5].Add(deck.Pop());
            }
            faceUp[6].Add(deck.Pop());
            for (int i = 0; i < 5; i++)
            {
                faceDown[6].Add(deck.Pop());
            }
            faceUp[7].Add(deck.Pop());
            for (int i = 0; i < 6; i++)
            {
                faceDown[7].Add(deck.Pop());
            }
        }
        // Flips the deck
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

        // Flips a card from face down to up
        public void StackFlip(int row)
        {
            if (faceDown[row].Count != 0)
            {
                Card c = faceDown[row][0];
                faceDown[row].Remove(c);
                faceUp[row].Add(c);
            }
        }

        // Moves a card from one column to another
        public void MoveCard(int source, int destination)
        {
            if (faceUp[source].Count != 0 && (faceDown[destination].Count + faceUp[destination].Count != 0))
            {
                if (source > 0)
                {
                    int previous = faceUp[destination].Count;
                    foreach (Card c in faceUp[source].ToList())
                    {
                        //if (c.getValue() + 1 == faceUp[destination][faceUp[destination].Count - 1].getValue())
                        faceUp[destination].Add(c);
                    }
                    if (previous != faceUp[destination].Count)
                    {
                        faceUp[source].Clear();
                        StackFlip(source);
                    }
                }
                else
                {
                    if (faceUpDeck.Count != 0)
                    {
                        Card c = faceUpDeck.Pop();
                        faceUp[destination].Add(c);
                    }
                }
            }
            // King card can move to an empty column
            else
            {
                if (source > 0)
                {
                    int previous = faceUp[destination].Count;
                    if (faceUp[source][0].getType() == "King")
                    {
                        foreach (Card card in faceUp[source].ToList())
                        {
                            faceUp[destination].Add(card);
                        }
                        if (previous != faceUp[destination].Count)
                        {
                            faceUp[source].Clear();
                            StackFlip(source);
                        }
                    }
                }
                else
                {
                    if (faceUpDeck.Count != 0)
                    {
                        Card card = faceUpDeck.Pop();
                        if (card.getType() == "King")
                        {
                            faceUp[destination].Add(card);
                        }
                        else
                        {
                            faceUpDeck.Push(card);
                        }
                    }
                }
            }
        }
        
        public void AceStacks(int source)
        {
            if (source > 0)
            {
                if (faceUp[source].Count != 0)
                {
                    foreach (Card c in faceUp[source].ToList())
                    {
                        if (c.getSuit() == "Hearts")
                        {
                            heartAce.Add(c);
                        }
                        else if (c.getSuit() == "Diamonds")
                        {
                            diamondAce.Add(c);
                        }
                        else if (c.getSuit() == "Clubs")
                        {
                            clubAce.Add(c);
                        }
                        else if (c.getSuit() == "Spades")
                        {
                            spadeAce.Add(c);
                        }
                    }
                    faceUp[source].Clear();
                }
            }
            else
            {
                if (faceUpDeck.Count != 0)
                {
                    Card c = faceUpDeck.Pop();
                    if (c.getSuit() == "Hearts")
                    {
                        heartAce.Add(c);
                    }
                    else if (c.getSuit() == "Diamonds")
                    {
                        diamondAce.Add(c);
                    }
                    else if (c.getSuit() == "Clubs")
                    {
                        clubAce.Add(c);
                    }
                    else if (c.getSuit() == "Spades")
                    {
                        spadeAce.Add(c);
                    }
                }
            }
        }

        // Displays for testing
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
            for (int i = 1; i <= 7; i++)
            {
                Console.Write($"{i}: ");
                foreach (Card c in faceDown[i])
                {
                    Console.Write("X ");
                }
                foreach (Card c in faceUp[i])
                {
                    Console.Write(c.getDisplay());
                }
                Console.WriteLine();
            }
            Console.Write("Hearts: ");
            foreach (Card c in heartAce)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("Diamonds: ");
            foreach (Card c in diamondAce)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("Clubs: ");
            foreach (Card c in clubAce)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("Spades: ");
            foreach (Card c in spadeAce)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();

        }
    }
}
