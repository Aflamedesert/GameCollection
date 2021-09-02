using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.StandardMatcherHelper.PokerMatcherHelper
{
    public interface IPokerMatcherHelper
    {
        bool isPatternMatch(List<IPokerCard> passedCards, bool? isFlush = null, bool? isStraight = null, bool? hasSet = null, List<int> setTarget = null);
    }
}
