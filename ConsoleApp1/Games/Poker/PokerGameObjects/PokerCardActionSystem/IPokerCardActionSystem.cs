using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerCardActionSystem
{
    public interface IPokerCardActionSystem<T>
    {
        void ExecuteCardActionRound(List<T> passedPlayers);
    }
}
