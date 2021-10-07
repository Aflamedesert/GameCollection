using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface
{
    public interface IChipHandlingBehavior
    {
        int GetNumberOfChips();
        void AddChipsToPlayer(int passedAmount);
        void RemoveChipsFromPlayer(int passedAmount);
    }
}
