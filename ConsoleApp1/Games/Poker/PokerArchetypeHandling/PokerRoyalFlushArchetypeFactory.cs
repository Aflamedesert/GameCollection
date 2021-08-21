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
    public class PokerRoyalFlushArchetypeFactory : IPokerArchetypeFactory
    {
        List<string> suitRankings;

        IPokerArchetypeMatcher royalFlushMatcher;
        public PokerRoyalFlushArchetypeFactory(IPokerArchetypeMatcher passedRoyalFlushMatcher, AbstractHighCardValueIterator passedHighCardIterator, List<string> passedSuitRankings)
        {
            suitRankings = passedSuitRankings;

            royalFlushMatcher = passedRoyalFlushMatcher;
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
