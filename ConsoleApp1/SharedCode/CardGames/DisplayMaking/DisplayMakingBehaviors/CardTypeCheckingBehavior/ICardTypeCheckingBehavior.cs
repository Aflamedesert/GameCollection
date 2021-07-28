using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CardTypeCheckingBehavior
{
    interface ICardTypeCheckingBehavior
    {
        bool isNumberCard(string passedCardType);
        bool isFaceCard(string passedCardType);
    }
}
