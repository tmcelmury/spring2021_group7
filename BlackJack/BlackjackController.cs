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

<<<<<<< Updated upstream
        public Deck Deck { get => deck; set => deck = value; }
        public Dealer Dealer { get => dealer; set => dealer = value; }
        public List<Player> GetPlayers() { return this.players; }
        public void SetPlayers(List<Player> newList) { this.players = newList; }

        public bool Propose(Player user)
=======
        public Deck getDeck()
        {
            return this.deck;
        }
        public Dealer getDealer()
>>>>>>> Stashed changes
        {
            Console.Write("Player : %i \nHit(1) or Stand(0)?\n", user.getId());
            int answer = Console.Read();
            if (answer == 1) { return true; }
            else { return false; }
        }
<<<<<<< Updated upstream
        public Card Draw() {
            return this.deck.DrawCard();
        }
        public void BustPlayer(Player outPlayer) { players.Remove(outPlayer); }
=======
        public List<Player> GetPlayers()
        {
            return this.players;
        }
>>>>>>> Stashed changes

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
