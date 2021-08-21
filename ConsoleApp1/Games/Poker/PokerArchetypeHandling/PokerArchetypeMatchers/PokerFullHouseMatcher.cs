using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerArchetypeHelper;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers
{
    public class PokerFullHouseMatcher : IPokerArchetypeMatcher
    {
        IPokerArchetypeHelper archetypeHelper;

        public PokerFullHouseMatcher(IPokerArchetypeHelper passedArchetypeHelper)
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
