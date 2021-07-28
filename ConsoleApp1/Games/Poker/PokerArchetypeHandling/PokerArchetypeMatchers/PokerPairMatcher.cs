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
    class PokerPairMatcher : IPokerArchetypeMatcher
    {
        const int FirstIndex = 0;

        IPokerHandPatternChecker setChecker;

        SetDiagnosticsTool setDiagnosicTool;

        public PokerPairMatcher(AbstractHighKindValueIterator passedHighKindIterator, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            setChecker = passedPatternCheckingPackage.setChecker;

            setDiagnosicTool = new SetDiagnosticsTool(passedHighKindIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            const int SetNumberTarget = 1;
            const int SetSizeTarget = 2;

            bool isSet = setChecker.containsPattern(passedCards);

            if(isSet == true)
            {
                setDiagnosicTool.AnalyzeCards(passedCards);

                int? numberOfSets = setDiagnosicTool.numberOfSets;

                int setLength = setDiagnosicTool.setLengths[FirstIndex];

                if((numberOfSets == SetNumberTarget) && (setLength == SetSizeTarget))
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
