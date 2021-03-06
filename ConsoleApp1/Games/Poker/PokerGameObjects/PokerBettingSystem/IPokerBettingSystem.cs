using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem
{
    public interface IPokerBettingSystem<T>
    {
        List<T> ExecuteBettingRound(List<T> passedPlayers);
    }
}
