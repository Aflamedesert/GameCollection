using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Hand.HandBehavior.AddingHandBehavior
{
    public class ClassicAddingHandBehavior<T> : IAddingHandBehavior<T>
    {
        List<T> hand;
        
        public ClassicAddingHandBehavior(List<T> passedHand)
        {
            hand = passedHand;
        }

        public void Add(List<T> passedCards)
        {
            if(passedCards != null)
            {
                foreach(T card in passedCards)
                {
                    Add(card);
                }
            }
        }

        public void Add(T passedCard)
        {
            if(passedCard != null)
            {
                hand.Add(passedCard);
            }
        }
    }
}
