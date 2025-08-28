using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator
{
    public static class Helper
    {
        public static void PrintStatus(List<Character> playerTeam, List<Character> enemyTeam)
        {
            Console.Clear();
            Console.WriteLine("Player Team:");
            foreach (var p in playerTeam)
                Console.WriteLine($"  {p.Weapon.Name}: {p.Health} HP {(p.Alive ? "" : "(Dead)")}");
            Console.WriteLine("Enemy Team:");
            foreach (var e in enemyTeam)
                Console.WriteLine($"  {e.Weapon.Name}: {e.Health} HP {(e.Alive ? "" : "(Dead)")}");
            Console.WriteLine();
        }

        public static void PrintAttack(Character attacker, Character target, int damage)
        {
            Console.WriteLine($"{attacker.Weapon.Name} deals {damage} damage to {target.Weapon.Name}!");
        }

        public static void PrintDeath(Character character)
        {
            Console.WriteLine($"{character.Weapon.Name} has been defeated!");
        }
    }
}