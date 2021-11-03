using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerNotificationSystem
{
    public interface IBettingNotifications
    {
        void BetMessage(string passedPlayerName, int passedBetAmount);
        void RaiseMessage(string passedPlayerName, int passedRaiseAmount);
        void CallMessage(string passedPlayerName, int passedCallAmount);
        void CheckMessage(string passedPlayerName);
        void FoldMessage(string passedPlayerName);
    }
}
