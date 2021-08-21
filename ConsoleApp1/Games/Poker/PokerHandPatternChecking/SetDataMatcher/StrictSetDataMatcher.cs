using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher
{
    public class StrictSetDataMatcher : ISetDataMatcher
    {
        public bool CheckForSetMatch(List<int> passedSetData, List<int> passedSetTarget)
        {
            int setDataCount = passedSetData.Count;

            int setTargetCount = passedSetTarget.Count;

            if (setDataCount != setTargetCount)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < setDataCount; i++)
                {
                    int currentSetDataElement = passedSetData[i];
                    int currentSetTargetElement = passedSetTarget[i];

                    if (currentSetDataElement != currentSetTargetElement)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
