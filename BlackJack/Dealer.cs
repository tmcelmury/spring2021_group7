using System;
using BlackJack;

namespace BlackJack
{
    public class Dealer : Player
    {
        public void Deal(Player player, Deck deck)
        {

            if (deck.getDeck().Count != 0)
            {
                Card card = deck.getDeck().Pop();
                player.getHand().Add(card);
            }
            else
            {
                Console.WriteLine("Deck is empty");
            }
        }

        public int ProposeHitOrStay(Player user)
        {
            Console.Write("Player : {0} \nHit(0) or Stand(1)?\n", user.getId());
            int answer = Convert.ToInt32(Console.ReadLine());
            return answer;

        }

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
