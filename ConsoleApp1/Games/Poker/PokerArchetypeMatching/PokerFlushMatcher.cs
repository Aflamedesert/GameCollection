using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerArchetypeMatchers;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.StandardMatcherHelper.PokerMatcherHelper;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers
{
    public class PokerFlushMatcher : IPokerArchetypeMatcher
    {
        IPokerMatcherHelper archetypeHelper;

        public PokerFlushMatcher(IPokerMatcherHelper passedArchetypeHelper)
        {
            archetypeHelper = passedArchetypeHelper;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            bool isFlush = true;

            return archetypeHelper.isPatternMatch(passedCards, isFlush);
        }
    }
}
