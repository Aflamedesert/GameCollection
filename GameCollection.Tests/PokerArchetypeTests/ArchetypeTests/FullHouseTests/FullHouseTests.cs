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

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.FullHouseTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetFullHouse3(), TestDataFactory.GetFullHouse());
            Add(TestDataFactory.GetFullHouse3(), TestDataFactory.GetFullHouse2());
            Add(TestDataFactory.GetFullHouse(), TestDataFactory.GetFullHouse2());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetFullHouse(), TestDataFactory.GetFullHouse());
            Add(TestDataFactory.GetFullHouse2(), TestDataFactory.GetFullHouse2());
            Add(TestDataFactory.GetFullHouse3(), TestDataFactory.GetFullHouse3());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetFullHouse(), TestDataFactory.GetFullHouse3());
            Add(TestDataFactory.GetFullHouse2(), TestDataFactory.GetFullHouse3());
            Add(TestDataFactory.GetFullHouse2(), TestDataFactory.GetFullHouse());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class FullHouseTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public FullHouseTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void FullHouseTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetFullHouseArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetFullHouseArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void FullHouseTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetFullHouseArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetFullHouseArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void FullHouseTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetFullHouseArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetFullHouseArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
