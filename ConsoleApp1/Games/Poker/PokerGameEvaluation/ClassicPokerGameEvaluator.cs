using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;

namespace GameCollection.Games.Poker.PokerGameEvaluation
{
    public class ClassicPokerGameEvaluator : IPokerGameEvaluator
    {


        List<string> archetypeHierarchy;

        public IPlayingEntity GetWinner(List<IPlayingEntity> passedPlayers)
        {
            throw new NotImplementedException();
        }
    }
}
