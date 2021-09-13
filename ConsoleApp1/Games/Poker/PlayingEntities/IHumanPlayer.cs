using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState;

namespace GameCollection.Games.Poker.PlayingEntities
{
    public interface IHumanPlayer : IPlayingEntity
    {
        IHumanPlayerGameInterface GetGameInterface();
        void SetGameInterface(IHumanPlayerGameInterface passedPlayerGameState);
    }
}
