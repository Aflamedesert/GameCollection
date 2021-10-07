using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface
{
    public interface IRemoveFromHandBehavior
    {
        IPokerCard RemoveFromHand(IPokerCard passedCard);
        List<IPokerCard> RemoveFromHand(List<IPokerCard> passedCards);
        IPokerCard RemoveFromHand(string passedCardType, string passedCardSuit);
        List<IPokerCard> RemoveFromHand(List<(string, string)> passedCardSignatures);
    }
}
