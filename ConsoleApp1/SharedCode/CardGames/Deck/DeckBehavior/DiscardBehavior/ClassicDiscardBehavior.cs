using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.DeckBehavior.DiscardBehavior
{
    class ClassicDiscardBehavior<T> : IDiscardBehavior<T>
    {
        IPileOfCards<T> discardPile;

        public ClassicDiscardBehavior(IPileOfCards<T> passedDiscardPile)
        {
            discardPile = passedDiscardPile;
        }

        public void Discard(T passedDiscardedCard)
        {
            discardPile.AddToPile(passedDiscardedCard);
        }

        public void Discard(List<T> passedDiscardedCards)
        {
            discardPile.AddToPile(passedDiscardedCards);
        }
    }
}
