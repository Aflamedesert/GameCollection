using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.StandardMessages
{
    public interface IGameFacadeMessager
    {
        void WelcomeMessage();
        void WinnerMessage(string passedWinnerName, int passedWonChips);
        IEndGameOption EndGameOptionsMessage();
    }
}
