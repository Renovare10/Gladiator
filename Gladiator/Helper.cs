using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator
{
    public static class Helper
    {
        // Displays team status with names, weapons, and gold
        public static void PrintStatus(List<Character> playerTeam, List<Character> enemyTeam, int playerGold)
        {
            Console.Clear();
            Console.WriteLine($"Player Gold: {playerGold}");
            Console.WriteLine("Player Team:");
            foreach (var p in playerTeam)
                Console.WriteLine($"  {p.Name} ({p.GetCurrentWeapon()?.Name ?? "Unarmed"}): {p.Health} HP {(p.Alive ? "" : "(Dead)")}{(p == playerTeam[0] ? $" (Inventory: {string.Join(", ", p.Inventory.Select(w => w.Name))})" : "")}");
            Console.WriteLine("Enemy Team:");
            foreach (var e in enemyTeam)
                Console.WriteLine($"  {e.Name} ({e.GetCurrentWeapon()?.Name ?? "Unarmed"}): {e.Health} HP {(e.Alive ? "" : "(Dead)")}");
            Console.WriteLine();
        }

        // Prints attack event
        public static void PrintAttack(Character attacker, Character target, int damage)
        {
            Console.WriteLine($"{attacker.Name} ({attacker.GetCurrentWeapon()?.Name ?? "Unarmed"}) deals {damage} damage to {target.Name} ({target.GetCurrentWeapon()?.Name ?? "Unarmed"})!");
        }

        // Prints death event
        public static void PrintDeath(Character character)
        {
            Console.WriteLine($"{character.Name} ({character.GetCurrentWeapon()?.Name ?? "Unarmed"}) has been defeated!");
        }
    }
}