using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerArchetypeMatchers;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerStraightFlushHelper;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers
{
    public class PokerRoyalFlushMatcher : IPokerArchetypeMatcher
    {
        IStraightFlushHelper straightFlushHelper;

        AbstractHighCardValueIterator highCardIterator;

        public PokerRoyalFlushMatcher(IStraightFlushHelper passedStraightFlushHelper, AbstractHighCardValueIterator passedHighCardIterator)
        {
            straightFlushHelper = passedStraightFlushHelper;

            highCardIterator = passedHighCardIterator;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            List<IPokerCard> possibleRoyalFlush = straightFlushHelper.FindStraightFlush(passedCards);

            if(possibleRoyalFlush != null)
            {
                IPokerCard highCard = highCardIterator.GetHighCard(possibleRoyalFlush);

                string highCardType = highCard.getType();

                if(highCardType == "Ace")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
