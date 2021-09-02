using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandPatternCheckers;

namespace GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerStraightFlushHelper
{
    public class FiveCardStraightFlushHelper : IStraightFlushHelper
    {
        IPokerHandPatternChecker flushChecker;

        IPokerHandPatternChecker straightChecker;

        public FiveCardStraightFlushHelper(IPokerHandPatternChecker passedFlushChecker, IPokerHandPatternChecker passedStraightChecker)
        {
            flushChecker = passedFlushChecker;
            straightChecker = passedStraightChecker;
        }

        public List<IPokerCard> FindStraightFlush(List<IPokerCard> passedCards)
        {
            bool containsFlush = flushChecker.containsPattern(passedCards);

            bool containsStraight = straightChecker.containsPattern(passedCards);

            if (containsFlush == true && containsStraight == true)
            {
                return passedCards;
            }
            else
            {
                return null;
            }
        }
    }
}
