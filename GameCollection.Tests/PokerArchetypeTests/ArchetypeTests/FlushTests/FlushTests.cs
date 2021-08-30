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

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.FlushTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetFlush3(), TestDataFactory.GetFlush());
            Add(TestDataFactory.GetFlush3(), TestDataFactory.GetFlush2());
            Add(TestDataFactory.GetFlush(), TestDataFactory.GetFlush2());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetFlush(), TestDataFactory.GetFlush());
            Add(TestDataFactory.GetFlush2(), TestDataFactory.GetFlush2());
            Add(TestDataFactory.GetFlush3(), TestDataFactory.GetFlush3());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetFlush(), TestDataFactory.GetFlush3());
            Add(TestDataFactory.GetFlush2(), TestDataFactory.GetFlush3());
            Add(TestDataFactory.GetFlush2(), TestDataFactory.GetFlush());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class FlushTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public FlushTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void FlushTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetFlushArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetFlushArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void FlushTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetFlushArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetFlushArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void FlushTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetFlushArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetFlushArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
