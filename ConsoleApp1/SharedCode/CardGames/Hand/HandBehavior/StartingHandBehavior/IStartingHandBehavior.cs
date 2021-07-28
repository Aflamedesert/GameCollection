using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Hand.HandBehavior.StartingHandBehavior
{
    interface IStartingHandBehavior<T>
    {
        public List<T> GetStartingHand();
    }
}
