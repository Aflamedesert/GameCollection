using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.PileBehavior.RemoveFromPileBehavior
{
    interface IRemoveFromPileBehavior<T>
    {
        List<T> RemoveFromPile(int numberOfRemovals);
        T RemoveFromPile();
        List<T> EmptyPile();
    }
}
