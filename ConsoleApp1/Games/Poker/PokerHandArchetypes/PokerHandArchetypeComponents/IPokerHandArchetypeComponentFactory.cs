using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.SharedCode.Utilities.HelperClasses.ListHelpers.RemoveSubsetFromList;
using GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.EvaluationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.IncrementingValuationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.PokerHandArchetypeState;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents
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
