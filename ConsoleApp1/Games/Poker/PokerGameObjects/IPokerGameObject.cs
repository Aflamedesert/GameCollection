using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;

namespace GameCollection.Games.Poker.PokerGameObjects
{
    public interface IPokerGameObject
    {
        void Play();
        void LinkPlayerToStateObject(List<IPlayingEntity> passedPlayers);
        void LinkPlayerToStateObject(IPlayingEntity passedPlayer);
    }
}
