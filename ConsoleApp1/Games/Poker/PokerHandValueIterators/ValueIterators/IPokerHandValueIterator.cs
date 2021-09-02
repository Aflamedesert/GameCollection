using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators
{
    public interface IPokerHandValueIterator
    {
        List<IPokerCard> GetHighestPartOfHand(List<IPokerCard> passedCards);
    }
}
