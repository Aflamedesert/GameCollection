using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher
{
    public interface ISetDataMatcher
    {
        bool CheckForSetMatch(List<int> passedSetData, List<int> passedSetTarget);
    }
}
