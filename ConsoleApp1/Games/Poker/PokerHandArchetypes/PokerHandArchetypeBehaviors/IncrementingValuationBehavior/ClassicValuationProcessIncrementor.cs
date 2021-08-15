using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeState.ValuationProcessState;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.EvaluationBehavior;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.IncrementingValuationBehavior
{
    public class ClassicValuationProcessIncrementor : IValuationProcessIncrementor
    {
        IValuationProcessState valuationState;

        IEvaluationBehavior evaluator;

        public ClassicValuationProcessIncrementor(IValuationProcessState passedValuationState, IEvaluationBehavior passedEvaluator)
        {
            valuationState = passedValuationState;
            evaluator = passedEvaluator;
        }

        public void Increment()
        {
            List<IPokerCard> highCards = valuationState.getCurrentHighCards();

            List<IPokerCard> cards = valuationState.getCards();

            int numberOfCards = cards.Count;

            if(numberOfCards > 0)
            {
                int lastIndex = valuationState.getValuationProcessCount() - 1;

                int currentIndex = valuationState.getCurrentValuationIndex();

                if (currentIndex > lastIndex)
                {
                    currentIndex++;
                    valuationState.setCurrentValuationIndex(currentIndex);
                }

                List<IPokerCard> restOfHand = RemoveHighCards(highCards, cards);

                valuationState.setCards(restOfHand);

                evaluator.Evaluate();
            }
            else
            {
                valuationState.setCurrentHighCards(null);
                valuationState.setCurrentHighValue(null);
            }
        }

        private List<IPokerCard> RemoveHighCards(List<IPokerCard> passedHighCards, List<IPokerCard> passedCards)
        {
            List<IPokerCard> highCards = new List<IPokerCard>(passedHighCards);

            List<IPokerCard> cards = new List<IPokerCard>(passedCards);

            int numberOfHighCards = highCards.Count;

            int numberOfCards = cards.Count;

            if ((numberOfHighCards > 0) && (numberOfCards > 0))
            {
                foreach (IPokerCard highCard in highCards)
                {
                    foreach (IPokerCard card in cards)
                    {
                        if (card == highCard)
                        {
                            cards.Remove(card);
                        }
                    }
                }
            }

            return cards;
        }
    }
}
