using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes;

namespace GameCollection.Games.Poker.PokerArchetypeHandling
{
    interface IPokerArchetypeFactory
    {
        bool isArchetypeMatch(List<IPokerCard> passedCards);
        IPokerHandArchetype getArchetypeInstance(List<IPokerCard> passedCards);
    }
}
