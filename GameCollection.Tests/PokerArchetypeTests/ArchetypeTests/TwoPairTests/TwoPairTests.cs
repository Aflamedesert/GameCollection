using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerArchetypeComparator;
using GameCollection.Games.Poker.PokerHandArchetypes;
using GameCollection.Tests.PokerArchetypeTests.FactoryFixture;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeFactories;
using GameCollection.Tests.DataFactory;
using Xunit;

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.TwoPairTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetTwoPair3(), TestDataFactory.GetTwoPair());
            Add(TestDataFactory.GetTwoPair3(), TestDataFactory.GetTwoPair2());
            Add(TestDataFactory.GetTwoPair(), TestDataFactory.GetTwoPair2());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetTwoPair(), TestDataFactory.GetTwoPair());
            Add(TestDataFactory.GetTwoPair2(), TestDataFactory.GetTwoPair2());
            Add(TestDataFactory.GetTwoPair3(), TestDataFactory.GetTwoPair3());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetTwoPair(), TestDataFactory.GetTwoPair3());
            Add(TestDataFactory.GetTwoPair2(), TestDataFactory.GetTwoPair3());
            Add(TestDataFactory.GetTwoPair2(), TestDataFactory.GetTwoPair());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class TwoPairTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public TwoPairTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void TwoPairTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetTwoPairArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetTwoPairArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void TwoPairTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetTwoPairArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetTwoPairArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void TwoPairTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetTwoPairArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetTwoPairArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
