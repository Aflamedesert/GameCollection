using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerCardActionSystem
{
    interface ISetCurrentCardActionRoundNumberBehavior
    {
        void SetCurrentRoundNumber(int passedCurrentRoundNumber);
    }
}
