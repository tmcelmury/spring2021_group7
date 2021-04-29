using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class BlackjackController
    {
        private List<Player> players = new List<Player>();
        private Dealer dealer = new Dealer();
        private Deck deck = new Deck();

        public Deck getDeck()
        {
            return this.deck;
        }

        public Dealer getDealer()

        {
            return this.dealer;
        }

        public List<Player> GetPlayers()
        {
            return this.players;
        }


        public void CreatePlayers(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                Player newPlayer = new Player();
                newPlayer.setId(i);
                this.players.Add(newPlayer);
            }
        }


        public List<int> DetermineWinner(Dictionary<int, int> scores)
        {
            //a list for the players determined to be winners
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
                Console.WriteLine("DEALER WINS!");
                finalWinners.Add(0);
                return finalWinners;
            }

            //select all players who have a blackjack (21 points)
            var blackjacks = scores.Where(pair => pair.Value == 21).Select(pair => pair.Key).ToList();
            if (blackjacks.Count != 0)
            {
                //if the dealer is one of the players with blackjack, dealer wins
                if (blackjacks.Contains(0))
                {
                    Console.WriteLine("DEALER WINS!");
                    finalWinners.Add(0);
                    return finalWinners;
                }
                else
                {
                    //if dealer doesn't have blackjack, those who do, have won
                    foreach (int id in blackjacks)
                    {
                        Console.WriteLine("PLAYER {0} WINS!", id);
                        finalWinners.Add(id);
                    }
                    return finalWinners;
                }
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
                    Console.WriteLine("DEALER WINS!");
                    finalWinners.Add(0);
                    return finalWinners;
                }
                else
                {
                    foreach (var winner in winners)
                    {
                        Console.WriteLine("PLAYER {0} WINS!", winner);
                        finalWinners.Add(winner);
                    }
                    return finalWinners;
                }
            }
        }

    }
}
