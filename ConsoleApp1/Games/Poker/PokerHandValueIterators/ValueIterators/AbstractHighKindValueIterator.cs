using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators
{
    public abstract class AbstractHighKindValueIterator : IPokerHandValueIterator
    {
        public virtual List<IPokerCard> GetHighestPartOfHand(List<IPokerCard> passedCards)
        {
            return GetHighSetOfCards(passedCards);
        }

        public abstract List<IPokerCard> GetHighSetOfCards(List<IPokerCard> passedCards);
    }
}
