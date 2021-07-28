using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.ReplaceCardSuitSurrogateBehavior
{
    class ClassicReplaceCardSuitSurrogateBehavior : IReplaceCardSuitSurrogateBehavior
    {
        public string ReplaceCardSuitSurrogate(string passedLine, string passedCardSuit, char passedFlag)
        {
            if (passedLine.Contains(passedFlag))
            {
                char flagReplacement = passedCardSuit[Constants.FirstIndex];

                passedLine = passedLine.Replace(passedFlag, flagReplacement);
            }

            return passedLine;
        }
    }
}
