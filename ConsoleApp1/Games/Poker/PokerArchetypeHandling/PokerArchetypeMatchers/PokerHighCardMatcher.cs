using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerArchetypeHelper;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers
{
    public class PokerHighCardMatcher : IPokerArchetypeMatcher
    {
        IPokerArchetypeHelper archetypeHelper;

        public PokerHighCardMatcher(IPokerArchetypeHelper passedArchetypeHelper)
        {
            archetypeHelper = passedArchetypeHelper;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            bool isFlush = false;

            bool isStraight = false;

            bool hasSet = false;

            return archetypeHelper.isPatternMatch(passedCards, isFlush, isStraight, hasSet);
        }
    }
}
