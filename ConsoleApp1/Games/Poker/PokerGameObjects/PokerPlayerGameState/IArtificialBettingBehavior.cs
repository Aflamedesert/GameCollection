using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState
{
    public interface IArtificialBettingBehavior
    {
        void Bet(string passedHandArchetype);
    }
}
