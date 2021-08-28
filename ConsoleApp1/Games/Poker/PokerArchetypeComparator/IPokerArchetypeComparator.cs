using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandArchetypes;

namespace GameCollection.Games.Poker.PokerArchetypeComparator
{
    public interface IPokerArchetypeComparator
    {
        bool? isFirstBetterThanSecond<T>(T passedFirstArchetype, T passedSecondArchetype) where T : IPokerHandArchetype;
    }
}
