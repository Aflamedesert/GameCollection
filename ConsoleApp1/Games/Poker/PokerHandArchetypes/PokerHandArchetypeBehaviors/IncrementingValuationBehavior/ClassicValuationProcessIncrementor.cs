using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeState.ValuationProcessState;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.EvaluationBehavior;
using GameCollection.SharedCode.Utilities.HelperClasses.ListHelpers.RemoveSubsetFromList;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.IncrementingValuationBehavior
{
    public class ClassicValuationProcessIncrementor : IValuationProcessIncrementor
    {
        IValuationProcessState valuationState;

        IListSubsetRemover remover;

        public ClassicValuationProcessIncrementor(IValuationProcessState passedValuationState, IListSubsetRemover passedRemover)
        {
            valuationState = passedValuationState;
            remover = passedRemover;
        }

        public void Increment()
        {
            List<IPokerCard> highCards = valuationState.getCurrentHighCards();

            List<IPokerCard> cards = valuationState.getCards();

            if(cards != null)
            {
                int numberOfCards = cards.Count;

                if (numberOfCards > 0)
                {
                    int lastIndex = valuationState.getValuationProcessCount() - 1;

                    int currentIndex = valuationState.getCurrentValuationIndex();

                    if (currentIndex < lastIndex)
                    {
                        currentIndex++;
                        valuationState.setCurrentValuationIndex(currentIndex);
                    }

                    List<IPokerCard> restOfHand = remover.RemoveSubsetFromList(cards, highCards);

                    valuationState.setCards(restOfHand);
                }
            }
        }
    }
}
