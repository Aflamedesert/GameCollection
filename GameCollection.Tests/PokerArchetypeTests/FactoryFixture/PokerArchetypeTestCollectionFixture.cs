using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeComparator;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeFactories;
using GameCollection.Games.Poker.PokerHandValueIterators.PokerHandValueIteratorFactories;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeFactories.PokerHandArchetypeComponentFactories;
using Xunit;

namespace GameCollection.Tests.PokerArchetypeTests.FactoryFixture
{
    public class PokerArchetypeTestCollectionFixture
    {
        public IPokerHandArchetypeFactory factory { get; }

        public IPokerArchetypeComparator comparator { get; }

        public PokerArchetypeTestCollectionFixture()
        {
            IPokerHandArchetypeComponentFactory componentFactory = new ClassicPokerHandArchetypeComponentFactory();
            IPokerHandValueIteratorFactory valueIteratorFactory = new ClassicPokerHandValueIteratorFactory();

            List<string> suitRankings = new List<string>()
            {
                "Clubs",
                "Diamonds",
                "Hearts",
                "Spades"
            };

            factory = new ClassicPokerHandArchetypeFactory(componentFactory, valueIteratorFactory, suitRankings);

            comparator = new ClassicPokerArchetypeComparator();
        }
    }

    [CollectionDefinition("PokerArchetypeTests")]
    public class PokerArchetypeTestCollection : ICollectionFixture<PokerArchetypeTestCollectionFixture>
    {
        //empty... used as a place to initiate the collection
    }
}
