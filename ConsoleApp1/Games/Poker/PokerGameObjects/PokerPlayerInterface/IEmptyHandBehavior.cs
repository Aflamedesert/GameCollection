using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface
{
    public interface IEmptyHandBehavior
    {
        List<IPokerCard> EmptyHand();
    }
}
