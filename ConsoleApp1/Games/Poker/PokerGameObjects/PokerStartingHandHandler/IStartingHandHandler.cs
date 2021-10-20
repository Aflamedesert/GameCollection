using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerStartingHandHandler
{
    public interface IStartingHandHandler<T>
    {
        void DealStartingHand(List<T> passedPlayerInterfaces);
    }
}
