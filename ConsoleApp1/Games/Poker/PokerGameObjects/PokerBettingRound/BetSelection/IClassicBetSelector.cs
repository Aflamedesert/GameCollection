using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingRound.BetSelection
{
    public interface IClassicBetSelector : ICallableBetSelectionBehavior, ICheckableBetSelectionBehavior
    {
        //used as a composite of the inherited interfaces
    }
}
