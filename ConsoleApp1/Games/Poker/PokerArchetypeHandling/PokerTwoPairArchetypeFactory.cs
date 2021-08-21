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
    public class PokerTwoPairArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighKindValueIterator highKindIterator;

        AbstractHighCardValueIterator highCardIterator;

        IPokerArchetypeMatcher twoPairMatcher;

        public PokerTwoPairArchetypeFactory(IPokerArchetypeMatcher passedTwoPairMatcher, AbstractHighKindValueIterator passedHighKindIterator, AbstractHighCardValueIterator passedHighCardIterator)
        {
            highKindIterator = passedHighKindIterator;
            highCardIterator = passedHighCardIterator;

            twoPairMatcher = passedTwoPairMatcher;
        }

        public IPokerHandArchetype getArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerTwoPairArchetype(passedCards, highKindIterator, highCardIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            return twoPairMatcher.isArchetypeMatch(passedCards);
        }
    }
}
