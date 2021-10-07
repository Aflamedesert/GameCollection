using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHand.PokerHands
{
    public interface IPokerHand
    {
        List<IPokerCard> GetPokerHand();
        void SortHand();
        void Add(IPokerCard passedCard);
        void Add(List<IPokerCard> passedCards);
        IPokerCard Remove(IPokerCard passedCard);
        List<IPokerCard> Remove(List<IPokerCard> passedCards);
        IPokerCard Remove(string passedCardType, string passedCardSuit);
        List<IPokerCard> Remove(List<(string cardType, string cardSuit)> passedCardSignatures);
        List<IPokerCard> EmptyHand();
    }
}
