using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandPatternChecking;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers
{
    public class PokerFlushMatcher : IPokerArchetypeMatcher
    {
        IPokerHandPatternChecker setChecker;

        IPokerHandPatternChecker straightChecker;

        IPokerHandPatternChecker flushChecker;

        public PokerFlushMatcher(PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            setChecker = passedPatternCheckingPackage.setChecker;
            straightChecker = passedPatternCheckingPackage.straightChecker;
            flushChecker = passedPatternCheckingPackage.flushChecker;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            bool hasSet = setChecker.containsPattern(passedCards);
            bool isStraight = straightChecker.containsPattern(passedCards);
            bool isFlush = flushChecker.containsPattern(passedCards);

            if((hasSet == false) && (isStraight == false) && (isFlush == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
