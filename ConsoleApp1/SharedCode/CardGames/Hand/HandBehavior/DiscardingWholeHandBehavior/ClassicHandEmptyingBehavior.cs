using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Hand.HandBehavior.DiscardingWholeHandBehavior
{
    public class ClassicHandEmptyingBehavior<T> : IHandEmptyingBehavior<T>
    {
        List<T> hand;

        public ClassicHandEmptyingBehavior(List<T> passedHand)
        {
            hand = passedHand;
        }

        public List<T> EmptyHand()
        {
            List<T> returningHand = new List<T>(hand);

            hand.Clear();

            return returningHand;
        }
    }
}
