using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.PokerHandArchetypeState;
using GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.EvaluationBehavior
{
    public class ClassicPokerHandArchetypeEvaluator : IEvaluationBehavior
    {
        IValuationProcessState valuationState;

        public ClassicPokerHandArchetypeEvaluator(IValuationProcessState passedValuationState)
        {
            valuationState = passedValuationState;
        }

        public void Evaluate()
        {
            List<IPokerCard> highCards;

            int? highValue;

            List<IPokerCard> cards = valuationState.getCards();

            if (cards != null)
            {
                int numberOfCards = cards.Count;

                if (numberOfCards > 0)
                {
                    IPokerHandValueIterator valueIterator = valuationState.getCurrentValuationProcess();

                    highCards = getHighCards(cards, valueIterator);
                    highValue = highCards[Constants.FirstIndex].getIntValue();

                    valuationState.setCurrentHighCards(highCards);
                    valuationState.setCurrentHighValue(highValue);
                }
                else
                {
                    SetEndValues();
                }
            }
        }

        private void SetEndValues()
        {
            valuationState.setCards(null);
            valuationState.setCurrentHighCards(null);
            valuationState.setCurrentHighValue(null);
        }

        private List<IPokerCard> getHighCards(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationMethod)
        {
            return passedValuationMethod.GetHighestPartOfHand(passedCards);
        }
    }
}
