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
using GameCollection.SharedCode.Utilities.HelperClasses.ListHelpers.RemoveSubsetFromList;


namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeFactories.PokerHandArchetypeComponentFactories
{
    public interface IPokerHandArchetypeComponentFactory
    {
        (IValuationProcessState, IEvaluationBehavior, IValuationProcessIncrementor) CreateComponents(List<IPokerCard> passedCards, List<IPokerHandValueIterator> passedValuationProcess);
        (IValuationProcessState, IEvaluationBehavior, IValuationProcessIncrementor) CreateComponents(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationProcess);

        IValuationProcessState GetValuationProcessStateInstance(List<IPokerCard> passedCards, List<IPokerHandValueIterator> passedValuationProcess);
        IValuationProcessState GetValuationProcessStateInstance(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationProcess);
        IEvaluationBehavior GetEvaluatorInstance(IValuationProcessState passedValuationState);
        IValuationProcessIncrementor GetValuationProcessIncrementorInstance(IValuationProcessState passedValuationProcessState, IListSubsetRemover passedRemover);
    }
}
