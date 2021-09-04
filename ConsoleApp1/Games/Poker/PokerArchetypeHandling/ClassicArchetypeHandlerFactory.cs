using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeMatching;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerArchetypeMatchers;
using GameCollection.Games.Poker.PokerHandArchetypes;

namespace GameCollection.Games.Poker.PokerArchetypeHandling
{
    class ClassicArchetypeHandlerFactory : IPokerArchetypeHandlerFactory
    {
        IPokerArchetypeMatcherFactory matcherFactory;

        IPokerHandArchetypeFactory archetypeFactory;

        public ClassicArchetypeHandlerFactory(IPokerArchetypeMatcherFactory passedMatcherFactory, IPokerHandArchetypeFactory passedArchetypeFactory)
        {
            matcherFactory = passedMatcherFactory;

            archetypeFactory = passedArchetypeFactory;
        }

        public IPokerArchetypeHandler GetFlushHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetFlushMatcherInstance(), archetypeFactory.GetFlushArchetypeInstance);
        }

        public IPokerArchetypeHandler GetFourOfAKindHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetFourOfAKindMatcherInstance(), archetypeFactory.GetFourOfAKindArchetypeInstance);
        }

        public IPokerArchetypeHandler GetFullHouseHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetFullHouseMatcherInstance(), archetypeFactory.GetFullHouseArchetypeInstance);
        }

        public IPokerArchetypeHandler GetHighCardHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetHighCardMatcherInstance(), archetypeFactory.GetHighCardArchetypeInstance);
        }

        public IPokerArchetypeHandler GetPairHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetPairMatcherInstance(), archetypeFactory.GetPairArchetypeInstance);
        }

        public IPokerArchetypeHandler GetRoyalFlushHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetRoyalFlushMatcherInstance(), archetypeFactory.GetRoyalFlushArchetypeInstance);
        }

        public IPokerArchetypeHandler GetStraightFlushHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetStraightFlushMatcherInstance(), archetypeFactory.GetStraightFlushArchetypeInstance);
        }

        public IPokerArchetypeHandler GetStraightHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetStraightMatcherInstance(), archetypeFactory.GetStraightArchetypeInstance);
        }

        public IPokerArchetypeHandler GetThreeOfAKindHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetThreeOfAKindMatcherInstance(), archetypeFactory.GetThreeOfAKindArchetypeInstance);
        }

        public IPokerArchetypeHandler GetTwoPairHandlerInstance()
        {
            return CreateHandlerInstance(matcherFactory.GetTwoPairMatcherInstance(), archetypeFactory.GetTwoPairArchetypeInstance);
        }

        private IPokerArchetypeHandler CreateHandlerInstance(IPokerArchetypeMatcher passedArchetypeMatcher, ArchetypeFactoryMethod passedFactoryMethod)
        {
            return new ClassicPokerArchetypeHandler(passedArchetypeMatcher, passedFactoryMethod);
        }
    }
}
