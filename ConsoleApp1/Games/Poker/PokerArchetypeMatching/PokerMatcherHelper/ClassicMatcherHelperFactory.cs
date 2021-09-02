using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerRoyalFlushHelper;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerStraightFlushHelper;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.StandardMatcherHelper.PokerMatcherHelper;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.StandardMatcherHelper.PokerMatcherHelperBase;

namespace GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper
{
    public class ClassicMatcherHelperFactory : IMatcherHelperFactory
    {
        IPokerHandValueIteratorFactory handValueIteratorFactory;

        IPokerPatternCheckingFactory patternCheckingFactory;

        public ClassicMatcherHelperFactory(IPokerHandValueIteratorFactory passedValueIteratorFactory, IPokerPatternCheckingFactory passedPatternCheckingFactory)
        {
            handValueIteratorFactory = passedValueIteratorFactory;
            patternCheckingFactory = passedPatternCheckingFactory;
        }

        public IRoyalFlushHelper GetRoyalFlushMatcherHelper()
        {
            return new RoyalFlushHelper(GetStraightFlushMatcherHelper(), handValueIteratorFactory.GetHighCardValueIteratorInstance(), "Ace");
        }

        public IPokerMatcherHelper GetStandardMatcherHelper()
        {
            IPokerMatcherHelperBase helperBase = new ClassicPokerMatcherHelperBase(patternCheckingFactory.GetSetDiagnosticsToolInstance(),
                patternCheckingFactory.GetSetDataMatcherInstance(), patternCheckingFactory.GetPatternCheckingPackageInstance());

            return new StrictPokerMatcherHelper(helperBase);
        }

        public IStraightFlushHelper GetStraightFlushMatcherHelper()
        {
            return new FiveCardStraightFlushHelper(patternCheckingFactory.GetFlushCheckerInstance(), patternCheckingFactory.GetStraightCheckerInstance());
        }
    }
}
