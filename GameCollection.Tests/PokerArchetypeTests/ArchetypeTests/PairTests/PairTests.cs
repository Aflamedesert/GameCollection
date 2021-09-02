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

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.PairTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetPair3(), TestDataFactory.GetPair2());
            Add(TestDataFactory.GetPair3(), TestDataFactory.GetPair());
            Add(TestDataFactory.GetPair(), TestDataFactory.GetPair2());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetPair(), TestDataFactory.GetPair());
            Add(TestDataFactory.GetPair2(), TestDataFactory.GetPair2());
            Add(TestDataFactory.GetPair3(), TestDataFactory.GetPair3());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetPair2(), TestDataFactory.GetPair3());
            Add(TestDataFactory.GetPair(), TestDataFactory.GetPair3());
            Add(TestDataFactory.GetPair2(), TestDataFactory.GetPair());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class PairTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public PairTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void PairTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetPairArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetPairArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void PairTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetPairArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetPairArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void PairTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetPairArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetPairArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
