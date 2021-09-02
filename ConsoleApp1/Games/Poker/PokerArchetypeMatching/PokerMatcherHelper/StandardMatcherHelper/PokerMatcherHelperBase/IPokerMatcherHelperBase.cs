using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.StandardMatcherHelper.PokerMatcherHelperBase
{
    public interface IPokerMatcherHelperBase
    {
        bool isPatternMatch(List<IPokerCard> passedCards, bool? isFlush, bool? isStraight, bool? hasSet, List<int> setTarget);
    }
}
