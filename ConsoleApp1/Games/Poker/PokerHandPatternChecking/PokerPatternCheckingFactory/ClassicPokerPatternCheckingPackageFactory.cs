using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics;
using GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandPatternChecking.PokerPatternCheckingFactory
{
    public class ClassicPokerPatternCheckingFactory : IPokerPatternCheckingFactory
    {
        public PokerPatternCheckingPackage GetPatternCheckingPackageInstance()
        {

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
            return new StraightChecker();
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
