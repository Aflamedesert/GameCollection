using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.PileBehavior.PileHasCardsBehavior
{
    class ClassicHasCardsBehavior<T> : IPileHasCardsBehavior
    {
        List<T> pileList;

        public ClassicHasCardsBehavior(List<T> passedPileList)
        {
            pileList = passedPileList;
        }

        public bool HasCards()
        {
            if(pileList != null)
            {
                int numberOfCardsInPile = pileList.Count;

                if(numberOfCardsInPile > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
