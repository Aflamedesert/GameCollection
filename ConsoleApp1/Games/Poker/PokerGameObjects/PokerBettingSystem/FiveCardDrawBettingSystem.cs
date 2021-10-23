using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors.BettingLoopActions;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.MinimumBetCalculation;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem
{
    public delegate ILoopIncrementor<T> IncrementorLoopCreationMethod<T>(List<T> passedObjects, int passedStartingIndex = 0);

    public class FiveCardDrawBettingSystem<T> : IPokerBettingSystem<T>, IBettingLoopMutator where T : IFoldingBehavior, ICallableBettingBehavior, ICheckableBettingBehavior
    {
        List<T> playerInterfaces;



        IncrementorLoopCreationMethod<T> loopCreator;

        IMinimumBetCalculator<T> minimumBetCalculator;

        IBettingLoopAction<T> checkableBettingAction;

        IBettingLoopAction<T> callableBettingAction;

        IBettingLoopAction<T> startingAction;



        ILoopIncrementor<T> currentIncrementorLoop;

        IBettingLoopAction<T> currentBettingLoopAction;

        public FiveCardDrawBettingSystem(IncrementorLoopCreationMethod<T> passedIncrementorLoopCreator, 
            IMinimumBetCalculator<T> passedMinimumBetCalculator, 
            IBettingLoopAction<T> passedCheckableBettingAction,
            IBettingLoopAction<T> passedCallableBettingAction,
            IBettingLoopAction<T> passedStartingBettingAction = null)
        {
            loopCreator = passedIncrementorLoopCreator;

            minimumBetCalculator = passedMinimumBetCalculator;

            checkableBettingAction = passedCheckableBettingAction;

            callableBettingAction = passedCallableBettingAction;

            startingAction = passedStartingBettingAction;
        }

        public List<T> ExecuteBettingRound(List<T> passedPlayers)
        {
            playerInterfaces = new List<T>(passedPlayers);

            minimumBetCalculator.SetPlayerInterfaces(playerInterfaces);

            currentIncrementorLoop = loopCreator(playerInterfaces);

            if(startingAction != null)
            {
                currentBettingLoopAction = startingAction;
            }
            else
            {
                currentBettingLoopAction = checkableBettingAction;
            }

            bool loopHasFinished = false;

            do
            {
                T currentPlayer = currentIncrementorLoop.GetCurrentObject();

                if (currentPlayer.HasPlayerFolded() == false)
                {
                    //maybe put some form of notification to let the current player know that it is their turn

                    currentBettingLoopAction.Execute(currentPlayer);
                }

                bool isFinished = currentIncrementorLoop.isFinished();

                if (isFinished == true)
                {
                    loopHasFinished = true;
                }
                else
                {
                    currentIncrementorLoop.Increment();
                }

            } while (loopHasFinished == false);

            List<T> playersThatHaveNotFolded = RemovedFoldedPlayers(playerInterfaces);

            minimumBetCalculator.ClearAll();

            return playersThatHaveNotFolded;
        }

        private List<T> RemovedFoldedPlayers(List<T> passedPlayerInterfaces)
        {
            List<T> output = new List<T>();

            foreach (T player in passedPlayerInterfaces)
            {
                if (player.HasPlayerFolded() == false)
                {
                    output.Add(player);
                }
            }

            return output;
        }

        public void ChangeToCheckableLoop()
        {
            currentBettingLoopAction = checkableBettingAction;

            int currentLoopIncrementorIndex = currentIncrementorLoop.GetCurrentIndex();

            currentIncrementorLoop = loopCreator(playerInterfaces, currentLoopIncrementorIndex);
        }

        public void ChangeToCallableLoop()
        {
            currentBettingLoopAction = callableBettingAction;

            int currentLoopIncrementorIndex = currentIncrementorLoop.GetCurrentIndex();

            currentIncrementorLoop = loopCreator(playerInterfaces, currentLoopIncrementorIndex);
        }
    }
}
