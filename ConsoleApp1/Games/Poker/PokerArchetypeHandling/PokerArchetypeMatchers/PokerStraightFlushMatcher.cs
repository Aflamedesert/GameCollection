using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerStraightFlushHelper;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers
{
    public class PokerStraightFlushMatcher : IPokerArchetypeMatcher
    {
        IStraightFlushHelper straightFlushHelper;

        AbstractHighCardValueIterator highCardIterator;

        public PokerStraightFlushMatcher(IStraightFlushHelper passedStraightFlushHelper, AbstractHighCardValueIterator passedHighCardIterator)
        {
            straightFlushHelper = passedStraightFlushHelper;

            highCardIterator = passedHighCardIterator;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            List<IPokerCard> possibleStraightFlushCards = straightFlushHelper.FindStraightFlush(passedCards);

            if(possibleStraightFlushCards != null)
            {
                IPokerCard highCard = highCardIterator.GetHighCard(possibleStraightFlushCards);

                string highCardType = highCard.getType();

                if(highCardType != "Ace")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
