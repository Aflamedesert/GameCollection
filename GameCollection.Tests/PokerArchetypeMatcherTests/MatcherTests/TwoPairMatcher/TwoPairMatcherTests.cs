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

namespace GameCollection.Tests.PokerArchetypeMatcherTests.MatcherTests.TwoPairMatcher
{
    class SuccessfulParameters : TheoryData<List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetTwoPair());
            Add(TestDataFactory.GetTwoPair2());
            Add(TestDataFactory.GetTwoPair3());
        }
    }

    class FailedParameters : TheoryData<List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetHighCard());
            Add(TestDataFactory.GetPair());
            Add(TestDataFactory.GetThreeOfAKind());
            Add(TestDataFactory.GetStraight());
            Add(TestDataFactory.GetFlush());
            Add(TestDataFactory.GetFullHouse());
            Add(TestDataFactory.GetFourOfAKind());
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
                2,
                2
            };

            ClassicPokerFactory factory = new ClassicPokerFactory();
            //matcher = new PokerTwoPairMatcher(factory.GetStrictArchetypeHelperInstance());
            matcher = new ClassicPokerArchetypeMatcher(factory.GetStrictArchetypeHelperInstance(), factory.GetFiveCardStraightFlushHelperInstance(),
                factory.GetRoyalFlushHelperInstance(), setTarget: targetSet);
        }
    }

    public class TwoPairMatcherTests : IClassFixture<TestSetup>
    {
        IPokerArchetypeMatcher matcher;

        public TwoPairMatcherTests(TestSetup setup)
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
