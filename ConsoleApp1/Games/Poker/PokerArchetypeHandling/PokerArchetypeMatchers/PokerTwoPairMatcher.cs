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
    public class PokerTwoPairMatcher : IPokerArchetypeMatcher
    {
        IPokerHandPatternChecker setChecker;

        SetDiagnosticsTool setDiagnosticTool;

        public PokerTwoPairMatcher(AbstractHighKindValueIterator passedHighKindIterator, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            setChecker = passedPatternCheckingPackage.setChecker;

            setDiagnosticTool = new SetDiagnosticsTool(passedHighKindIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            const int SetNumberTarget = 2;
            const int SetSizeTarget = 2;

            bool hasSet = setChecker.containsPattern(passedCards);

            if(hasSet == true)
            {
                setDiagnosticTool.AnalyzeCards(passedCards);

                int? numberOfSets = setDiagnosticTool.numberOfSets;

                List<int> setLengths = setDiagnosticTool.setLengths;

                if(numberOfSets == SetNumberTarget)
                {
                    if(SetsAreOfLength(SetSizeTarget, setLengths))
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

        private bool SetsAreOfLength(int targetLength, List<int> setLengths)
        {
            if(setLengths != null)
            {
                foreach (int length in setLengths)
                {
                    if (length != targetLength)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
