using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes
{
    class ClassicNonIncrementablePokerHandArchetype : IPokerHandArchetype
    {
        List<IPokerCard> cards;

        IPokerHandValueIterator valuationProcess;

        string archetypeIdentifier;

        bool hasBeenEvaluated;

        public ClassicNonIncrementablePokerHandArchetype(List<IPokerCard> passedCards, IPokerHandValueIterator passedValueIterator, 
            string passedArchetypeIdentifier)
        {
            cards = passedCards;

            valuationProcess = passedValueIterator;

            archetypeIdentifier = passedArchetypeIdentifier;

            hasBeenEvaluated = false;
        }

        public string GetArchetypeIdentifier()
        {
            return archetypeIdentifier;
        }

        public int? GetValuation()
        {
            if (hasBeenEvaluated == false)
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

            if (highestPartOfHand != null && highestPartOfHand.Count != 0)
            {
                highValue = highestPartOfHand[Constants.FirstIndex].getIntValue();
            }

            return highValue;
        }
    }
}
