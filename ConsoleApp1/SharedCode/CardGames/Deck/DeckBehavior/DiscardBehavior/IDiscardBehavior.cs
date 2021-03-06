using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.DeckBehavior.DiscardBehavior
{
    public interface IDiscardBehavior<T>
    {
        void Discard(T passedDiscardedCard);
        void Discard(List<T> passedDiscardedCards);
    }
}
