using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState
{
    public interface IDiscardableDrawableBettableHumanPlayerGameInterface : IHumanPlayerGameInterface, IDrawBehavior, IDiscardBehavior, IHumanBettingBehavior
    {
        //empty, because this interface only serves as a combination of other interfaces
    }
}
