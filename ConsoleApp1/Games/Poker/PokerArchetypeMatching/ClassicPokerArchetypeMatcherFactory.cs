using GameCollection.Games.Poker.PokerArchetypeMatching.PokerArchetypeMatchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper;

namespace GameCollection.Games.Poker.PokerArchetypeMatching
{
    public class ClassicPokerArchetypeMatcherFactory : IPokerArchetypeMatcherFactory
    {
        IMatcherHelperFactory matcherHelperFactory;

        public ClassicPokerArchetypeMatcherFactory(IMatcherHelperFactory passedMatcherHelperFactory)
        {
            matcherHelperFactory = passedMatcherHelperFactory;
        }

        public IPokerArchetypeMatcher GetHighCardMatcherInstance()
        {
            return CreateMatcherInstance(false, false, false);
        }

        public IPokerArchetypeMatcher GetPairMatcherInstance()
        {
            List<int> targetSet = new List<int>()
            {
                2
            };

            return CreateMatcherInstance(setTarget: targetSet);
        }

        public IPokerArchetypeMatcher GetTwoPairMatcherInstance()
        {
            List<int> targetSet = new List<int>()
            {
                2,
                2
            };

            return CreateMatcherInstance(setTarget: targetSet);
        }

        public IPokerArchetypeMatcher GetThreeOfAKindMatcherInstance()
        {
            List<int> targetSet = new List<int>()
            {
                3
            };

            return CreateMatcherInstance(setTarget: targetSet);
        }

        public IPokerArchetypeMatcher GetStraightMatcherInstance()
        {
            return CreateMatcherInstance(isStraight: true);
        }

        public IPokerArchetypeMatcher GetFlushMatcherInstance()
        {
            return CreateMatcherInstance(isFlush: true);
        }

        public IPokerArchetypeMatcher GetFullHouseMatcherInstance()
        {
            List<int> targetSet = new List<int>()
            {
                3,
                2
            };

            return CreateMatcherInstance(setTarget: targetSet);
        }

        public IPokerArchetypeMatcher GetFourOfAKindMatcherInstance()
        {
            List<int> targetSet = new List<int>()
            {
                4
            };

            return CreateMatcherInstance(setTarget: targetSet);
        }

        public IPokerArchetypeMatcher GetStraightFlushMatcherInstance()
        {
            return CreateMatcherInstance(isFlush: true, isStraight: true);
        }

        public IPokerArchetypeMatcher GetRoyalFlushMatcherInstance()
        {
            return CreateMatcherInstance(isRoyalFlush: true);
        }

        private ClassicPokerArchetypeMatcher CreateMatcherInstance(bool? isFlush = null, bool? isStraight = null, bool? hasSet = null, bool? isRoyalFlush = null, List<int> setTarget = null)
        {
            return new ClassicPokerArchetypeMatcher(
                matcherHelperFactory.GetStandardMatcherHelper(), matcherHelperFactory.GetStraightFlushMatcherHelper(), matcherHelperFactory.GetRoyalFlushMatcherHelper(),
                isFlush, isStraight, hasSet, isRoyalFlush, setTarget);
        }
    }
}
