using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerRoyalFlushHelper;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerStraightFlushHelper;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.StandardMatcherHelper.PokerMatcherHelper;

namespace GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper
{
    public interface IMatcherHelperFactory
    {
        IPokerMatcherHelper GetStandardMatcherHelper();
        IRoyalFlushHelper GetRoyalFlushMatcherHelper();
        IStraightFlushHelper GetStraightFlushMatcherHelper();
    }
}
