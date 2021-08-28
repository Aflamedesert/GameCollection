using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandValueIterators.PokerHandValueIteratorFactories
{
    public interface IPokerHandValueIteratorFactory
    {
        AbstractHighCardValueIterator GetHighCardValueIteratorInstance();
        AbstractHighKindValueIterator GetHighKindValueIteratorInstance();
    }
}
