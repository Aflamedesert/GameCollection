using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers;

namespace GameCollection.Games.Poker.PokerArchetypeHandling
{
    class PokerThreeOfAKindArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighKindValueIterator highKindIterator;

        AbstractHighCardValueIterator highCardIterator;

        IPokerArchetypeMatcher threeOfAKindMatcher;

        public PokerThreeOfAKindArchetypeFactory(AbstractHighKindValueIterator passedHighKindIterator, AbstractHighCardValueIterator passedHighCardIterator, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            highKindIterator = passedHighKindIterator;
            highCardIterator = passedHighCardIterator;

            threeOfAKindMatcher = new PokerThreeOfAKindMatcher(passedHighKindIterator, passedPatternCheckingPackage);
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
