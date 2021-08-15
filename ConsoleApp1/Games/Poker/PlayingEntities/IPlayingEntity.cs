using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes;
using GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.State;

namespace GameCollection.Games.Poker.PlayingEntities
{
    public interface IPlayingEntity
    {
        bool HasStateObject();
        void SetStateObject(IPlayerState passedPlayerStateObject);
        void PlayTurn();
    }
}
