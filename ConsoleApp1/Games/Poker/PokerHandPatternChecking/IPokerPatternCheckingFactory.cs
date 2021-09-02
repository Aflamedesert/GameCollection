using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandPatternCheckers;

namespace GameCollection.Games.Poker.PokerHandPatternChecking
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
