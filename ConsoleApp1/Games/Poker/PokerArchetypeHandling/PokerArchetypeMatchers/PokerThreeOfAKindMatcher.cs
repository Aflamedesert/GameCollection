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
    public class PokerThreeOfAKindMatcher : IPokerArchetypeMatcher
    {
        const int FirstIndex = 0;

        IPokerHandPatternChecker setChecker;

        IPokerHandPatternChecker straightChecker;

        IPokerHandPatternChecker flushChecker;

        SetDiagnosticsTool setDiagnosticsTool;

        public PokerThreeOfAKindMatcher(AbstractHighKindValueIterator passedHighKindIterator, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            setChecker = passedPatternCheckingPackage.setChecker;

            setDiagnosticsTool = new SetDiagnosticsTool(passedHighKindIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            const int SetNumberTarget = 1;
            const int SetSizeTarget = 3;

            bool hasSet = setChecker.containsPattern(passedCards);

            if(hasSet == true)
            {
                setDiagnosticsTool.AnalyzeCards(passedCards);

                int? numberOfSets = setDiagnosticsTool.numberOfSets;

                List<int> setLengths = setDiagnosticsTool.setLengths;

                if(numberOfSets == SetNumberTarget)
                {
                    int lengthOfFirstSet = setLengths[FirstIndex];

                    if(lengthOfFirstSet == SetSizeTarget)
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
            else
            {
                return false;
            }
        }
    }
}
