using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;
using GameCollection.Games.Poker.PokerGameObjects.StandardMessages;

namespace GameCollection.Games.Poker.PokerGameObjects.GameFacade
{
    public interface IPokerGameFacade
    {
        IEndGameOption Play();
    }
}
