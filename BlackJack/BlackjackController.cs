using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack;

namespace BlackJack
{
    public class BlackjackController{
        private List<Player> players = new List<Player>();
        private Dealer dealer = new Dealer();
        private Deck deck = new Deck();

        public Deck Deck { get => deck; set => deck = value; }
        public Dealer Dealer { get => dealer; set => dealer = value; }
        public List<Player> GetPlayers() { return this.players; }

        private bool Propose(Player user)
        {
            Console.Write("Player : %i \nHit(1) or Stand(0)?\n", user.getId());
            int answer = Console.Read();
            if (answer == 1) { return true; }
            else { return false; }
        }
        private Card Draw() {
            return this.deck.DrawCard();
        }
        private void BustPlayer(Player outPlayer) { players.Remove(outPlayer); }

        public void CreatePlayers(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Player newPlayer = new Player();
                newPlayer.setId(i);
                this.players.Add(newPlayer);
            }
        }

    }
}
