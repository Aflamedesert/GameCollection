using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerDisplay
{
    public interface IDisplayDiscardBehavior
    {
        void DisplayDiscard(IPlayingEntity passedDiscardingPlayer, int numberOfDiscardedCards);
    }
}
