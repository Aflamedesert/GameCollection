using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.MinimumBetCalculation
{
    public interface IMinimumBetCalculator<T>
    {
        void SetPlayerInterfaces(List<T> passedPlayerInterfaces);
        int GetMinimumBet();
        void ClearAll();
    }
}
