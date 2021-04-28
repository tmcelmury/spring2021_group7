using System;

namespace Solitaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SOLITAIRE!\n");

            SolitaireController control = new SolitaireController();
            while (true)
            {
                control.Display();
                Console.WriteLine("\nMove(m) or flip(f) or ace(a)");
                string input = Console.ReadLine();
                if (input == "f")
                {
                    Console.WriteLine("\nPick row from 0-7");
                    int flipRow = Convert.ToInt32(Console.ReadLine());
                    if (flipRow == 0)
                    {
                        control.DeckFlip();
                    }
                    else
                    {
                        control.StackFlip(flipRow);
                    }
                }else if (input == "m")
                {
                    Console.WriteLine("\nPick source row from 0-7");
                    int source = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nPick destination row from 1-7");
                    int destination = Convert.ToInt32(Console.ReadLine());
                    control.MoveCard(source, destination);
                }
                else if (input == "a")
                {
                    Console.WriteLine("\nPick source row from 0-7");
                    int source = Convert.ToInt32(Console.ReadLine());
                    control.AceStacks(source);
                }
                else
                {
                    Console.WriteLine("\nMove(m) or flip(f)");
                }
            }
        }
    }
}
