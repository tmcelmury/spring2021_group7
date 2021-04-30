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
     * This class is the controller for the BlackJack game logic.
     * This class handles the functionality for the BlackJack game operations and logic.
     * The BlackJack controller has access to the list of players, the dealer, and the deck.
     * This class implements the IGame interface.
     */
    public class BlackjackController : IGame
    {
        private List<Player> players = new List<Player>();
        private Dealer dealer = new Dealer(0);
        private Deck deck = new Deck();

        public Deck GetDeck() { return this.deck; }

        public Dealer GetDealer() { return this.dealer; }

        public List<Player> GetPlayers() { return this.players; }


        /**
         * This CreatePlayers method initializes the list of Players for BlackJack.
         */
        public void CreatePlayers(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                Player newPlayer = new Player(i);
                this.players.Add(newPlayer);
            }
        }


        /**
         * This DetermineWinner method takes in a dictionary as a parameter.
         * The dictionary maps player id to their score.
         * The method uses this dictionary to determine the winner(s).
         * This method returns a list of Player IDs of the winner(s).
         */
        public List<int> DetermineWinner(Dictionary<int, int> scores)
        {

            List<int> finalWinners = new List<int>();

            //a list that shows which players busted
            List<bool> busted = new List<bool>();
            for (int i = 0; i < scores.Count; i++)
            {
                //initalize busted bool to false, update to true if score is > 21
                busted.Add(false);
                if (scores[i] > 21)
                {
                    busted[i] = true;
                }
            }

            //this is the case where everybody busted, the dealer is favored
            if (!busted.Any(o => o != busted[0]) && busted[0])
            {
                //Console.WriteLine("DEALER WINS!");
                finalWinners.Add(0);
                return finalWinners;
            }
            else
            {
                //take the score of everybody who did not bust
                var nonbusters = scores.Where(pair => pair.Value < 21).ToDictionary(x => x.Key, x => x.Value);
                //from the nonbusters select the highest score and the players with that score
                var winners = nonbusters.Where(pair => pair.Value == nonbusters.Values.Max()).Select(pair => pair.Key).ToList();

                //if the dealer is one of the players with the best score, dealer wins
                if (winners.Contains(0))
                {
                    //Console.WriteLine("DEALER WINS!");
                    finalWinners.Add(0);
                    return finalWinners;
                }
                else
                {
                    foreach (var winner in winners)
                    {
                        //Console.WriteLine("PLAYER {0} WINS!", winner);
                        finalWinners.Add(winner);
                    }
                    return finalWinners;
                }
            }
        }


        /**
         * The PlayGame method begins the game logic loop for BlackJack.
         */
        public void PlayGame()
        {
            //Console.WriteLine("Welcome to BlackJack!\n");
            //Console.WriteLine("How many players are there? (Max 6)\n");

            //int numPlayers = Convert.ToInt32(Console.ReadLine());
            int numPlayers = 6; //UI input;

            CreatePlayers(numPlayers);


            // begin the actual game, taking turns per round while there are still 1 or more players
            // in, and the dealer has not busted

            Deck deck = GetDeck();

            Dealer dealer = GetDealer();
            dealer.Deal(dealer, deck);

            foreach (Player p in GetPlayers())
            {
                //deal each player two cards to start.
                dealer.Deal(p, deck);
                dealer.Deal(p, deck);
            }

            //this list holds the players who haven't busted or chose to stand
            List<Player> activePlayers = new List<Player>(GetPlayers());

            //create and initalize a final scores list to find the winner
            Dictionary<int, int> finalScores = new Dictionary<int, int>();

            while (activePlayers.Count > 0)
            {

                for (int i = activePlayers.Count - 1; i >= 0; i--)
                {
                    Player player = activePlayers[i];
                    int answer = -1;
                    while (answer != 1)
                    {
                        Console.Clear();
                        foreach (Player p in GetPlayers())
                        {
                            Console.WriteLine("Player {0}", p.GetId().ToString());
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
                            finalScores.Add(player.GetId(), player.CalculateScore());
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
                DetermineWinner(finalScores);
                Console.ReadKey();
            }

            Console.WriteLine("GAME FINISHED");
        }

    }
}