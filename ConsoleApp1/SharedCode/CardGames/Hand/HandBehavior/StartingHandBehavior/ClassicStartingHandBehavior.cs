using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Hand.HandBehavior.StartingHandBehavior
{
    public class ClassicStartingHandBehavior<T>
    {
        List<T> startingHand;

        public ClassicStartingHandBehavior(List<T> passedStartingHand = null)
        {
            startingHand = passedStartingHand;
        }

        public List<T> GetStartingHand()
        {
            List<T> returningHand = new List<T>();

            if(startingHand != null)
            {
                returningHand.AddRange(startingHand);
            }

            return returningHand;
        }
    }
}
