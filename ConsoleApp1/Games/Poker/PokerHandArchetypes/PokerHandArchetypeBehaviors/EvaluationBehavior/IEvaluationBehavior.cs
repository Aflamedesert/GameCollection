using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandValueIterators;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.EvaluationBehavior
{
    public interface IEvaluationBehavior
    {
        void Evaluate();
    }
}
