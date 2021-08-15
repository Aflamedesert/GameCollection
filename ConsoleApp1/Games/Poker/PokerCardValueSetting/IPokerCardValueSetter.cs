using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.Poker.PokerCardValueSetting
{
    public interface IPokerCardValueSetter
    {
        int ConvertToIntValue(ICard passedCard);
    }
}
