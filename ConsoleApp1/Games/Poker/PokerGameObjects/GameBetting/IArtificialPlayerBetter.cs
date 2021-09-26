using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.GameBetting
{
    public interface IArtificialPlayerBetter
    {
        bool GenerateBet(string passedHandArchetype);
    }
}
