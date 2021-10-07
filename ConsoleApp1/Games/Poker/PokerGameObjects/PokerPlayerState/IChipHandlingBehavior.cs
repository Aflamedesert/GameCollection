using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerState
{
    public interface IChipHandlingBehavior
    {
        int GetPlayerChipAmount();
        void AddChips(int passedAmount);
        void RemoveChips(int passedAmount);
    }
}
