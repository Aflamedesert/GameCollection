using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.MinimumBetCalculation;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors.BettingLoopActions
{
    public class CallableBettingAction<T> : IBettingLoopAction<T> where T : ICallableBettingBehavior, IBettingRoundStateBehavior
    {
        IMinimumBetCalculator<T> minimumBeCalculator;

        public CallableBettingAction(IMinimumBetCalculator<T> passedBettingStateHandler)
        {
            minimumBeCalculator = passedBettingStateHandler;
        }

        public void Execute(T passedObjectToBeActedOn)
        {
            int minimumBetAmount = minimumBeCalculator.GetMinimumBet();

            int currentAmountBet = passedObjectToBeActedOn.GetAmountBet();

            if(minimumBetAmount <= currentAmountBet)
            {
                throw new InvalidOperationException($"Something has gone wrong, minimumBetAmount : {minimumBetAmount} must be greater than currentAmountBet : {currentAmountBet}");
            }

            int callAmount = minimumBetAmount - currentAmountBet;

            passedObjectToBeActedOn.InitiateCallableBet(callAmount);
        }
    }
}
