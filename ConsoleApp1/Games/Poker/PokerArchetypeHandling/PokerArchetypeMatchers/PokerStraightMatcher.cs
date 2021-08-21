using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerArchetypeHelper;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers
{
    public class PokerStraightMatcher : IPokerArchetypeMatcher
    {
        IPokerArchetypeHelper archetypeHelper;

        public PokerStraightMatcher(IPokerArchetypeHelper passedArchetypeHelper)
        {
            archetypeHelper = passedArchetypeHelper;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            bool isStraight = true;

            return archetypeHelper.isPatternMatch(passedCards, isStraight: isStraight);
        }
    }
}
