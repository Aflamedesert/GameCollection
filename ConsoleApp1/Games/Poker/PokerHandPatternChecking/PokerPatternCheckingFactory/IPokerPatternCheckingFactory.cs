using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics;

namespace GameCollection.Games.Poker.PokerHandPatternChecking.PokerPatternCheckingFactory
{
    public interface IPokerPatternCheckingFactory
    {
        PokerPatternCheckingPackage GetPatternCheckingPackageInstance();
        IPokerHandPatternChecker GetFlushCheckerInstance();
        IPokerHandPatternChecker GetStraightCheckerInstance();
        IPokerHandPatternChecker GetSetCheckerInstance();
        ISetDataMatcher GetSetDataMatcherInstance();
        ISetDiagnosticsTool GetSetDiagnosticsToolInstance();
    }
}
