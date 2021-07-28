using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandValueIterators
{
    abstract class AbstractHighCardValueIterator : IPokerHandValueIterator
    {
        public virtual List<IPokerCard> GetHighestPartOfHand(List<IPokerCard> passedCards)
        {
            IPokerCard highCard = GetHighCard(passedCards);

            List<IPokerCard> highCardList = new List<IPokerCard>();

            highCardList.Add(highCard);

            return highCardList;
        }

        public abstract IPokerCard GetHighCard(List<IPokerCard> passedCards);
    }
}
