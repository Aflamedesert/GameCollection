using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerDeck
{
    interface IPokerDeck
    {
        IPokerCard Draw();
        List<IPokerCard> Draw(int passedDrawNumber);
        void Discard(IPokerCard passedDiscardedCard);
        void Discard(List<IPokerCard> passedDiscardedCards);
        List<IPokerCard> Shuffle(List<IPokerCard> passedCards);
    }
}
