using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeHandlers
{
    public interface IPokerArchetypeHandler
    {
        bool isArchetypeMatch(List<IPokerCard> passedCards);
        IPokerHandArchetype GetArchetypeInstance(List<IPokerCard> passedCards);
    }
}
