using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeComparator;
using GameCollection.Games.Poker.PokerHandArchetypes;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Tests.PokerArchetypeTests.FactoryFixture
{
    public delegate IPokerHandArchetype ArchetypeFactoryMethod(List<IPokerCard> passedCards);

    public class DelegateTest
    {
        IPokerArchetypeComparator comparator;

        public DelegateTest(IPokerArchetypeComparator passedComparator)
        {
            comparator = passedComparator;
        }

        public bool? RunArchetypeTest(ArchetypeFactoryMethod passedFactoryMethod, List<IPokerCard> firstCards, List<IPokerCard> secondCards)
        {
            IPokerHandArchetype firstArchetype = passedFactoryMethod(firstCards);

            IPokerHandArchetype secondArchetype = passedFactoryMethod(secondCards);

            return comparator.isFirstBetterThanSecond(firstArchetype, secondArchetype);
        }
    }
}
