using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.PileBehavior.RemoveFromPileBehavior
{
    class ClassicRemoveFromPileBehavior<T> : IRemoveFromPileBehavior<T>
    {
        List<T> pileList;

        public ClassicRemoveFromPileBehavior(List<T> passedPileList)
        {
            pileList = passedPileList;
        }

        public List<T> RemoveFromPile(int numberOfRemovals)
        {
            List<T> removedCards = pileList.GetRange(Constants.TopOfPile, numberOfRemovals - 1);

            pileList.RemoveRange(Constants.TopOfPile, numberOfRemovals - 1);

            return removedCards;
        }

        public T RemoveFromPile()
        {
            T removedCard = pileList[Constants.TopOfPile];

            pileList.RemoveAt(Constants.TopOfPile);

            return removedCard;
        }

        public List<T> EmptyPile()
        {
            List<T> cardsInCardPile = new List<T>(pileList);

            pileList.Clear();

            return cardsInCardPile;
        }
    }
}
