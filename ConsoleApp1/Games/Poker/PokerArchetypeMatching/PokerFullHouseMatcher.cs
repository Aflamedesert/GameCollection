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
    public class PokerFullHouseMatcher : IPokerArchetypeMatcher
    {
        IPokerMatcherHelper archetypeHelper;

        public PokerFullHouseMatcher(IPokerMatcherHelper passedArchetypeHelper)
        {
            archetypeHelper = passedArchetypeHelper;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            List<int> targetSet = new List<int>()
            {
                3,
                2
            };

            return archetypeHelper.isPatternMatch(passedCards, setTarget: targetSet);
        }
    }
}
