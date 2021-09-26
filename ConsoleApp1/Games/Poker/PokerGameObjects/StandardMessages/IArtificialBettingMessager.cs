using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.StandardMessages
{
    public interface IArtificialBettingMessager
    {
        void BetMessage(string passedPlayerName, int passedBetAmount);
        void RaiseMessage(string passedPlayerName, int passedRaiseAmount);
        void CheckMessage(string passedPlayerName);
        void CallMessage(string passedPlayerName);
        void FoldMessage(string passedPlayerName);
    }
}
