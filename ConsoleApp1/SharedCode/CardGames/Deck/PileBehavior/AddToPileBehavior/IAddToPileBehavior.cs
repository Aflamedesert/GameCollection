using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.PileBehavior.AddToPileBehavior
{
    public interface IAddToPileBehavior<T>
    {
        void AddToPile(List<T> passedCards);
        void AddToPile(T passedCard);
    }
}
