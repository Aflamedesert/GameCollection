using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.BettingLoopIncrementors.BettingLoopActions;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem
{
    public delegate ILoopIncrementor<T> IncrementorLoopCreationMethod<T>(List<T> passedObjects, int passedStartingIndex = 0);

    public class FiveCardDrawBettingSystem<T> : IPokerBettingSystem<T>, IBettingLoopMutator where T : IFoldingBehavior, ICallableBettingBehavior, ICheckableBettingBehavior
    {
        List<T> playerInterfaces;

        IncrementorLoopCreationMethod<T> loopCreator;

        ILoopIncrementor<T> currentIncrementorLoop;

        IBettingLoopAction<T> currentBettingLoopAction;

        public FiveCardDrawBettingSystem(IncrementorLoopCreationMethod<T> passedIncrementorLoopCreator)
        {
            loopCreator = passedIncrementorLoopCreator;
        }

        public List<T> ExecuteBettingRound(List<T> passedPlayers)
        {
            playerInterfaces = new List<T>(passedPlayers);

            currentIncrementorLoop = loopCreator(playerInterfaces);

            currentBettingLoopAction = CreateCheckableBettingAction();

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
            currentBettingLoopAction = CreateCheckableBettingAction();

            int currentLoopIncrementorIndex = currentIncrementorLoop.GetCurrentIndex();

            currentIncrementorLoop = loopCreator(playerInterfaces, currentLoopIncrementorIndex);
        }

        public void ChangeToCallableLoop(int passedMinimumBet)
        {
            currentBettingLoopAction = CreateCallableBettingAction(passedMinimumBet);

            int currentLoopIncrementorIndex = currentIncrementorLoop.GetCurrentIndex();

            currentIncrementorLoop = loopCreator(playerInterfaces, currentLoopIncrementorIndex);
        }

        private CheckableBettingAction<T> CreateCheckableBettingAction()
        {
            return new CheckableBettingAction<T>();
        }

        private CallableBettingAction<T> CreateCallableBettingAction(int passedMinimumBetSize)
        {
            return new CallableBettingAction<T>(passedMinimumBetSize);
        }
    }
}
