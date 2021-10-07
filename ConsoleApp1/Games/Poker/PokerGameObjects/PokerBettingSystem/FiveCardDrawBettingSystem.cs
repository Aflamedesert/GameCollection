using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem
{
    public class FiveCardDrawBettingSystem<T> : IPokerBettingSystem<T> where T : IChipHandlingBehavior, IFoldingBehavior, ICallableBettingBehavior, ICheckableBettingBehavior
    {
        public void Ante(List<T> passedPlayers)
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteBettingRound(List<T> passedPlayers)
        {
            throw new NotImplementedException();
        }
    }
}
