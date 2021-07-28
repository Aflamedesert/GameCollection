using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers;

namespace GameCollection.Games.Poker.PokerArchetypeHandling
{
    class PokerHighCardArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighCardValueIterator highCardIterator;

        IPokerArchetypeMatcher highCardMatcher;

        public PokerHighCardArchetypeFactory(AbstractHighCardValueIterator passedHighCardIterator, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            highCardIterator = passedHighCardIterator;

            highCardMatcher = new PokerHighCardMatcher(passedPatternCheckingPackage);
        }
        public IPokerHandArchetype getArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerHighCardArchetype(passedCards, highCardIterator);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            return highCardMatcher.isArchetypeMatch(passedCards);
        }
    }
}
