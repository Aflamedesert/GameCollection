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
    public class PokerFullHouseArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighKindValueIterator highKindIterator;

        IPokerArchetypeMatcher fullHouseMatcher;

        public PokerFullHouseArchetypeFactory(IPokerArchetypeMatcher passedFullHouseMatcher, AbstractHighKindValueIterator passedHighKindIterator)
        {
            highKindIterator = passedHighKindIterator;

            fullHouseMatcher = passedFullHouseMatcher;
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
