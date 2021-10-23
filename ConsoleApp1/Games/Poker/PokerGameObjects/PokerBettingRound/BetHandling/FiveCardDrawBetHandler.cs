using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;
using GameCollection.Games.Poker.PokerGameObjects.PokerPot;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingRound.BetHandling
{
    public class FiveCardDrawBetHandler<T> : IClassicBetHandler<T> where T : IChipHandlingBehavior, IBettingRoundStateBehavior, IFoldingBehavior
    {
        T playerInterface;

        IBettingLoopMutator loopMutator;

        IPokerPot pot;

        public FiveCardDrawBetHandler(IBettingLoopMutator passedLoopMutator, IPokerPot passedPot)
        {
            loopMutator = passedLoopMutator;

            pot = passedPot;
        }

        public void SetPlayerInterface(T passedPlayerInterface)
        {
            playerInterface = passedPlayerInterface;
        }

        public void Check()
        {
            //notify the player that they have just checked
        }

        public void Call(int passedCallAmount)
        {
            ExecuteBet(passedCallAmount);

            //notify the player that they have just called
        }

        public void Bet(int passedBetAmount)
        {
            ExecuteBet(passedBetAmount);

            //notify the player that they have just bet
        }

        public void Raise(int passedRaiseAmount)
        {
            ExecuteBet(passedRaiseAmount);

            //notify the player that they have just raised
        }

        public void Fold()
        {
            playerInterface.Fold();

            //notify the player that they have just folded
        }

        private void ExecuteBet(int passedBetAmount)
        {
            playerInterface.AddToAmountBet(passedBetAmount);

            playerInterface.RemoveChipsFromPlayer(passedBetAmount);

            pot.AddToPot(passedBetAmount);

            loopMutator.ChangeToCallableLoop();
        }
    }
}
