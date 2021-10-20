using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors
{
    public interface ILoopIncrementor<T>
    {
        int GetCurrentIndex();

        T GetCurrentObject();
        void Increment();
        bool isFinished();
    }
}
