using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeState.ValuationProcessState;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.EvaluationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.IncrementingValuationBehavior;

namespace GameCollection.Games.Poker.PokerHandArchetypes
{
    public class ClassicIncrementablePokerHandArchetype : IPokerIncrementableHandArchetype
    {
        IValuationProcessState valuationState;

        IEvaluationBehavior evaluator;

        IValuationProcessIncrementor incrementor;

        public ClassicIncrementablePokerHandArchetype(IValuationProcessState passedValuationState, IEvaluationBehavior passedEvaluationBehavior, IValuationProcessIncrementor passedValuationIncrementor)
        {
            valuationState = passedValuationState;
            evaluator = passedEvaluationBehavior;
            incrementor = passedValuationIncrementor;

            evaluator.Evaluate();
        }

        public int? getValuation()
        {
            return valuationState.getCurrentHighValue();
        }

        public void Increment()
        {
            incrementor.Increment();
            evaluator.Evaluate();
        }
    }
}
