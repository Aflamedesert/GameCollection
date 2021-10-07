using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingRound.BetHandling
{
    public interface IClassicBetHandler<T> : ISetPlayerInterfaceBehavior<T>, IBetBehavior, ICallBehavior, ICheckBehavior, IFoldBehavior, IRaiseBehavior
    {
        //empty interface, used as a composite of the inherited interfaces
    }
}
