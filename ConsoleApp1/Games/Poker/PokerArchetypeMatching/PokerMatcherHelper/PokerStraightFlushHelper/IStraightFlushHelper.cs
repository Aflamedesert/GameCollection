using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerStraightFlushHelper
{
    public interface IStraightFlushHelper
    {
        List<IPokerCard> FindStraightFlush(List<IPokerCard> passedCards);
    }
}
