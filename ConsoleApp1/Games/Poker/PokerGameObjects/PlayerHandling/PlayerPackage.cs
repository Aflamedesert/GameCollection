using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.State;
using GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.Betting.PlayerBetter;
using GameCollection.Games.Poker.PlayingEntities;

namespace GameCollection.Games.Poker.PokerGameObjects
{
    struct PlayerPackage
    {
        public IPlayingEntity playerObject { get; }

        public IPlayerState playerState { get; }

        public IPlayerBetter playerBetter { get; }

        public PlayerPackage(IPlayingEntity passedPlayerObject, IPlayerState passedPlayerState, IPlayerBetter passedPlayerBetter)
        {
            playerObject = passedPlayerObject;
            playerState = passedPlayerState;
            playerBetter = passedPlayerBetter;
        }
    }
}
