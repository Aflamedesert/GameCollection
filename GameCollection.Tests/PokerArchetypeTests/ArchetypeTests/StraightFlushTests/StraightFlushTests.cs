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

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.StraightFlushTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetStraightFlush3(), TestDataFactory.GetStraightFlush());
            Add(TestDataFactory.GetStraight3(), TestDataFactory.GetStraightFlush2());
            Add(TestDataFactory.GetStraightFlush(), TestDataFactory.GetStraightFlush2());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetStraightFlush(), TestDataFactory.GetStraightFlush());
            Add(TestDataFactory.GetStraightFlush2(), TestDataFactory.GetStraightFlush2());
            Add(TestDataFactory.GetStraightFlush3(), TestDataFactory.GetStraightFlush3());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetStraightFlush(), TestDataFactory.GetStraightFlush3());
            Add(TestDataFactory.GetStraightFlush2(), TestDataFactory.GetStraightFlush3());
            Add(TestDataFactory.GetStraightFlush2(), TestDataFactory.GetStraightFlush());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class StraightFlushTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public StraightFlushTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void StraightFlushTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetStraightFlushArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetStraightFlushArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void StraightFlushTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetStraightFlushArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetStraightFlushArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void StraightFlushTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetStraightFlushArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetStraightFlushArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
