using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerStraightFlushHelper;

namespace GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerRoyalFlushHelper
{
    public class RoyalFlushHelper : IRoyalFlushHelper
    {
        IStraightFlushHelper straightFlushHelper;

        AbstractHighCardValueIterator highCardIterator;

        string royalFlushHighCardType;

        public RoyalFlushHelper(IStraightFlushHelper passedStraightFlushHelper, AbstractHighCardValueIterator passedHighCardIterator,
            string passedRoyalFlushHighCardType)
        {
            straightFlushHelper = passedStraightFlushHelper;

            highCardIterator = passedHighCardIterator;

            royalFlushHighCardType = passedRoyalFlushHighCardType;
        }

        public bool isRoyalFlush(List<IPokerCard> passedCards)
        {
            if (passedCards == null)
            {
                throw new ArgumentException("RoyalFlushHelper : passedCards is equal to null");
            }

            if (passedCards.Count == 0)
            {
                throw new ArgumentException("RoyalFlushHelper : passedCards contains no cards");
            }

            List<IPokerCard> straightFlush = straightFlushHelper.FindStraightFlush(passedCards);

            if (straightFlush != null)
            {
                IPokerCard highCard = highCardIterator.GetHighCard(straightFlush);

                string highCardType = highCard.getType();

                if (highCardType == royalFlushHighCardType)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
