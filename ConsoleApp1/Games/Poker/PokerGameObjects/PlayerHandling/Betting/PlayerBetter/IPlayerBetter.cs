using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.Betting.PlayerBetter
{
    interface IPlayerBetter
    {
        int GetNumberOfChips();
        void SetNumberOfChips(int passedNumberOfChips);
        void Ante();
        void Bet(int passedBetAmount);
    }
}
