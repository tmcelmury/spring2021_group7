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
            control.getDeck().InitializeDeck();

            // begin user interaction
            Console.WriteLine("Welcome to BlackJack!\n");
            Console.WriteLine("How many players are there? (Max 6)\n");
            int numPlayers = Console.Read();

            // generate the appropriate number of Player objects
            control.CreatePlayers(numPlayers);
<<<<<<< Updated upstream

            //finish setup of game, drawing two cards to every player, and the dealer
            Console.WriteLine("Dealing...\n\n");
            for (int i = 0; i < numPlayers; i++)
            {
                List<Card> initialHand = control.Deck.DealHand();
                control.GetPlayers()[i].Hit(initialHand[0]);
                control.GetPlayers()[i].Hit(initialHand[1]);
            }
            control.Dealer.PlayTurn();

            // begin the actual game, taking turns per round while there are still more than 1 player 
            // in, and the dealer has not busted
            while (control.GetPlayers().Capacity > 1 && !control.Dealer.Bust())
            {
                List<Player> players = control.GetPlayers();    // retrieve the list of players
                // print out the state of the game, dealer on top, then players from player 1 to n below

                // ask players to go one at a time
                for (int i = 0; i < players.Capacity; i++)
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
                for (int i = 0; i < players.Capacity; i++)
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

=======
        

            // begin the actual game, taking turns per round while there are still more than 1 player 
            // in, and the dealer has not busted
            
            Deck deck = control.getDeck();

            Dealer dealer = control.getDealer();
            dealer.Deal(dealer, deck);

            foreach (Player p in control.GetPlayers())
            {
                dealer.Deal(p, deck);
                dealer.Deal(p, deck);
            }

            //this list holds the players who haven't busted or chose to stand
            List<Player> activePlayers = new List<Player>(control.GetPlayers());

            //create and initalize a final scores list to find the winner
            Dictionary<int,int> finalScores = new Dictionary<int, int>();

            while (activePlayers.Count > 1)
            {

                for (int i = activePlayers.Count - 1; i >= 0; i--)
                {
                    Player player = activePlayers[i];
                    int answer = -1;
                    while(answer != 1)
                    {
                        Console.Clear();
                        foreach (Player p in control.GetPlayers())
                        {
                            Console.WriteLine("Player {0}", p.getId().ToString());
                            foreach (Card c in p.getHand())
                            {
                                Console.WriteLine(c.ToString());
                            }
                            Console.WriteLine("Score: {0}\n", p.CalculateScore().ToString());
                        }

                        if (!(player.CalculateScore() > 21))
                        {
                            answer = dealer.ProposeHitOrStay(player);
                        }
                        if(answer == 0 && !(player.CalculateScore() > 21))
                        {
                            dealer.Deal(player, deck);
                        } else
                        {
                            finalScores.Add(player.getId(), player.CalculateScore());
                            activePlayers.RemoveAt(i);
                            break;
                        }
                    }
                }

                dealer.Play(deck);
                finalScores.Add(0, dealer.CalculateScore());
                Console.Write("FINAL SCORES:\nDEALER: {0}\t", finalScores[0]);

                for (int i = 1; i < finalScores.Count; i++)
                {
                    Console.Write("PLAYER {0}: {1}\t", i, finalScores[i]);
                }
                Console.WriteLine("\n");
                control.DetermineWinner(finalScores);
                Console.ReadKey();
            }
            
            Console.WriteLine("GAME FINISHED");
>>>>>>> Stashed changes
        }
    }
}
