using System;
using System.Collections.Generic;

namespace Gladiator
{
    class Program
    {
        static void Main()
        {
            // Initialize teams (1v1 for now)
            var hero = new Character { Health = 100 };
            var goblin = new Character { Health = 30 };
            var teamManager = new TeamManager(
                new List<Character> { hero },
                new List<Character> { goblin }
            );

            // Subscribe to events for UI
            foreach (var player in teamManager.PlayerTeam.Concat(teamManager.EnemyTeam))
            {
                player.OnAttack += (attacker, target, damage) =>
                    Helper.PrintAttack(attacker, target, damage);
                player.OnDeath += (character) =>
                    Helper.PrintDeath(character);
            }

            // Auto-battle loop
            while (teamManager.SimulateRound())
            {
                Helper.PrintStatus(teamManager.PlayerTeam, teamManager.EnemyTeam);
                Console.WriteLine("Press Enter for next round");
                Console.ReadLine();
            }

            // Final state
            Helper.PrintStatus(teamManager.PlayerTeam, teamManager.EnemyTeam);
            Console.WriteLine(teamManager.PlayerTeam.Any(c => c.Alive) ? "Player wins!" : "Enemy wins!");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}