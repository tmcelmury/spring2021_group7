using System;

namespace Solitaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOLITAIRE!\n");

            GameTable gameTable = new GameTable();
            while (true)
            {
                gameTable.Display();
                Console.WriteLine("\nMove(m) or flip(f)");
                string input = Console.ReadLine();
                if (input == "f")
                {
                    Console.WriteLine("\nPick row from 0-7");
                    int flipRow = Convert.ToInt32(Console.ReadLine());
                    if (flipRow == 0)
                    {
                        gameTable.DeckFlip();
                    }
                    else
                    {
                        gameTable.StackFlip(flipRow);
                    }
                }else if (input == "m")
                {
                    Console.WriteLine("\nPick source row from 0-7");
                    int source = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nPick destination row from 1-7");
                    int destination = Convert.ToInt32(Console.ReadLine());
                    gameTable.MoveCard(source, destination);
                }
                else
                {
                    Console.WriteLine("\nMove(m) or flip(f)");
                }
            }
        }
    }
}
