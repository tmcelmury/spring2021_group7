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
     * This class is the controller for the Solitaire game logic.
     * This class handles the functionality for the Solitaire game operations and logic.
     * The SolitaireController has access to the GameTable.
     * This controller implements the IGame interface.
     */
    public class SolitaireController : IGame
    {
        GameTable gameTable = new GameTable();

        /**
         * This DeckFlip method gets the top card from the draw pile.
         * The method will cycle through the unused cards.
         */
        public void DeckFlip()
        {
            //in the case where the draw pile isn't empty
            if(gameTable.deck.GetDeck().Count != 0)
            {
                if(gameTable.onDeck == null)
                {
                    gameTable.onDeck = gameTable.deck.GetDeck()[0];
                } else
                {
                    //Make the card on top of the draw pile equal to the next card on the draw pile (cyclic list)
                    gameTable.onDeck = gameTable.deck.GetDeck()[(gameTable.deck.GetDeck().IndexOf(gameTable.onDeck) + 1) % gameTable.deck.GetDeck().Count];
                }
            }
        }

        /**
         * This StackFlip method reveals an upside-down card from the given pile.
         */
        public void StackFlip(int row)
        {
            if (gameTable.faceUp[row].Count != 0) return;
            if (gameTable.faceDown[row].Count == 0) return;
            Card c = gameTable.faceDown[row][0];
            gameTable.faceDown[row].Remove(c);
            gameTable.faceUp[row].Add(c);
        }

        /**
         * This MoveCard method moves a card/cards from one pile to another.
         */
        public void MoveCard(int source, int index, int destination)
        {
            if (source > 7 || destination > 7 || destination == 0) return;
            if (source > 0 && index >= gameTable.faceUp[source].Count) return;
            if ((gameTable.faceUp[source].Count != 0 && (gameTable.faceUp[destination].Count != 0)) || (source == 0 && gameTable.onDeck != null && (gameTable.faceUp[destination].Count != 0)))
            {
                if (source > 0)
                {
                    Card c = gameTable.faceUp[source][index];
                    Card lastInDest = gameTable.faceUp[destination][^1];
                    if (c.GetColor() == lastInDest.GetColor()) return;
                    if (c.GetRank() != lastInDest.GetRank() - 1) return;
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
                    if (gameTable.onDeck == null) return;
                    Card c = gameTable.onDeck;
                    Card lastInDest = gameTable.faceUp[destination][^1];
                    if (c.GetColor() == lastInDest.GetColor()) return;
                    if (c.GetRank() != lastInDest.GetRank() - 1) return;
                    Card drawnCard = gameTable.onDeck;
                    gameTable.deck.GetDeck().Remove(drawnCard);
                    gameTable.faceUp[destination].Add(drawnCard);
                }
            }
            // King card can move to an empty column
            else
            {
                if (source > 0)
                {
                    int previous = gameTable.faceUp[destination].Count;
                    if (gameTable.faceUp[source][0].GetType() != "King") return;
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
                    if (gameTable.onDeck == null) return;
                    Card card = gameTable.onDeck;

                    if (card.GetType() == "King")
                    {
                        gameTable.faceUp[destination].Add(card);
                        gameTable.deck.GetDeck().Remove(card);
                    }
                }
            }
            Display();
        }

        /**
         * This AceStacks methods handles the card moves onto the ace piles.
         */
        public void AceStacks(int source)
        {
            if (source > 0)
            {
                if (gameTable.faceUp[source].Count == 0) return;
                Card c = gameTable.faceUp[source][^1];
                if (c.GetSuit() == "Hearts" && gameTable.heartAce.Count + 1 == c.GetRank())
                {
                    gameTable.heartAce.Add(c);
                    gameTable.faceUp[source].Remove(c);
                }
                else if (c.GetSuit() == "Diamonds" && gameTable.diamondAce.Count + 1 == c.GetRank())
                {
                    gameTable.diamondAce.Add(c);
                    gameTable.faceUp[source].Remove(c);
                }
                else if (c.GetSuit() == "Clubs" && gameTable.clubAce.Count + 1 == c.GetRank())
                {
                    gameTable.clubAce.Add(c);
                    gameTable.faceUp[source].Remove(c);
                }
                else if (c.GetSuit() == "Spades" && gameTable.spadeAce.Count + 1 == c.GetRank())
                {
                    gameTable.spadeAce.Add(c);
                    gameTable.faceUp[source].Remove(c);
                }

                if (gameTable.faceUp[source].Count != 0 || gameTable.faceDown[source].Count == 0) return;
                StackFlip(source);
            }
            else
            {
                if (gameTable.onDeck == null) return;
                Card c = gameTable.onDeck;
                Card drawnCard;
                if (c.GetSuit() == "Hearts" && gameTable.heartAce.Count + 1 == c.GetRank())
                {
                    drawnCard = gameTable.onDeck;
                    gameTable.heartAce.Add(drawnCard);
                    gameTable.deck.GetDeck().Remove(drawnCard);
                }
                else if (c.GetSuit() == "Diamonds" && gameTable.diamondAce.Count + 1 == c.GetRank())
                {
                    drawnCard = gameTable.onDeck;
                    gameTable.diamondAce.Add(drawnCard);
                    gameTable.deck.GetDeck().Remove(drawnCard);
                }
                else if (c.GetSuit() == "Clubs" && gameTable.clubAce.Count + 1 == c.GetRank())
                {
                    drawnCard = gameTable.onDeck;
                    gameTable.clubAce.Add(drawnCard);
                    gameTable.deck.GetDeck().Remove(drawnCard);
                }
                else if (c.GetSuit() == "Spades" && gameTable.spadeAce.Count + 1 == c.GetRank())
                {
                    drawnCard = gameTable.onDeck;
                    gameTable.spadeAce.Add(drawnCard);
                    gameTable.deck.GetDeck().Remove(drawnCard);
                }
            }
            Display();
        }
    
        public int GetCountFromColumn(int source)
        {
            return gameTable.faceUp[source].Count;
        }


        /**
         * This Display method displays the state of the solitaire GameTable.
         */
        public void Display()
        {
            Console.Clear();
            // deck
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("0: ");
            if(gameTable.onDeck != null)
            {
                if(gameTable.onDeck.GetColor() == "Red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(gameTable.onDeck.GetDisplay());
            }
            Console.WriteLine();
            // rows
            for (int i = 1; i <= 7; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{i}: ");
                foreach (Card c in gameTable.faceDown[i])
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("X ");
                }
                foreach (Card c in gameTable.faceUp[i])
                {
                    if (c.GetColor() == "Red")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(c.GetDisplay());
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Hearts: ");
            foreach (Card c in gameTable.heartAce)
            {
                Console.Write(c.GetDisplay());
            }
            Console.WriteLine();
            Console.Write("Diamonds: ");
            foreach (Card c in gameTable.diamondAce)
            {
                Console.Write(c.GetDisplay());
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Clubs: ");
            foreach (Card c in gameTable.clubAce)
            {
                Console.Write(c.GetDisplay());
            }
            Console.WriteLine();
            Console.Write("Spades: ");
            foreach (Card c in gameTable.spadeAce)
            {
                Console.Write(c.GetDisplay());
            }
            Console.WriteLine();
        }

        /**
         * This Won method checks whether the player has won solitaire.
         * It returns True if the player has won, false otherwise.
         */
        public bool Won()
        {
            return (gameTable.clubAce.Count == 13 && gameTable.heartAce.Count == 13 && gameTable.diamondAce.Count == 13 && gameTable.spadeAce.Count == 13);
        }

        /**
         * This PlayGame method begins the game logic loop for Solitaire.
         */
        public void PlayGame()
        {
            Console.WriteLine("SOLITAIRE!\n");

            SolitaireController control = new SolitaireController();
            while (!Won())
            {
                control.Display();
                Console.WriteLine("\nMove(m) or flip(f) or ace(a)");
                string input = Console.ReadLine();
                if (input == "f" || input == "F")
                {
                    control.DeckFlip();
                }
                else if (input == "m" || input == "M")
                {
                    Console.WriteLine("\nPick source row from 0-7");
                    int source = Convert.ToInt32(Console.ReadLine());
                    int count = control.GetCountFromColumn(source);
                    int index = 0;
                    if (count > 1 && source != 0)
                    {
                        Console.WriteLine("\nPick which card to grab from 0-" + (count - 1));
                        index = Convert.ToInt32(Console.ReadLine());
                    }

                    Console.WriteLine("\nPick destination row from 1-7");
                    int destination = Convert.ToInt32(Console.ReadLine());
                    control.MoveCard(source, index, destination);
                }
                else if (input == "a")
                {
                    Console.WriteLine("\nPick source row from 0-7");
                    int source = Convert.ToInt32(Console.ReadLine());
                    control.AceStacks(source);
                }
                else
                {
                    Console.WriteLine("\nMove(m) or flip(f)");
                }
            }
        }
    }
}
