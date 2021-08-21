using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerArchetypeHelper
{
    public interface IPokerArchetypeHelper
    {
        bool isPatternMatch(List<IPokerCard> passedCards, bool? isFlush = null, bool? isStraight = null, bool? hasSet = null, List<int> setTarget = null);
    }
}
