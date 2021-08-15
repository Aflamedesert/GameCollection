using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.State
{
    public interface IPlayerState
    {
        void Draw();
        void Draw(int passedNumberOfCards);
        void Discard(IPokerCard passedCard);
        void Discard(List<IPokerCard> passedCards);
        void ReturnHandToDeck();
        IReadOnlyList<IPokerCard> GetHand();
        int GetNumberOfChips();
        void Ante();
        void Bet(int passedNumberOfChips);
    }
}
