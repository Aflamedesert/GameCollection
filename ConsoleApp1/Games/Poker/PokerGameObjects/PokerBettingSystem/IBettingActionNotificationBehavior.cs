using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem
{
    public interface IBettingActionNotificationBehavior<T>
    {
        void BetNotification(int passedBetAmount);
        void FoldNotification(T passedFoldingPlayer);
    }
}
