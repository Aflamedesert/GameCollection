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

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.StraightTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetStraight3(), TestDataFactory.GetStraight());
            Add(TestDataFactory.GetStraight3(), TestDataFactory.GetStraight2());
            Add(TestDataFactory.GetStraight(), TestDataFactory.GetStraight2());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetStraight(), TestDataFactory.GetStraight());
            Add(TestDataFactory.GetStraight2(), TestDataFactory.GetStraight2());
            Add(TestDataFactory.GetStraight3(), TestDataFactory.GetStraight3());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetStraight(), TestDataFactory.GetStraight3());
            Add(TestDataFactory.GetStraight2(), TestDataFactory.GetStraight3());
            Add(TestDataFactory.GetStraight2(), TestDataFactory.GetStraight());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class StraightTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public StraightTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void StraightTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetStraightArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetStraightArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void StraightTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetStraightArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetStraightArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void StraightTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetStraightArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetStraightArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
