using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerFlood
{
    public interface IPokerFlood
    {
        List<IPokerCard> GetCardsInFlood();
        void AddToFlood(IPokerCard passedCard);
        void AddToFlood(List<IPokerCard> passedCards);
        List<IPokerCard> EmptyFlood();
    }
}
