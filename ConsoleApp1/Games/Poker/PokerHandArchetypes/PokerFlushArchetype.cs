using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeState.ValuationProcessState;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.BackupValuationCheckingBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.EvaluationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.IncrementingValuationBehavior;

namespace GameCollection.Games.Poker.PokerHandArchetypes
{
    public class PokerFlushArchetype : IPokerHandArchetype
    {
        IValuationProcessState valuationState;

        IBackupValuationChecker backupChecker;

        IEvaluationBehavior evaluator;

        IValuationProcessIncrementor incrementor;

        public PokerFlushArchetype(List<IPokerCard> passedCards, AbstractHighCardValueIterator passedHighCardIterator)
        {
            valuationState = new ClassicValuationProcessState(passedCards, passedHighCardIterator);
            backupChecker = new ClassicBackupValuationChecker(valuationState);
            evaluator = new ClassicPokerHandArchetypeEvaluator(valuationState, backupChecker);
            incrementor = new ClassicValuationProcessIncrementor(valuationState, evaluator);

            evaluator.Evaluate();
        }

        public int? getValuation()
        {
            return valuationState.getCurrentHighValue();
        }

        public bool hasBackUpValuation()
        {
            return backupChecker.hasBackupValuation();
        }

        public void incrementBackUpValuation()
        {
            incrementor.Increment();
        }
    }
}
