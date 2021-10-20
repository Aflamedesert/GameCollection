using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors.BettingLoopActions
{
    public class CheckableBettingAction<T> : IBettingLoopAction<T> where T : ICheckableBettingBehavior
    {
        public void Execute(T passedObjectToBeActedOn)
        {
            passedObjectToBeActedOn.InitiateCheckableBet();
        }
    }
}
