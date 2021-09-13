using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState;

namespace GameCollection.Games.Poker.PlayingEntities
{
    public interface IArtificialPlayer : IPlayingEntity
    {
        IArtificialPlayerGameInterface GetGameInterface();
        void SetGameInterface(IArtificialPlayerGameInterface passedPlayerGameState);
    }
}
