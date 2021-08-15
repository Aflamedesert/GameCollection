using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers
{
    public class PokerStraightFlushMatcher : IPokerArchetypeMatcher
    {
        AbstractHighCardValueIterator highCardIterator;

        IPokerHandPatternChecker setChecker;

        IPokerHandPatternChecker straightChecker;

        IPokerHandPatternChecker flushChecker;

        public PokerStraightFlushMatcher(AbstractHighCardValueIterator passedHighCardIterator, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            highCardIterator = passedHighCardIterator;

            setChecker = passedPatternCheckingPackage.setChecker;
            straightChecker = passedPatternCheckingPackage.straightChecker;
            flushChecker = passedPatternCheckingPackage.flushChecker;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            bool hasSet = setChecker.containsPattern(passedCards);
            bool isStraight = straightChecker.containsPattern(passedCards);
            bool isFlush = flushChecker.containsPattern(passedCards);

            if((hasSet == false) && (isStraight == true) && (isFlush == true))
            {
                IPokerCard highCard = highCardIterator.GetHighCard(passedCards);

                string highCardType = highCard.getType();

                if(highCardType != "Ace")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
