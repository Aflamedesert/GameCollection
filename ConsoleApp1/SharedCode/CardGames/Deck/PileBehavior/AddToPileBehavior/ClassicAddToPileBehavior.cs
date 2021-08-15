using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.PileBehavior.AddToPileBehavior
{
    public class ClassicAddToPileBehavior<T> : IAddToPileBehavior<T>
    {
        List<T> pileList;

        public ClassicAddToPileBehavior(List<T> passedPileList)
        {
            pileList = passedPileList;
        }

        public void AddToPile(List<T> passedCards)
        {
            pileList.InsertRange(Constants.TopOfPile, passedCards);
        }

        public void AddToPile(T passedCard)
        {
            pileList.Insert(Constants.TopOfPile, passedCard);
        }
    }
}
