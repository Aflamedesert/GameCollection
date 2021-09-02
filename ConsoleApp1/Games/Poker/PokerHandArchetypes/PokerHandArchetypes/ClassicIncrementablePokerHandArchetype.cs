using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.EvaluationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.IncrementingValuationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.PokerHandArchetypeState;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes
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
