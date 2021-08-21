using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers;
using GameCollection.Games.Poker.PokerHandPatternChecking;

namespace GameCollection.Games.Poker.PokerArchetypeHandling
{
    public class PokerStraightArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighCardValueIterator highCardIterator;

        IPokerArchetypeMatcher straightMatcher;

        public PokerStraightArchetypeFactory(IPokerArchetypeMatcher passedStraightMatcher, AbstractHighCardValueIterator passedHighCardIterator)
        {
            highCardIterator = passedHighCardIterator;

            straightMatcher = passedStraightMatcher;
        }

        public IPokerHandArchetype getArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerStraightArchetype(passedCards, highCardIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            return straightMatcher.isArchetypeMatch(passedCards);
        }
    }
}
