using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    public static class Helper
    {
        public static void PrintStatus(Character p1, Character p2)
        {
            Console.Clear();
            Console.WriteLine($"Player 1 Health: {p1.Health}");
            Console.WriteLine($"Player 2 Health: {p2.Health}");
            Console.WriteLine();
        }
    }
}
