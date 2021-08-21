using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerArchetypeHelper.PokerArchetypeHelperBase
{
    public interface IPokerArchetypeHelperBase
    {
        bool isPatternMatch(List<IPokerCard> passedCards, bool? isFlush, bool? isStraight, bool? hasSet, List<int> setTarget);
    }
}
