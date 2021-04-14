using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class BlackjackController{
        private Player[] players;
        private dealer = new Dealer;
        private deck = new Deck;


        private Player[] getPlayers() { return players; }
        private Dealer GetDealer() { return dealer; }
        private void setDealer(Dealer dealer) { this.dealer = dealer}
        private Deck getDeck() { return getDeck; }
        private void setDeck(Deck deck) { this.deck = deck; }


        public Player createPlayer(int id, Hand hand)
        {
            newPlayer = new Player;
            newPlayer.setId(id);
            newPlayer.setHand(hand);
        }
        public Hand drawHand()
        {
            this.getDeck().shuffleDraw()
        }
        public void generatePlayers(int numPlayers)
        {
            this.players = new Player[numPlayers];
            for(int i = 0; i < numPlayers; i++)
            {
                newPlayer = new Player;
                newPlayer.setId(i);
                newPlayer.setHand(this.drawHand());
                this.players[i] = newPlayer;
            }
        }
        public void static hit(Player player, Deck deck) 
        { 
            //give the player a random card from deck
        }
        public void static bustPlayer(Player player) 
        {
        // remove the player
        }
        
    }
}
