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

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.FourOfAKindTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetFourOfAKind3(), TestDataFactory.GetFourOfAKind());
            Add(TestDataFactory.GetFourOfAKind3(), TestDataFactory.GetFourOfAKind2());
            Add(TestDataFactory.GetFourOfAKind(), TestDataFactory.GetFourOfAKind2());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetFourOfAKind(), TestDataFactory.GetFourOfAKind());
            Add(TestDataFactory.GetFourOfAKind2(), TestDataFactory.GetFourOfAKind2());
            Add(TestDataFactory.GetFourOfAKind3(), TestDataFactory.GetFourOfAKind3());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetFourOfAKind(), TestDataFactory.GetFourOfAKind3());
            Add(TestDataFactory.GetFourOfAKind2(), TestDataFactory.GetFourOfAKind3());
            Add(TestDataFactory.GetFourOfAKind2(), TestDataFactory.GetFourOfAKind());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class FourOfAKindTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public FourOfAKindTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void FourOfAKindTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetFourOfAKindArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetFourOfAKindArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void FourOfAKindTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetFourOfAKindArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetFourOfAKindArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void FourOfAKindTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetFourOfAKindArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetFourOfAKindArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
