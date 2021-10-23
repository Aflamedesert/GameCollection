using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerCardActionSystem
{
    public class ClassicPokerCardActionSystem<T> : IPokerCardActionSystem<T> where T : ICardActionBehavior
    {
        public void ExecuteCardActionRound(List<T> passedPlayers)
        {
            foreach(T player in passedPlayers)
            {
                player.InitiateCardAction();
            }
        }
    }
}
