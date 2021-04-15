using System;
using System.Collections.Generic;
using BlackJack;

namespace BlackJack
{
    public class Program
    {
        public static void Main()
        {
            // create controller object
            BlackjackController control = new BlackjackController();

            // initialize and shuffle the deck
            control.Deck.InitializeDeck();

            // begin user interaction
            Console.WriteLine("Welcome to BlackJack!\n");
            Console.WriteLine("How many players are there? (Max 6)\n");
            int numPlayers = Console.Read();

            // generate the appropriate number of Player objects
            control.CreatePlayers(numPlayers);

            //finish setup of game, drawing two cards to every player, and the dealer
            Console.WriteLine("Dealing...\n\n");
            for (int i = 0; i < numPlayers; i++)
            {
                List<Card> initialHand = control.Deck.DealHand();
                control.GetPlayers()[i].Hit(initialHand[0]);
                control.GetPlayers()[i].Hit(initialHand[1]);
            }
            List<Card> initialHand = control.Deck.DealHand();
            control.Dealer.Hit(initialHand[0]);
            control.Dealer.Hit(initialHand[1]);

            // begin the actual game, taking turns per round while there are still more than 1 player 
            // in, and the dealer has not busted
            while (control.GetPlayers().Capacity > 1 && !control.Dealer.Bust())
            {
                List<Player> players = control.GetPlayers();    // retrieve the list of players
                // print out the state of the game, dealer on top, then players from player 1 to n below

                // ask players to go one at a time
                for (int i = 0; i < players.Capacity(); i++)
                {
                    bool draw = control.Propose(players[i]);
                    if (draw)
                    {
                        Card newCard = control.Draw();
                        players[i].Hit(newCard);
                    }
                }

                // dealer has chance to draw
                control.Dealer.PlayTurn();

                // check if players bust, if they do, remove them from the game
                for (int i = 0; i < players.Capacity(); i++)
                {
                   if (players[i].Bust())
                    {
                        control.BustPlayer(players[i]);
                        i--;
                        numPlayers--;
                    }
                }
            }

            if (control.Dealer.Bust())
            {
                Console.WriteLine("All remaining players Win!");
            }
            else
            {
                Console.WriteLine("Player %i Wins!", control.GetPlayers()[0].getId());
            }

        }
    }
}
