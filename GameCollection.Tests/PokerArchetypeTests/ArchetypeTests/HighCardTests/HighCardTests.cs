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

namespace GameCollection.Tests.PokerArchetypeTests.ArchetypeTests.HighCardTests
{
    public class SuccessfulParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public SuccessfulParameters()
        {
            Add(TestDataFactory.GetHighCard(), TestDataFactory.GetHighCard2());
            Add(TestDataFactory.GetHighCard3(), TestDataFactory.GetHighCard2());
            Add(TestDataFactory.GetHighCard3(), TestDataFactory.GetHighCard());
        }
    }

    public class NullParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public NullParameters()
        {
            Add(TestDataFactory.GetHighCard2(), TestDataFactory.GetHighCard2());
            Add(TestDataFactory.GetHighCard3(), TestDataFactory.GetHighCard3());
            Add(TestDataFactory.GetHighCard(), TestDataFactory.GetHighCard());
        }
    }

    public class FailedParameters : TheoryData<List<IPokerCard>, List<IPokerCard>>
    {
        public FailedParameters()
        {
            Add(TestDataFactory.GetHighCard2(), TestDataFactory.GetHighCard());
            Add(TestDataFactory.GetHighCard2(), TestDataFactory.GetHighCard3());
            Add(TestDataFactory.GetHighCard(), TestDataFactory.GetHighCard3());
        }
    }

    [Collection("PokerArchetypeTests")]
    public class HighCardTests
    {
        IPokerHandArchetypeFactory archetypeFactory;

        IPokerArchetypeComparator comparator;

        public HighCardTests(PokerArchetypeTestCollectionFixture factoryFixture)
        {
            archetypeFactory = factoryFixture.factory;

            comparator = factoryFixture.comparator;
        }


        [Theory]
        [ClassData(typeof(SuccessfulParameters))]
        public void HighCardTest_ShouldBeTrue(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetHighCardArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetHighCardArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.True(actual);
        }


        [Theory]
        [ClassData(typeof(NullParameters))]
        public void HighCardTest_ShouldBeNull(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetHighCardArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetHighCardArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(FailedParameters))]
        public void HighCardTest_ShouldBeFalse(List<IPokerCard> firstHand, List<IPokerCard> secondHand)
        {
            IPokerHandArchetype firstHandArchetype = archetypeFactory.GetHighCardArchetypeInstance(firstHand);

            IPokerHandArchetype secondArchetype = archetypeFactory.GetHighCardArchetypeInstance(secondHand);

            bool? actual = comparator.isFirstBetterThanSecond(firstHandArchetype, secondArchetype);

            Assert.False(actual);
        }
    }
}
