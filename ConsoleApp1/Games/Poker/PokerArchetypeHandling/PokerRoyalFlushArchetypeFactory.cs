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
    class PokerRoyalFlushArchetypeFactory : IPokerArchetypeFactory
    {
        List<string> suitRankings;

        IPokerArchetypeMatcher royalFlushMatcher;
        public PokerRoyalFlushArchetypeFactory(AbstractHighCardValueIterator passedHighCardIterator, PokerPatternCheckingPackage passedPatternCheckingPackage, List<string> passedSuitRankings)
        {
            suitRankings = passedSuitRankings;

            royalFlushMatcher = new PokerRoyalFlushMatcher(passedHighCardIterator, passedPatternCheckingPackage);
        }

        public IPokerHandArchetype getArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerRoyalFlushArchetype(passedCards, suitRankings);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            return royalFlushMatcher.isArchetypeMatch(passedCards);
        }
    }
}
