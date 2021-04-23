using System;

namespace Solitaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOLITAIRE!\n");

            GameTable gameTable = new GameTable();
            gameTable.Display();
        }
    }
}
