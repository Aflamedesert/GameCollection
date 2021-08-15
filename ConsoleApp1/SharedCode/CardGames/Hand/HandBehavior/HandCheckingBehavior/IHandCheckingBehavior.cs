using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Hand.HandBehavior.HandCheckingBehavior
{
    public interface IHandCheckingBehavior
    {
        public bool ContainsCard(string passedType = null, string passedSuit = null);
        public bool isEmpty();
    }
}
