using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;

namespace GameCollection.Games.Poker.PokerGameEvaluation
{
    public interface IPokerGameEvaluator<T> where T : IGetCardsInHandBehavior
    {
        List<T> GetWinner(List<T> passedPlayers);
    }
}
