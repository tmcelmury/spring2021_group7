using System;

namespace CardGames
{
    /**
     * Created by Group 7 (Spring 2021)
     * 
     * This is a driver for Solitaire.
     */
    class Program
    {
        public static IGame game;

        static void Main(string[] args)
        {
            //choose blackjack or solitaire based on UI button click

            //if blackjack
            IGame game = new BlackjackController();

            //if solitaire
            game = new SolitaireController();

            Play(game);
        }

        /**
         * This Play method begins the gameplay of the desired game.
         */
        public static void Play(IGame game)
        {
            game.PlayGame();
        }
    }
}
