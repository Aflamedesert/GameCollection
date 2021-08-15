using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.Poker.PokerCards
{
    public interface IPokerCard : ICard
    {
        int getIntValue();
    }
}
