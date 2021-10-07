using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;


namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerState
{
    public interface IGetPlayerCardsBehavior
    {
        List<IPokerCard> GetPlayerCards();
    }
}
