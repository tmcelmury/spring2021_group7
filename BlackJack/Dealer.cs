using System;
using BlackJack;

namespace BlackJack
{
    public class Dealer : Player
    {
        // The "Hole" card is the card at the beginning of the game that the other players can not see
        private Card hole;
        private bool holeRevealed = false;



        public bool HoleRevealed
        {
            get => holeRevealed;
            set => holeRevealed = value;
        }

        public Card Hole
        {
            get => hole;
            set => hole = value;
        }


        /*
        public void PlayTurn()
        {
            if (this.Points() == 0)
            {
                // TODO: Waiting on Deck implementation
                // this.Hit(Deck.ShuffleDraw());
                this.DrawHole();
                return;
            }

            if (this.HoleRevealed == false)
            {
                this.HoleRevealed = true;
            }

            if (this.Points() < 17)
            {
                // TODO: Waiting on Deck implementation
                // this.Hit(Deck.ShuffleDraw());
            }
            else
            {
                // Stand
                return;
            }
        }
        */

        public void DrawHole(Card card)
        {
            this.Hole = card;
        }

        public void RevealHole()
        {
            this.Hit(this.Hole);
            this.HoleRevealed = true;
        }
    }
}

