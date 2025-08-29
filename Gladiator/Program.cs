using Gladiator.WeaponSelectionStrategy;
using System;
using System.Collections.Generic;

namespace Gladiator
{
    class Program
    {
        static void Main()
        {
            // Initialize teams (1v1, Fist only)
            var hero = new Character(new HighestDamageStrategy()) { Health = 100, Name = "Gladius" };
            var goblin = new Character(new HighestDamageStrategy()) { Health = 30, Name = "Goblin" };
            var teamManager = new TeamManager(
                [hero],
                [goblin]
            );
            var gameState = new GameState(teamManager); // Initialize game state

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
                Helper.PrintStatus(teamManager.PlayerTeam, teamManager.EnemyTeam, gameState.PlayerGold);
                Console.WriteLine("Press Enter for next round");
                Console.ReadLine();
            }

            // Final state
            Helper.PrintStatus(teamManager.PlayerTeam, teamManager.EnemyTeam, gameState.PlayerGold);
            Console.WriteLine(teamManager.PlayerTeam.Any(c => c.Alive) ? "Player wins!" : "Enemy wins!");
            Console.WriteLine($"Final Gold: {gameState.PlayerGold}");
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}