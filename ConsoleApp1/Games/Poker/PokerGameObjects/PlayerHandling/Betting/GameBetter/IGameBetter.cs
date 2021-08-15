using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.Betting.GameBetter
{
    public interface IGameBetter
    {
        void AddChips(int passedNumberOfChips);
        int EmptyPot();
        int GetAmountInPot();
    }
}
