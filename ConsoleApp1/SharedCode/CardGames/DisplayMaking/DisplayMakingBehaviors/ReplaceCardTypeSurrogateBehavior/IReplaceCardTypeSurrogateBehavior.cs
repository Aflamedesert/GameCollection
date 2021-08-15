using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.ReplaceCardTypeSurrogateBehavior
{
    public interface IReplaceCardTypeSurrogateBehavior
    {
        string ReplaceCardTypeSurrogate(string passedLine, string passedCardType, char passedFlag);
    }
}
