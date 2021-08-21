using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Tests.PokerArchetypeMatcherTests.InstanceFactory;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers;
using GameCollection.Games.Poker.PokerFactories;
using Xunit;

namespace GameCollection.Tests.PokerArchetypeMatcherTests.MatcherTests.PairMatcher
{
    class SuccessfulParameters : TheoryData<List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            List<IPokerCard> HandVariation = new List<IPokerCard>()
            {
                new PokerFaceCard("Jack", 11, "Clubs", null),
                new PokerFaceCard("King", 13, "Clubs", null),
                new PokerFaceCard("King", 13, "Hearts", null),
                new PokerNumberCard(3, "Hearts", null),
                new PokerNumberCard(5, "Hearts", null),
            };

            Add(HandVariation);
            Add(TestDataFactory.GetPair());
        }
    }

    class FailedParameters : TheoryData<List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetHighCard());
            Add(TestDataFactory.GetTwoPair());
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
            ClassicPokerFactory factory = new ClassicPokerFactory();
            matcher = new PokerPairMatcher(factory.GetStrictArchetypeHelperInstance());
        }
    }

    public class PairMatcherTests : IClassFixture<TestSetup>
    {
        IPokerArchetypeMatcher matcher;

        public PairMatcherTests(TestSetup setup)
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
