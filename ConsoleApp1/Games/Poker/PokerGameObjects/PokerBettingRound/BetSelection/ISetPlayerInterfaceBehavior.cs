using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingRound.BetSelection
{
    public interface ISetPlayerInterfaceBehavior<T>
    {
        void SetPlayerInterface(T passedPlayerInterface);
    }
}
