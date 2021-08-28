using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.EvaluationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.IncrementingValuationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeState.ValuationProcessState;
using GameCollection.SharedCode.Utilities.HelperClasses.ListHelpers.RemoveSubsetFromList;
using GameCollection.Games.Poker.PokerHandValueIterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeFactories.PokerHandArchetypeComponentFactories
{
    public class ClassicPokerHandArchetypeComponentFactory : IPokerHandArchetypeComponentFactory
    {
        public (IValuationProcessState, IEvaluationBehavior, IValuationProcessIncrementor) CreateComponents(List<IPokerCard> passedCards, List<IPokerHandValueIterator> passedValuationProcess)
        {
            IListSubsetRemover remover = new ClassicSubsetRemover();


            IValuationProcessState valuationState = GetValuationProcessStateInstance(passedCards, passedValuationProcess);

            IEvaluationBehavior evaluator = GetEvaluatorInstance(valuationState);

            IValuationProcessIncrementor incrementor = GetValuationProcessIncrementorInstance(valuationState, remover);

            return (valuationState, evaluator, incrementor);
        }

        public (IValuationProcessState, IEvaluationBehavior, IValuationProcessIncrementor) CreateComponents(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationProcess)
        {
            IListSubsetRemover remover = new ClassicSubsetRemover();


            IValuationProcessState valuationState = GetValuationProcessStateInstance(passedCards, passedValuationProcess);

            IEvaluationBehavior evaluator = GetEvaluatorInstance(valuationState);

            IValuationProcessIncrementor incrementor = GetValuationProcessIncrementorInstance(valuationState, remover);

            return (valuationState, evaluator, incrementor);
        }

        public IValuationProcessState GetValuationProcessStateInstance(List<IPokerCard> passedCards, List<IPokerHandValueIterator> passedValuationProcess)
        {
            return new ClassicValuationProcessState(passedCards, passedValuationProcess);
        }

        public IValuationProcessState GetValuationProcessStateInstance(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationProcess)
        {
            return new ClassicValuationProcessState(passedCards, passedValuationProcess);
        }

        public IEvaluationBehavior GetEvaluatorInstance(IValuationProcessState passedValuationState)
        {
            return new ClassicPokerHandArchetypeEvaluator(passedValuationState);
        }

        public IValuationProcessIncrementor GetValuationProcessIncrementorInstance(IValuationProcessState passedValuationProcessState, IListSubsetRemover passedRemover)
        {
            return new ClassicValuationProcessIncrementor(passedValuationProcessState, passedRemover);
        }
    }
}
