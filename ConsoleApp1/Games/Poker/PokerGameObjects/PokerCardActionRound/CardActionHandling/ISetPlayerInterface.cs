using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerCardActionRound.CardActionHandling
{
    public interface ISetPlayerInterface<T>
    {
        void SetPlayerInterface(T passedPlayerInterface);
    }
}
