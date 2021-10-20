using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors.BettingLoopActions
{
    public interface IBettingLoopAction<T>
    {
        void Execute(T passedObjectToBeActedOn);
    }
}
