using GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandValueIterators
{
    public interface IPokerHandValueIteratorFactory
    {
        AbstractHighCardValueIterator GetHighCardValueIteratorInstance();
        AbstractHighKindValueIterator GetHighKindValueIteratorInstance();
    }
}
