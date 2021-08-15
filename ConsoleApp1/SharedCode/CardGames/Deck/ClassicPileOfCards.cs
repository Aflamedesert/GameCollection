using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Deck.PileBehavior.AddToPileBehavior;
using GameCollection.SharedCode.CardGames.Deck.PileBehavior.RemoveFromPileBehavior;
using GameCollection.SharedCode.CardGames.Deck.PileBehavior.PileHasCardsBehavior;

namespace GameCollection.SharedCode.CardGames.Deck
{
    public class ClassicPileOfCards<T> : IPileOfCards<T>
    {
        List<T> CardPile;

        IAddToPileBehavior<T> addToPileBehavior;

        IRemoveFromPileBehavior<T> removeFromPileBehavior;

        IPileHasCardsBehavior pileHasCardsBehavior;

        public ClassicPileOfCards()
        {
            CardPile = new List<T>();

            addToPileBehavior = new ClassicAddToPileBehavior<T>(CardPile);

            removeFromPileBehavior = new ClassicRemoveFromPileBehavior<T>(CardPile);

            pileHasCardsBehavior = new ClassicHasCardsBehavior<T>(CardPile);
        }

        public void AddToPile(List<T> passedCards)
        {
            addToPileBehavior.AddToPile(passedCards);
        }

        public void AddToPile(T passedCard)
        {
            addToPileBehavior.AddToPile(passedCard);
        }

        public List<T> RemoveFromPile(int numberOfRemovals)
        {
            return removeFromPileBehavior.RemoveFromPile(numberOfRemovals);
        }

        public T RemoveFromPile()
        {
            return removeFromPileBehavior.RemoveFromPile();
        }

        public List<T> EmptyPile()
        {
            return removeFromPileBehavior.EmptyPile();
        }

        public bool HasCards()
        {
            return pileHasCardsBehavior.HasCards();
        }
    }
}
