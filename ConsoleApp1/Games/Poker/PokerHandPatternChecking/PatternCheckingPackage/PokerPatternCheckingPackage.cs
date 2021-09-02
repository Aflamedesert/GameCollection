using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandPatternCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandPatternChecking
{
    public class PokerPatternCheckingPackage
    {
        public IPokerHandPatternChecker setChecker { get; private set; }

        public IPokerHandPatternChecker straightChecker { get; private set; }

        public IPokerHandPatternChecker flushChecker { get; private set; }

        public PokerPatternCheckingPackage(IPokerHandPatternChecker passedSetChecker, IPokerHandPatternChecker passedStraightChecker, IPokerHandPatternChecker passedFlushChecker)
        {
            setChecker = passedSetChecker;
            straightChecker = passedStraightChecker;
            flushChecker = passedFlushChecker;
        }
    }
}
