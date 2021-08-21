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
    public class PokerPairArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighKindValueIterator highKindIterator;

        AbstractHighCardValueIterator highCardIterator;

        IPokerArchetypeMatcher pairMatcher;

        public PokerPairArchetypeFactory(IPokerArchetypeMatcher passedPairMatcher, AbstractHighKindValueIterator passedHighKindIterator, AbstractHighCardValueIterator passedHighCardIterator)
        {
            highKindIterator = passedHighKindIterator;
            highCardIterator = passedHighCardIterator;

            pairMatcher = passedPairMatcher;
        }
        public IPokerHandArchetype getArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerPairArchetype(passedCards, highKindIterator, highCardIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            return pairMatcher.isArchetypeMatch(passedCards);
        }
    }
}
