using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeMatching;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerHandSorting;
using Xunit;

namespace GameCollection.Tests.PokerArchetypeMatcherTests.FactoryFixture
{
    public class PokerArchetypeMatcherTestCollectionFixture
    {
        public IPokerArchetypeMatcherFactory factory { get; }

        public PokerArchetypeMatcherTestCollectionFixture()
        {
            IPokerHandValueIteratorFactory valueIteratorFactory = new ClassicPokerHandValueIteratorFactory();

            IPokerHandSorterFactory sorterFactory = new ClassicPokerHandSorterFactory(valueIteratorFactory);

            IPokerPatternCheckingFactory patternFactory = new ClassicPokerPatternCheckingFactory(sorterFactory, valueIteratorFactory);

            IMatcherHelperFactory matcherHelperFactory = new ClassicMatcherHelperFactory(valueIteratorFactory, patternFactory);

            factory = new ClassicPokerArchetypeMatcherFactory(matcherHelperFactory);
        }
    }

    [CollectionDefinition("PokerArchetypeMatcherTests")]
    public class PokerArchetypeTestCollection : ICollectionFixture<PokerArchetypeMatcherTestCollectionFixture>
    {
        //empty... used as a place to initiate the collection
    }
}
