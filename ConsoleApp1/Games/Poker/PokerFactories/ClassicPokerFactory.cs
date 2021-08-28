using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandSorting;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerArchetypeHelper;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerStraightFlushHelper;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerRoyalFlushHelper;

namespace GameCollection.Games.Poker.PokerFactories
{
    public class ClassicPokerFactory
    {
        public PokerPatternCheckingPackage GetPatternCheckingPackageInstance()
        {
            SetChecker setChecker = GetSetCheckerInstance();

            StraightChecker straightChecker = GetStraightCheckerInstance();

            FlushChecker flushChecker = GetFlushCheckerInstance();

            return new PokerPatternCheckingPackage(setChecker, straightChecker, flushChecker);
        }

        public StrictPokerArchetypeHelper GetStrictArchetypeHelperInstance()
        {
            return new StrictPokerArchetypeHelper(GetSetDiagnosticsToolInstance(), GetStrictSetDataMatcherInstance(), GetPatternCheckingPackageInstance());
        }

        public LoosePokerArchetypeHelper GetLooseArchetypeHelperInstance()
        {
            return new LoosePokerArchetypeHelper(GetSetDiagnosticsToolInstance(), GetLooseSetDataMatcherInstance(), GetPatternCheckingPackageInstance());
        }

        public RoyalFlushHelper GetRoyalFlushHelperInstance()
        {
            string royalFlushHighCardType = "Ace";

            return new RoyalFlushHelper(GetFiveCardStraightFlushHelperInstance(), GetHighCardIteratorInstance(), royalFlushHighCardType);
        }

        public FiveCardStraightFlushHelper GetFiveCardStraightFlushHelperInstance()
        {
            return new FiveCardStraightFlushHelper(GetFlushCheckerInstance(), GetStraightCheckerInstance());
        }

        public StrictSetDataMatcher GetStrictSetDataMatcherInstance()
        {
            return new StrictSetDataMatcher();
        }

        public LooseSetDataMatcher GetLooseSetDataMatcherInstance()
        {
            return new LooseSetDataMatcher();
        }

        public SetDiagnosticsTool GetSetDiagnosticsToolInstance()
        {
            return new SetDiagnosticsTool(GetHighKindIteratorInstance());
        }

        public HighCardValueIterator GetHighCardIteratorInstance()
        {
            return new HighCardValueIterator();
        }

        public HighKindValueIterator GetHighKindIteratorInstance()
        {
            return new HighKindValueIterator();
        }

        public ClassicHandSorter GetHandSorterInstance()
        {
            return new ClassicHandSorter(GetHighCardIteratorInstance(), GetHighKindIteratorInstance());
        }

        public FlushChecker GetFlushCheckerInstance()
        {
            return new FlushChecker();
        }

        public StraightChecker GetStraightCheckerInstance()
        {
            return new StraightChecker(GetHandSorterInstance());
        }

        public SetChecker GetSetCheckerInstance()
        {
            return new SetChecker();
        }
    }
}
