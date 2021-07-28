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
    class PokerStraightFlushArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighCardValueIterator highCardIterator;

        List<string> suitRankings;

        IPokerArchetypeMatcher straightFlushMatcher;

        public PokerStraightFlushArchetypeFactory(AbstractHighCardValueIterator passedHighCardIterator, PokerPatternCheckingPackage passedPatternCheckingPackage, List<string> passedSuitRankings)
        {
            highCardIterator = passedHighCardIterator;

            suitRankings = passedSuitRankings;

            straightFlushMatcher = new PokerStraightFlushMatcher(passedHighCardIterator, passedPatternCheckingPackage);
        }

        public IPokerHandArchetype getArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerStraightFlushArchetype(passedCards, highCardIterator, suitRankings);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            return straightFlushMatcher.isArchetypeMatch(passedCards);
        }
    }
}
