using System;
using BlackJack;

public class Program
{
	public static void Main()
    {
        BlackjackController control = new BlackjackController();

        Console.WriteLine("Welcome to BlackJack!\n");
        Console.WriteLine("How many players are there? (Max 6)\n");
        int numPlayers = Console.Read();

        control.CreatePlayers(numPlayers);

        //finish setup of game

        while (control.Players.get().Capacity() > 1 && !control.Dealer.Bust())
        {
            // print out the state of the game, dealer on top, then players from player 1 to n below

            // ask players to go one at a time

            // dealer has chance to draw

            // check if players bust
            for (int i = 0; i < numPlayers; i++)
            {

            }
        }
    }
}
