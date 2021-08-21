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

namespace GameCollection.Tests.PokerArchetypeMatcherTests.MatcherTests.HighCardMatcher
{
    class SuccessfulParameters : TheoryData<List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            List<IPokerCard> highCardHand1 = new List<IPokerCard>()
            {
                new PokerFaceCard("Jack", 11, "Clubs", null),
                new PokerFaceCard("King", 13, "Clubs", null),
                new PokerFaceCard("Queen", 12, "Hearts", null),
                new PokerNumberCard(3, "Hearts", null),
                new PokerNumberCard(5, "Hearts", null),
            };

            Add(highCardHand1);
            Add(TestDataFactory.GetHighCard());
        }
    }

    class FailedParameters : TheoryData<List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetPair());
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

    public class HighCardTestSetup
    {
        public PokerHighCardMatcher matcher { get; }

        public HighCardTestSetup()
        {
            ClassicPokerFactory factory = new ClassicPokerFactory();
            matcher = new PokerHighCardMatcher(factory.GetStrictArchetypeHelperInstance());
        }
    }

    public class HighCardMatcherTests : IClassFixture<HighCardTestSetup>
    {
        PokerHighCardMatcher matcher;

        public HighCardMatcherTests(HighCardTestSetup testSetup)
        {
            matcher = testSetup.matcher;
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
