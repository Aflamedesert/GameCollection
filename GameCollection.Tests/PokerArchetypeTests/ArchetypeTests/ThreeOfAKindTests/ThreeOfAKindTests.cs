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

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.ThreeOfAKindTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetThreeOfAKind3(), TestDataFactory.GetThreeOfAKind());
            Add(TestDataFactory.GetThreeOfAKind3(), TestDataFactory.GetThreeOfAKind2());
            Add(TestDataFactory.GetThreeOfAKind(), TestDataFactory.GetThreeOfAKind2());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetThreeOfAKind(), TestDataFactory.GetThreeOfAKind());
            Add(TestDataFactory.GetThreeOfAKind2(), TestDataFactory.GetThreeOfAKind2());
            Add(TestDataFactory.GetThreeOfAKind3(), TestDataFactory.GetThreeOfAKind3());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetThreeOfAKind(), TestDataFactory.GetThreeOfAKind3());
            Add(TestDataFactory.GetThreeOfAKind2(), TestDataFactory.GetThreeOfAKind3());
            Add(TestDataFactory.GetThreeOfAKind2(), TestDataFactory.GetThreeOfAKind());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class ThreeOfAKindTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public ThreeOfAKindTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void ThreeOfAKindTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetThreeOfAKindArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetThreeOfAKindArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void ThreeOfAKindTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetThreeOfAKindArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetThreeOfAKindArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void ThreeOfAKindTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetThreeOfAKindArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetThreeOfAKindArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
