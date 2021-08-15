using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.ReplaceCardSuitSurrogateBehavior
{
    public interface IReplaceCardSuitSurrogateBehavior
    {
        string ReplaceCardSuitSurrogate(string passedLine, string passedCardSuit, char passedFlag);
    }
}
