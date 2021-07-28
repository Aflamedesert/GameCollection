using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandPatternChecking;

namespace GameCollection.Games.Poker.PokerArchetypeHandling
{
    class PokerPatternCheckingPackage
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
