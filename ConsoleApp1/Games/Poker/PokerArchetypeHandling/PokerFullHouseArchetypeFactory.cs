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
    class PokerFullHouseArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighKindValueIterator highKindIterator;

        IPokerArchetypeMatcher fullHouseMatcher;

        public PokerFullHouseArchetypeFactory(AbstractHighKindValueIterator passedHighKindIterator, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            highKindIterator = passedHighKindIterator;

            fullHouseMatcher = new PokerFullHouseMatcher(passedHighKindIterator, passedPatternCheckingPackage);
        }

        public IPokerHandArchetype getArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerFullHouseArchetype(passedCards, highKindIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            return fullHouseMatcher.isArchetypeMatch(passedCards);
        }
    }
}
