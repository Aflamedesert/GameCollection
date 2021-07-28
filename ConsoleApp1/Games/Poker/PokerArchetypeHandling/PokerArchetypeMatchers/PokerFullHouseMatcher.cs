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
    class PokerFullHouseMatcher : IPokerArchetypeMatcher
    {
        const int FirstIndex = 0;
        const int SecondIndex = 1;

        IPokerHandPatternChecker setChecker;

        SetDiagnosticsTool setDiagnosticTool;

        public PokerFullHouseMatcher(AbstractHighKindValueIterator passedHighKindIterator, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            setChecker = passedPatternCheckingPackage.setChecker;

            setDiagnosticTool = new SetDiagnosticsTool(passedHighKindIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            const int SetNumberTarget = 2;
            const int FirstSetSizeTarget = 3;
            const int SecondSetSizeTarget = 2;

            bool hasSet = setChecker.containsPattern(passedCards);

            if(hasSet == true)
            {
                setDiagnosticTool.AnalyzeCards(passedCards);

                int? numberOfSets = setDiagnosticTool.numberOfSets;

                List<int> setLengths = setDiagnosticTool.setLengths;

                if(numberOfSets == SetNumberTarget)
                {
                    int firstSetLength = setLengths[FirstIndex];

                    if(firstSetLength == FirstSetSizeTarget)
                    {
                        int secondSetLength = setLengths[SecondIndex];

                        if(secondSetLength == SecondSetSizeTarget)
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
            else
            {
                return false;
            }
        }
    }
}
