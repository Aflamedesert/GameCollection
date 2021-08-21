﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers;
using GameCollection.Games.Poker.PokerHandPatternChecking;

namespace GameCollection.Games.Poker.PokerArchetypeHandling
{
    public class PokerHighCardArchetypeFactory : IPokerArchetypeFactory
    {
        AbstractHighCardValueIterator highCardIterator;

        IPokerArchetypeMatcher highCardMatcher;

        public PokerHighCardArchetypeFactory(IPokerArchetypeMatcher passedHighCardMatcher, AbstractHighCardValueIterator passedHighCardIterator)
        {
            highCardIterator = passedHighCardIterator;

            highCardMatcher = passedHighCardMatcher;
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
