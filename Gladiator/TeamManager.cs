using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    public class TeamManager
    {
        public List<Character> PlayerTeam { get; }
        public List<Character> EnemyTeam { get; }
        private readonly Random _random = new();

        public TeamManager(List<Character> playerTeam, List<Character> enemyTeam)
        {
            PlayerTeam = playerTeam ?? throw new ArgumentNullException(nameof(playerTeam));
            EnemyTeam = enemyTeam ?? throw new ArgumentNullException(nameof(playerTeam)); ;
        }

        // Simulates one round of combat; returns true if battle continues
        public bool SimulateRound()
        {
            if (!PlayerTeam.Any(c => c.Alive) || !EnemyTeam.Any(c => c.Alive))
                return false;

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

            return PlayerTeam.Any(c => c.Alive) && EnemyTeam.Any(c => c.Alive);
        }
    }
}
