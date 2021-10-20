using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerAnteHandler
{
    public interface IAnteHandler<T>
    {
        void Ante(List<T> passedPlayerInterfaces);
    }
}
