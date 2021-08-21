using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher
{
    public class LooseSetDataMatcher : ISetDataMatcher
    {
        public bool CheckForSetMatch(List<int> passedSetData, List<int> passedSetTarget)
        {
            foreach (int setSize in passedSetTarget)
            {
                if (passedSetData.Contains(setSize) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
