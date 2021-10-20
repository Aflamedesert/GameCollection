using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors.BettingLoopActions
{
    public class CallableBettingAction<T> : IBettingLoopAction<T> where T : ICallableBettingBehavior
    {
        int minimumBetSize;

        public CallableBettingAction(int passedMinimumBetSize)
        {
            minimumBetSize = passedMinimumBetSize;
        }

        public void Execute(T passedObjectToBeActedOn)
        {
            passedObjectToBeActedOn.InitiateCallableBet(minimumBetSize);
        }
    }
}
