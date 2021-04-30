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
            Console.WriteLine("Solitaire(0) or Blackjack(1)?");
            string result = Console.ReadLine();
            if(result == "0")
            {
                game = new SolitaireController();
            } else if(result == "1")
            {
                game = new BlackjackController();
            } else
            {
                Console.WriteLine("Invalid Input!");
                return;
            }
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
