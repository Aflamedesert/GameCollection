using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState
{
    public interface IArtificialPlayerGameInterface : IPlayerGameInterface
    {
        //interface used to group the AI PlayerGameInterface classes, and to distinguish them from the Human PlayerGameInterface classes
        void ExecuteTurn();
    }
}
