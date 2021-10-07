using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPot
{
    public interface IPokerPot
    {
        int GetAmountInPot();
        void AddToPot(int passedAmount);
        int EmptyPot();
    }
}
