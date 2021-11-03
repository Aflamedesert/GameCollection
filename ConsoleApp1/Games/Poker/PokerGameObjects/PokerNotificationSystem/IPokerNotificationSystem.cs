using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerNotificationSystem
{
    public interface IPokerNotificationSystem
    {
        void FoldMessage(string passedPlayerName);
        void AddMessage(string passedPlayerName);
        void AddMessage(string passedPlayerName, int passedNumberOfCardsAdded);
        void BetMessage(string passedPlayerName, int passedBetAmount);
        void RaiseMessage(string passedPlayerName, int passedRaiseAmount);
        void CallMessage(string passedPlayerName, int passedCallAmount);
        void CheckMessage(string passedPlayerName);
        void DiscardMessage(string passedPlayerName, int passedNumberOfDiscardedCards);
        void WinnerMessage(string passedPlayerName, int numberOfWonChips);
        void TieMessage(List<(string tiedPlayerName, int amountOfChipsWon)> passedTiedPlayerData);
    }
}
