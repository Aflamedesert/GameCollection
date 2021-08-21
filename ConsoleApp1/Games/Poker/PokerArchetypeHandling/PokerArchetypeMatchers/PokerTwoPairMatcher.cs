using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerArchetypeHelper;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers
{
    public class PokerTwoPairMatcher : IPokerArchetypeMatcher
    {
        IPokerArchetypeHelper archetypeHelper;

        public PokerTwoPairMatcher(IPokerArchetypeHelper passedArchetypeHelper)
        {
            archetypeHelper = passedArchetypeHelper;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            List<int> targetSet = new List<int>()
            {
                2,
                2
            };

            return archetypeHelper.isPatternMatch(passedCards, setTarget: targetSet);
        }
    }
}
