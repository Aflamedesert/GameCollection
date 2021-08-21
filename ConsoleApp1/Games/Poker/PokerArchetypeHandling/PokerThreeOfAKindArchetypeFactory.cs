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
    public class PokerThreeOfAKindArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighKindValueIterator highKindIterator;

        AbstractHighCardValueIterator highCardIterator;

        IPokerArchetypeMatcher threeOfAKindMatcher;

        public PokerThreeOfAKindArchetypeFactory(IPokerArchetypeMatcher passedThreeOfAKindMatcher, AbstractHighKindValueIterator passedHighKindIterator, AbstractHighCardValueIterator passedHighCardIterator)
        {
            highKindIterator = passedHighKindIterator;
            highCardIterator = passedHighCardIterator;

            threeOfAKindMatcher = passedThreeOfAKindMatcher;
        }

        public IPokerHandArchetype getArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerThreeOfAKindArchetype(passedCards, highKindIterator, highCardIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            return threeOfAKindMatcher.isArchetypeMatch(passedCards);
        }
    }
}
