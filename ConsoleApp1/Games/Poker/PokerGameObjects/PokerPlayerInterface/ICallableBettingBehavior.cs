using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface
{
    public interface ICallableBettingBehavior
    {
        void InitiateCallableBet(int passedMinimumBetAmount);
    }
}
