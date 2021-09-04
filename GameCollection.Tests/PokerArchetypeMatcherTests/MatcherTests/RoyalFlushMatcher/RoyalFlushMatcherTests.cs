using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Tests.DataFactory;
using GameCollection.Tests.PokerArchetypeMatcherTests.FactoryFixture;
using Xunit;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerArchetypeMatchers;

namespace GameCollection.Tests.PokerArchetypeMatcherTests.MatcherTests.RoyalFlushMatcher
{
    class SuccessfulParameters : TheoryData<List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetRoyalFlush());
            Add(TestDataFactory.GetRoyalFlush2());
            Add(TestDataFactory.GetRoyalFlush3());
        }
    }

    class FailedParameters : TheoryData<List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetHighCard());
            Add(TestDataFactory.GetPair());
            Add(TestDataFactory.GetTwoPair());
            Add(TestDataFactory.GetThreeOfAKind());
            Add(TestDataFactory.GetStraight());
            Add(TestDataFactory.GetFlush());
            Add(TestDataFactory.GetFullHouse());
            Add(TestDataFactory.GetFourOfAKind());
            Add(TestDataFactory.GetStraightFlush());
        }
    }

    [Collection("PokerArchetypeMatcherTests")]
    public class RoyalFlushMatcherTests
    {
        IPokerArchetypeMatcher matcher;

        public RoyalFlushMatcherTests(PokerArchetypeMatcherTestCollectionFixture fixture)
        {
            matcher = fixture.factory.GetRoyalFlushMatcherInstance();
        }

        [Theory]
        [Trait("Category", "PokerArchetypeMatcherTests")]
        [ClassData(typeof(SuccessfulParameters))]
        public void isArchetypeMatch_ShouldMatch(List<IPokerCard> passedTestCards)
        {
            bool actual = matcher.isArchetypeMatch(passedTestCards);
            Assert.True(actual);
        }

        [Theory]
        [Trait("Category", "PokerArchetypeMatcherTests")]
        [ClassData(typeof(FailedParameters))]
        public void isArchetypeMatch_ShouldNotMatch(List<IPokerCard> passedTestCards)
        {
            bool actual = matcher.isArchetypeMatch(passedTestCards);
            Assert.False(actual);
        }
    }
}
