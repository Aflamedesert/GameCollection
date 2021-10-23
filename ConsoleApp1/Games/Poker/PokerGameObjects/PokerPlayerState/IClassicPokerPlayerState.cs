using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerState
{
    public interface IClassicPokerPlayerState : IGetPlayerNameBehavior, IGetPlayerCardsBehavior, IChipHandlingBehavior, IBettingRoundStateBehavior, IFoldingBehavior, IEmptyHandBehavior, IAddToHandBehavior, IRemoveFromHandBehavior
    {
        //empty interface that is used to represent the default, Classic, poker player state object
    }
}
