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

namespace GameCollection.Tests.PokerArchetypeMatcherTests.MatcherTests.FullHouseMatcher
{
    class SuccessfulParameters : TheoryData<List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            List<IPokerCard> handVariation = new List<IPokerCard>()
            {
                new PokerFaceCard("Jack", 11, "Spades", null),
                new PokerFaceCard("Jack", 11, "Hearts", null),
                new PokerNumberCard(10, "Diamonds", null),
                new PokerNumberCard(10, "Clubs", null),
                new PokerNumberCard(10, "Spades", null)
            };

            Add(handVariation);
            Add(TestDataFactory.GetFullHouse());
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
            matcher = new PokerFullHouseMatcher(factory.GetStrictArchetypeHelperInstance());
        }
    }

    public class FullHouseMatcherTests : IClassFixture<TestSetup>
    {
        IPokerArchetypeMatcher matcher;

        public FullHouseMatcherTests(TestSetup setup)
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
