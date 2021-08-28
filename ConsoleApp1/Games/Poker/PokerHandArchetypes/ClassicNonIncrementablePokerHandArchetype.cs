using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandValueIterators;

namespace GameCollection.Games.Poker.PokerHandArchetypes
{
    class ClassicNonIncrementablePokerHandArchetype : IPokerHandArchetype
    {
        List<IPokerCard> cards;

        IPokerHandValueIterator valuationProcess;

        bool hasBeenEvaluated;

        public ClassicNonIncrementablePokerHandArchetype(List<IPokerCard> passedCards, IPokerHandValueIterator passedValueIterator)
        {
            cards = passedCards;
            valuationProcess = passedValueIterator;
            hasBeenEvaluated = false;
        }

        public int? getValuation()
        {
            if(hasBeenEvaluated == false)
            {
                hasBeenEvaluated = true;
                return GetHandValue(cards);
            }
            else
            {
                return null;
            }
        }

        private int? GetHandValue(List<IPokerCard> passedCards)
        {
            int? highValue = null;

            List<IPokerCard> highestPartOfHand = valuationProcess.GetHighestPartOfHand(passedCards);

            if((highestPartOfHand != null) && (highestPartOfHand.Count != 0))
            {
                highValue = highestPartOfHand[Constants.FirstIndex].getIntValue();
            }

            return highValue;
        }
    }
}
