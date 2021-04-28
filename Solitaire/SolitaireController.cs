using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire
{
    public class SolitaireController
    {
        GameTable gameTable = new GameTable();

        // Flips the deck
        public void DeckFlip()
        {
            if (gameTable.deck.Count != 0)
            {
                Card c = gameTable.deck.Pop();
                gameTable.faceUpDeck.Push(c);
            }
            else
            {
                Console.WriteLine("Deck is empty");
            }
        }

        // Flips a card from face down to up
        public void StackFlip(int row)
        {
            if (gameTable.faceDown[row].Count != 0)
            {
                Card c = gameTable.faceDown[row][0];
                gameTable.faceDown[row].Remove(c);
                gameTable.faceUp[row].Add(c);
            }
        }

        // Moves a card from one column to another
        public void MoveCard(int source, int destination)
        {
            if (gameTable.faceUp[source].Count != 0 && (gameTable.faceDown[destination].Count + gameTable.faceUp[destination].Count != 0))
            {
                if (source > 0)
                {
                    int previous = gameTable.faceUp[destination].Count;
                    foreach (Card c in gameTable.faceUp[source].ToList())
                    {
                        //if (c.getValue() + 1 == faceUp[destination][faceUp[destination].Count - 1].getValue())
                        gameTable.faceUp[destination].Add(c);
                    }
                    if (previous != gameTable.faceUp[destination].Count)
                    {
                        gameTable.faceUp[source].Clear();
                        StackFlip(source);
                    }
                }
                else
                {
                    if (gameTable.faceUpDeck.Count != 0)
                    {
                        Card c = gameTable.faceUpDeck.Pop();
                        gameTable.faceUp[destination].Add(c);
                    }
                }
            }
            // King card can move to an empty column
            else
            {
                if (source > 0)
                {
                    int previous = gameTable.faceUp[destination].Count;
                    if (gameTable.faceUp[source][0].getType() == "King")
                    {
                        foreach (Card card in gameTable.faceUp[source].ToList())
                        {
                            gameTable.faceUp[destination].Add(card);
                        }
                        if (previous != gameTable.faceUp[destination].Count)
                        {
                            gameTable.faceUp[source].Clear();
                            StackFlip(source);
                        }
                    }
                }
                else
                {
                    if (gameTable.faceUpDeck.Count != 0)
                    {
                        Card card = gameTable.faceUpDeck.Pop();
                        if (card.getType() == "King")
                        {
                            gameTable.faceUp[destination].Add(card);
                        }
                        else
                        {
                            gameTable.faceUpDeck.Push(card);
                        }
                    }
                }
            }
        }

        public void AceStacks(int source)
        {
            if (source > 0)
            {
                if (gameTable.faceUp[source].Count != 0)
                {
                    foreach (Card c in gameTable.faceUp[source].ToList())
                    {
                        if (c.getSuit() == "Hearts")
                        {
                            gameTable.heartAce.Add(c);
                        }
                        else if (c.getSuit() == "Diamonds")
                        {
                            gameTable.diamondAce.Add(c);
                        }
                        else if (c.getSuit() == "Clubs")
                        {
                            gameTable.clubAce.Add(c);
                        }
                        else if (c.getSuit() == "Spades")
                        {
                            gameTable.spadeAce.Add(c);
                        }
                    }
                    gameTable.faceUp[source].Clear();
                }
            }
            else
            {
                if (gameTable.faceUpDeck.Count != 0)
                {
                    Card c = gameTable.faceUpDeck.Pop();
                    if (c.getSuit() == "Hearts")
                    {
                        gameTable.heartAce.Add(c);
                    }
                    else if (c.getSuit() == "Diamonds")
                    {
                        gameTable.diamondAce.Add(c);
                    }
                    else if (c.getSuit() == "Clubs")
                    {
                        gameTable.clubAce.Add(c);
                    }
                    else if (c.getSuit() == "Spades")
                    {
                        gameTable.spadeAce.Add(c);
                    }
                }
            }
        }

        // Displays for testing
        public void Display()
        {
            // deck
            Console.Write("0: ");
            foreach (Card c in gameTable.faceUpDeck)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            // rows
            for (int i = 1; i <= 7; i++)
            {
                Console.Write($"{i} ");
                foreach (Card c in gameTable.faceDown[i])
                {
                    Console.Write("X ");
                }
                foreach (Card c in gameTable.faceUp[i])
                {
                    Console.Write(c.getDisplay());
                }
                Console.WriteLine();
            }
            Console.Write("Hearts: ");
            foreach (Card c in gameTable.heartAce)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("Diamonds: ");
            foreach (Card c in gameTable.diamondAce)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("Clubs: ");
            foreach (Card c in gameTable.clubAce)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();
            Console.Write("Spades: ");
            foreach (Card c in gameTable.spadeAce)
            {
                Console.Write(c.getDisplay());
            }
            Console.WriteLine();

        }
    }
}
