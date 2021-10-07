using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerCardActionRound.CardActionHandling
{
    public interface IDiscardBehavior
    {
        void Discard(IPokerCard passedCard);
        void Discard(List<IPokerCard> passedCards);
        void Discard(string passedCardType, string passedCardSuit);
        void Discard(string[,] passedCardSignatures);
    }
}
