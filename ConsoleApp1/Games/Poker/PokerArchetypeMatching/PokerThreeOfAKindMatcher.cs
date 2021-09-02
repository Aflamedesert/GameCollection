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
    public class PokerThreeOfAKindMatcher : IPokerArchetypeMatcher
    {
        IPokerMatcherHelper archetypeHelper;

        public PokerThreeOfAKindMatcher(IPokerMatcherHelper passedArchtypeHelper)
        {
            archetypeHelper = passedArchtypeHelper;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            List<int> targetSet = new List<int>()
            {
                3
            };

            return archetypeHelper.isPatternMatch(passedCards, setTarget: targetSet);
        }
    }
}
