using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator
{
    public class GameState
    {
        public int PlayerGold { get; private set; }

        public GameState(TeamManager teamManager)
        {
            PlayerGold = 0;
            teamManager.OnBattleWon += () => PlayerGold += 10; // Award 10 gold on win
        }
    }
}
