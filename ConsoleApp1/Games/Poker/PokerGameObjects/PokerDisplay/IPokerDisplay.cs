using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerDisplay
{
    public interface IPokerDisplay<T>
    {
        void DisplayFold(string passedPlayerName);
        void UpdatePot();
        void UpdateDisplay();
        void RevealAllPlayers();
    }
}
