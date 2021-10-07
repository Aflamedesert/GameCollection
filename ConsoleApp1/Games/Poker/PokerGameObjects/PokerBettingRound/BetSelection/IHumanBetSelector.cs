using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingRound.BetSelection
{
    public interface IHumanBetSelector : IClassicBetSelector
    {
        //empty interface, used to distinguish the interfaces linked to human players from those linked to artificial players
    }
}
