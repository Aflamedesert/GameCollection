using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandPatternCheckers;
using GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandSorting;
using GameCollection.Games.Poker.PokerHandValueIterators;

namespace GameCollection.Games.Poker.PokerHandPatternChecking
{
    public class ClassicPokerPatternCheckingFactory : IPokerPatternCheckingFactory
    {
        IPokerHandSorterFactory handSorterFactory;

        IPokerHandValueIteratorFactory valueIteratorFactory;

        public ClassicPokerPatternCheckingFactory(IPokerHandSorterFactory passedHandSorterFactory, IPokerHandValueIteratorFactory passedValueIteratorFactory)
        {
            handSorterFactory = passedHandSorterFactory;

            valueIteratorFactory = passedValueIteratorFactory;
        }

        public PokerPatternCheckingPackage GetPatternCheckingPackageInstance()
        {
            return new PokerPatternCheckingPackage(GetSetCheckerInstance(), GetStraightCheckerInstance(), GetFlushCheckerInstance());
        }

        public IPokerHandPatternChecker GetFlushCheckerInstance()
        {
            return new FlushChecker();
        }

        public IPokerHandPatternChecker GetSetCheckerInstance()
        {
            return new SetChecker();
        }

        public IPokerHandPatternChecker GetStraightCheckerInstance()
        {
            return new StraightChecker(handSorterFactory.GetHandSorterInstance());
        }

        public ISetDataMatcher GetSetDataMatcherInstance()
        {
            return new StrictSetDataMatcher();
        }

        public ISetDiagnosticsTool GetSetDiagnosticsToolInstance()
        {
            return new SetDiagnosticsTool(valueIteratorFactory.GetHighKindValueIteratorInstance());
        }
    }
}
