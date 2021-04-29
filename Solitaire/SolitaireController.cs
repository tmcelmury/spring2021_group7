﻿using System;
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
            if (gameTable.faceUp[row].Count != 0) return;
            if (gameTable.faceDown[row].Count == 0) return;
            Card c = gameTable.faceDown[row][0];
            gameTable.faceDown[row].Remove(c);
            gameTable.faceUp[row].Add(c);
        }

        // Moves a card from one column to another
        public void MoveCard(int source, int index, int destination)
        {
            if (source > 7 || destination > 7 || destination == 0) return;
            if (source > 0 && index >= gameTable.faceUp[source].Count) return;
            if ((gameTable.faceUp[source].Count != 0 && (gameTable.faceUp[destination].Count != 0)) || (source == 0 && gameTable.faceUpDeck.Count != 0 && (gameTable.faceUp[destination].Count != 0)))
            {
                if (source > 0)
                {
                    Card c = gameTable.faceUp[source][index];
                    Card lastInDest = gameTable.faceUp[destination][^1];
                    if (c.getColor() == lastInDest.getColor()) return;
                    if (c.getRank() != lastInDest.getRank() - 1) return;
                    int initialCount = gameTable.faceUp[source].Count;
                    for (int i = index; i < initialCount; i++)
                    {
                        Card newCard = gameTable.faceUp[source][index];
                        gameTable.faceUp[destination].Add(newCard);
                        gameTable.faceUp[source].Remove(newCard);
                    }
                    if (index != 0 || gameTable.faceDown[source].Count == 0) return;
                    StackFlip(source);
                }
                else
                {
                    if (gameTable.faceUpDeck.Count == 0) return;
                    Card c = gameTable.faceUpDeck.Peek();
                    Card lastInDest = gameTable.faceUp[destination][^1];
                    if (c.getColor() == lastInDest.getColor()) return;
                    if (c.getRank() != lastInDest.getRank() - 1) return;
                    gameTable.faceUp[destination].Add(gameTable.faceUpDeck.Pop());
                }
            }
            // King card can move to an empty column
            else
            {
                if (source > 0)
                {
                    int previous = gameTable.faceUp[destination].Count;
                    if (gameTable.faceUp[source][0].getType() != "King") return;
                    foreach (Card card in gameTable.faceUp[source].ToList())
                    {
                        gameTable.faceUp[destination].Add(card);
                    }

                    if (previous == gameTable.faceUp[destination].Count) return;
                    gameTable.faceUp[source].Clear();
                    StackFlip(source);
                }
                else
                {
                    if (gameTable.faceUpDeck.Count == 0) return;
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

        public void AceStacks(int source)
        {
            if (source > 0)
            {
                if (gameTable.faceUp[source].Count == 0) return;
                Card c = gameTable.faceUp[source][^1];
                if (c.getSuit() == "Hearts" && gameTable.heartAce.Count + 1 == c.getRank())
                {
                    gameTable.heartAce.Add(c);
                    gameTable.faceUp[source].Remove(c);
                }
                else if (c.getSuit() == "Diamonds" && gameTable.diamondAce.Count + 1 == c.getRank())
                {
                    gameTable.diamondAce.Add(c);
                    gameTable.faceUp[source].Remove(c);
                }
                else if (c.getSuit() == "Clubs" && gameTable.clubAce.Count + 1 == c.getRank())
                {
                    gameTable.clubAce.Add(c);
                    gameTable.faceUp[source].Remove(c);
                }
                else if (c.getSuit() == "Spades" && gameTable.spadeAce.Count + 1 == c.getRank())
                {
                    gameTable.spadeAce.Add(c);
                    gameTable.faceUp[source].Remove(c);
                }

                if (gameTable.faceUp[source].Count != 0 || gameTable.faceDown[source].Count == 0) return;
                StackFlip(source);
            }
            else
            {
                if (gameTable.faceUpDeck.Count == 0) return;
                Card c = gameTable.faceUpDeck.Peek();
                if (c.getSuit() == "Hearts" && gameTable.heartAce.Count + 1 == c.getRank())
                {
                    gameTable.heartAce.Add(gameTable.faceUpDeck.Pop());
                }
                else if (c.getSuit() == "Diamonds" && gameTable.diamondAce.Count + 1 == c.getRank())
                {
                    gameTable.diamondAce.Add(gameTable.faceUpDeck.Pop());
                }
                else if (c.getSuit() == "Clubs" && gameTable.clubAce.Count + 1 == c.getRank())
                {
                    gameTable.clubAce.Add(gameTable.faceUpDeck.Pop());
                }
                else if (c.getSuit() == "Spades" && gameTable.spadeAce.Count + 1 == c.getRank())
                {
                    gameTable.spadeAce.Add(gameTable.faceUpDeck.Pop());
                }
            }
        }

        public int GetCountFromColumn(int source)
        {
            return gameTable.faceUp[source].Count;
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
