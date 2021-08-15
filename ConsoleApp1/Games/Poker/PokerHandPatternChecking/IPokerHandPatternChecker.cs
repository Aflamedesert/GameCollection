using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandPatternChecking
{
    public interface IPokerHandPatternChecker
    {
        bool containsPattern(List<IPokerCard> passedCards);
    }
}
