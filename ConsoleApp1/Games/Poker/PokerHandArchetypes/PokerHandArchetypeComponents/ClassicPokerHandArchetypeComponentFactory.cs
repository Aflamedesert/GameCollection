using GameCollection.Games.Poker.PokerCards;
using GameCollection.SharedCode.Utilities.HelperClasses.ListHelpers.RemoveSubsetFromList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.EvaluationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.IncrementingValuationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.PokerHandArchetypeState;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents
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
