using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator
{
    // Manages teams and combat, fires event on player win
    public class TeamManager(List<Character> playerTeam, List<Character> enemyTeam)
    {
        public List<Character> PlayerTeam { get; } = playerTeam ?? throw new ArgumentNullException(nameof(playerTeam));
        public List<Character> EnemyTeam { get; } = enemyTeam ?? throw new ArgumentNullException(nameof(enemyTeam));
        public event Action? OnBattleWon; // Fired when player team wins
        private readonly Random _random = new();

        // Simulates one round of combat; returns true if battle continues
        public bool SimulateRound()
        {
            // Player team attacks
            foreach (var attacker in PlayerTeam.Where(c => c.Alive))
            {
                var target = EnemyTeam.Where(c => c.Alive).OrderBy(_ => _random.Next()).FirstOrDefault();
                if (target != null)
                    attacker.Attact(target);
            }

            // Enemy team attacks
            foreach (var attacker in EnemyTeam.Where(c => c.Alive))
            {
                var target = PlayerTeam.Where(c => c.Alive).OrderBy(_ => _random.Next()).FirstOrDefault();
                if (target != null)
                    attacker.Attact(target);
            }

            // Check win condition after attacks
            if (!PlayerTeam.Any(c => c.Alive) || !EnemyTeam.Any(c => c.Alive))
            {
                if (PlayerTeam.Any(c => c.Alive))
                {
                    Console.WriteLine("Debug: Player wins, firing OnBattleWon"); // Debug log
                    OnBattleWon?.Invoke(); // Fire event on player win
                }
                return false;
            }

            return true;
        }
    }
}