using System;

namespace CardGames
{
    /**
     * Created by Group 7 (Spring 2021)
     * 
     * This class represents the Dealer object.
     * The Dealer is responsible for dealing cards to players and it also plays for itself.
     * The Dealer is a subclass of Player.
     */
    public class Dealer : Player
    {
        public Dealer(int id) : base(id)
        {
        }

        /**
         * This Deal method deals a card from the top of the deck to a given player.
         */
        public void Deal(Player player, Deck deck)
        {

            if (deck.GetDeck().Count != 0)
            {
                Card card = deck.GetDeck()[0];//deck.GetDeck().Pop();
                player.getHand().Add(card);
                deck.GetDeck().Remove(card);
            }
            else
            {
                Console.WriteLine("Deck is empty");
            }
        }

        /**
         * This ProposeHitOrStay method polls the user to see whether they want to receive anther card or stop.
         */
        public int ProposeHitOrStay(Player user)
        {
            Console.Write("Player : {0} \nHit(0) or Stand(1)?\n", user.GetId());
            int answer = Convert.ToInt32(Console.ReadLine());
            return answer;

        }

        /**
         * This Play method is the logic that controls the Dealer's turn.
         * If the dealer's score is less than 17 they will hit, otherwise they will stay.
         */
        public void Play(Deck deck)
        {
            Console.WriteLine("Dealer:");
            foreach (Card c in this.getHand())
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("Score: {0}\n", this.CalculateScore().ToString());

            while (CalculateScore() < 17)
            {
                Console.WriteLine("DEALER HITS!\n");

                Deal(this, deck);
                Console.WriteLine("Dealer:");
                foreach (Card c in this.getHand())
                {
                    Console.WriteLine(c.ToString());
                }
                Console.WriteLine("Score: {0}\n", this.CalculateScore().ToString());
            }
            Console.WriteLine("DEALER STAYS\n");
            return;
        }
    }
}