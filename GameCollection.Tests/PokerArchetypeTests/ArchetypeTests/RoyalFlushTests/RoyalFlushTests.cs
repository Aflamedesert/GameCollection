using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerArchetypeComparator;
using GameCollection.Tests.PokerArchetypeTests.FactoryFixture;
using GameCollection.Tests.DataFactory;
using Xunit;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes;
using GameCollection.Games.Poker.PokerHandArchetypes;

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.RoyalFlushTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetRoyalFlush3(), TestDataFactory.GetRoyalFlush());
            Add(TestDataFactory.GetRoyalFlush3(), TestDataFactory.GetRoyalFlush2());
            Add(TestDataFactory.GetRoyalFlush(), TestDataFactory.GetRoyalFlush2());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetRoyalFlush(), TestDataFactory.GetRoyalFlush());
            Add(TestDataFactory.GetRoyalFlush2(), TestDataFactory.GetRoyalFlush2());
            Add(TestDataFactory.GetRoyalFlush3(), TestDataFactory.GetRoyalFlush3());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetRoyalFlush(), TestDataFactory.GetRoyalFlush3());
            Add(TestDataFactory.GetRoyalFlush2(), TestDataFactory.GetRoyalFlush3());
            Add(TestDataFactory.GetRoyalFlush2(), TestDataFactory.GetRoyalFlush());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class RoyalFlushTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public RoyalFlushTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void RoyalFlushTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetRoyalFlushArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetRoyalFlushArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void RoyalFlushTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetRoyalFlushArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetRoyalFlushArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void RoyalFlushTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetRoyalFlushArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetRoyalFlushArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
