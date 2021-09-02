using GameCollection.Games.Poker.PokerHandSorting.HandSorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;

namespace GameCollection.Games.Poker.PokerHandSorting
{
    public class ClassicPokerHandSorterFactory : IPokerHandSorterFactory
    {
        IPokerHandValueIteratorFactory handValueIteratorFactory;

        public ClassicPokerHandSorterFactory(IPokerHandValueIteratorFactory passedHandValueIteratorFactory)
        {
            handValueIteratorFactory = passedHandValueIteratorFactory;
        }

        public IPokerHandSorter GetHandSorterInstance()
        {
            return new ClassicHandSorter(handValueIteratorFactory.GetHighCardValueIteratorInstance(), handValueIteratorFactory.GetHighKindValueIteratorInstance());
        }
    }
}
