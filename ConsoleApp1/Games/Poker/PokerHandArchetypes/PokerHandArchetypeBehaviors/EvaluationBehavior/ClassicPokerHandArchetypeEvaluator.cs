using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.BackupValuationCheckingBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeState.ValuationProcessState;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.EvaluationBehavior
{
    public class ClassicPokerHandArchetypeEvaluator : IEvaluationBehavior
    {
        const int FirstIndex = 0;

        IValuationProcessState valuationState;

        IBackupValuationChecker backupValuationChecker;

        public ClassicPokerHandArchetypeEvaluator(IValuationProcessState passedValuationState, IBackupValuationChecker passedBackupChecker) 
        {
            valuationState = passedValuationState;

            backupValuationChecker = passedBackupChecker;
        }

        public void Evaluate()
        {
            List<IPokerCard> highCards = null;

            int? highValue = null;

            if(backupValuationChecker.hasBackupValuation() == true)
            {
                List<IPokerCard> cards = valuationState.getCards();

                IPokerHandValueIterator valueIterator = valuationState.getCurrentValuationProcess();

                highCards = getHighCards(cards, valueIterator);
                highValue = highCards[FirstIndex].getIntValue();
            }

            valuationState.setCurrentHighCards(highCards);
            valuationState.setCurrentHighValue(highValue);
        }

        private List<IPokerCard> getHighCards(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationMethod)
        {
            return passedValuationMethod.GetHighestPartOfHand(passedCards);
        }
    }
}
