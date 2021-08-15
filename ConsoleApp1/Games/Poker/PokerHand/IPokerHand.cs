using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHand
{
    public interface IPokerHand
    {

        public void Add(IPokerCard passedCard);
        public void Add(List<IPokerCard> passedCards);
        public List<IPokerCard> GetPokerHand();
        public void SortHand();
        public List<IPokerCard> DiscardHand();
        public IPokerCard Discard(IPokerCard passedCard);
        public IPokerCard Discard(string passedCardType, string passedCardSuit);
    }
}
