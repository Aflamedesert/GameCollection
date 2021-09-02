using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics;
using GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher;


namespace GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.StandardMatcherHelper.PokerMatcherHelperBase
{
    public class ClassicPokerMatcherHelperBase : IPokerMatcherHelperBase
    {
        ISetDiagnosticsTool setDiagnosticsTool;

        ISetDataMatcher setDataMatcher;

        PokerPatternCheckingPackage patternCheckingPackage;

        public ClassicPokerMatcherHelperBase(ISetDiagnosticsTool passedSetDiagnosticsTool, ISetDataMatcher passedSetDataMatcher, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            setDiagnosticsTool = passedSetDiagnosticsTool;
            setDataMatcher = passedSetDataMatcher;
            patternCheckingPackage = passedPatternCheckingPackage;
        }

        public bool isPatternMatch(List<IPokerCard> passedCards, bool? isFlush, bool? isStraight, bool? hasSet, List<int> setTarget)
        {
            if (passedCards == null)
            {
                throw new ArgumentException("ClassicPokerArchetypeHelperBase : passed in an invalid argument", $"passedCards = null");
            }

            if (passedCards.Count == 0)
            {
                throw new ArgumentException("ClassicPokerArchetypeHelperBase : passed in an invalid argument", $"passedCards.Count = 0");
            }

            if (isFlush != null)
            {
                bool actual = CheckForFlush(passedCards);

                if (actual != isFlush)
                {
                    return false;
                }
            }

            if (isStraight != null)
            {
                bool actual = CheckForStraight(passedCards);

                if (actual != isStraight)
                {
                    return false;
                }
            }

            if (hasSet != null)
            {
                bool actual = CheckForSet(passedCards);

                if (actual != hasSet)
                {
                    return false;
                }
            }

            if (setTarget != null)
            {
                bool actual = CheckForSetTarget(passedCards, setTarget);

                if (actual != true)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckForFlush(List<IPokerCard> passedCards)
        {
            return patternCheckingPackage.flushChecker.containsPattern(passedCards);
        }

        private bool CheckForStraight(List<IPokerCard> passedCards)
        {
            return patternCheckingPackage.straightChecker.containsPattern(passedCards);
        }

        private bool CheckForSet(List<IPokerCard> passedCards)
        {
            return patternCheckingPackage.setChecker.containsPattern(passedCards);
        }

        private bool CheckForSetTarget(List<IPokerCard> passedCards, List<int> passedSetTarget)
        {
            List<int> setData = setDiagnosticsTool.AnalyzeCards(passedCards);

            if (setData == null)
            {
                return false;
            }

            return setDataMatcher.CheckForSetMatch(setData, passedSetTarget);
        }
    }
}
