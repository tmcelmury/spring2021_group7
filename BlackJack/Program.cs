using System;
using System.Collections.Generic;
using BlackJack;

namespace BlackJack
{
    public class Program
    {
        public static void Main()
        {
            BlackjackController control = new BlackjackController();

            Console.WriteLine("Welcome to BlackJack!\n");
            Console.WriteLine("How many players are there? (Max 6)\n");
            int numPlayers = Convert.ToInt32(Console.ReadLine());

            control.CreatePlayers(numPlayers);

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
            Dictionary<int, int> finalScores = new Dictionary<int, int>();

            while (activePlayers.Count > 1)
            {

                for (int i = activePlayers.Count - 1; i >= 0; i--)
                {
                    Player player = activePlayers[i];
                    int answer = -1;
                    while (answer != 1)
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
                        if (answer == 0 && !(player.CalculateScore() > 21))
                        {
                            dealer.Deal(player, deck);
                        }
                        else
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


            }

            Console.WriteLine("GAME FINISHED");
        }
    }
}