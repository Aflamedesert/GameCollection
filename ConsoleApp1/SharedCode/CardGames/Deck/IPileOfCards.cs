using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck
{
    interface IPileOfCards<T>
    {
        void AddToPile(List<T> passedCards);
        void AddToPile(T passedCard);
        T RemoveFromPile();
        List<T> RemoveFromPile(int numberOfRemovals);
        List<T> EmptyPile();
        bool HasCards();
    }
}
