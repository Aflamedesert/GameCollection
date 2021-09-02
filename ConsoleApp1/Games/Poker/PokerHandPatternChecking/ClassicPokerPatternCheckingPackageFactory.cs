using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandPatternCheckers;
using GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandSorting;

namespace GameCollection.Games.Poker.PokerHandPatternChecking
{
    public class ClassicPokerPatternCheckingFactory : IPokerPatternCheckingFactory
    {
        IPokerHandSorterFactory handSorterFactory;

        public ClassicPokerPatternCheckingFactory(IPokerHandSorterFactory passedHandSorterFactory)
        {
            handSorterFactory = passedHandSorterFactory;
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
            throw new NotImplementedException();
        }

        public ISetDiagnosticsTool GetSetDiagnosticsToolInstance()
        {
            throw new NotImplementedException();
        }
    }
}
