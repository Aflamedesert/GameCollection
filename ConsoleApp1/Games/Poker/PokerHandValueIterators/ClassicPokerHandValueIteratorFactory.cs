using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;

namespace GameCollection.Games.Poker.PokerHandValueIterators
{
    public class ClassicPokerHandValueIteratorFactory : IPokerHandValueIteratorFactory
    {
        public AbstractHighCardValueIterator GetHighCardValueIteratorInstance()
        {
            return new HighCardValueIterator();
        }

        public AbstractHighKindValueIterator GetHighKindValueIteratorInstance()
        {
            return new HighKindValueIterator();
        }
    }
}
