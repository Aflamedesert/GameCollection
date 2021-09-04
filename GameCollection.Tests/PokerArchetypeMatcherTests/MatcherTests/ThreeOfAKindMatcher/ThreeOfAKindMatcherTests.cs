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

namespace GameCollection.Tests.PokerArchetypeMatcherTests.MatcherTests.ThreeOfAKindMatcher
{
    class SuccessfulParameters : TheoryData<List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetThreeOfAKind());
            Add(TestDataFactory.GetThreeOfAKind2());
            Add(TestDataFactory.GetThreeOfAKind3());
        }
    }

    class FailedParameters : TheoryData<List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetHighCard());
            Add(TestDataFactory.GetPair());
            Add(TestDataFactory.GetTwoPair());
            Add(TestDataFactory.GetStraight());
            Add(TestDataFactory.GetFlush());
            Add(TestDataFactory.GetFullHouse());
            Add(TestDataFactory.GetFourOfAKind());
            Add(TestDataFactory.GetStraightFlush());
            Add(TestDataFactory.GetRoyalFlush());
        }
    }

    [Collection("PokerArchetypeMatcherTests")]
    public class ThreeOfAKindMatcherTests
    {
        IPokerArchetypeMatcher matcher;

        public ThreeOfAKindMatcherTests(PokerArchetypeMatcherTestCollectionFixture fixture)
        {
            matcher = fixture.factory.GetThreeOfAKindMatcherInstance();
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
