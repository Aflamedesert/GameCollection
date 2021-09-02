using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Tests.DataFactory;
using GameCollection.Games.Poker.PokerFactories;
using Xunit;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerArchetypeMatchers;

namespace GameCollection.Tests.PokerArchetypeMatcherTests.MatcherTests.FourOfAKindMatcher
{
    class SuccessfulParameters : TheoryData<List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetFourOfAKind());
            Add(TestDataFactory.GetFourOfAKind2());
            Add(TestDataFactory.GetFourOfAKind3());
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
            Add(TestDataFactory.GetStraightFlush());
            Add(TestDataFactory.GetRoyalFlush());
        }
    }

    public class TestSetup
    {
        public IPokerArchetypeMatcher matcher { get; }

        public TestSetup()
        {
            List<int> targetSet = new List<int>()
            {
                4
            };

            ClassicPokerFactory factory = new ClassicPokerFactory();
            //matcher = new PokerFourOfAKindMatcher(factory.GetStrictArchetypeHelperInstance());
            matcher = new ClassicPokerArchetypeMatcher(factory.GetStrictArchetypeHelperInstance(), factory.GetFiveCardStraightFlushHelperInstance(),
                factory.GetRoyalFlushHelperInstance(), setTarget: targetSet);
        }
    }

    public class FourOfAKindMatcherTests : IClassFixture<TestSetup>
    {
        IPokerArchetypeMatcher matcher;

        public FourOfAKindMatcherTests(TestSetup setup)
        {
            matcher = setup.matcher;
        }

        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void isArchetypeMatch_ShouldMatch(List<IPokerCard> passedTestCards)
        {
            bool actual = matcher.isArchetypeMatch(passedTestCards);
            Assert.True(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void isArchetypeMatch_ShouldNotMatch(List<IPokerCard> passedTestCards)
        {
            bool actual = matcher.isArchetypeMatch(passedTestCards);
            Assert.False(actual);
        }
    }
}
