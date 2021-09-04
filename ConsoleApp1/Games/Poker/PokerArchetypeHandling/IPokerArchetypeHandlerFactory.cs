using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeHandlers;

namespace GameCollection.Games.Poker.PokerArchetypeHandling
{
    public interface IPokerArchetypeHandlerFactory
    {
        IPokerArchetypeHandler GetHighCardHandlerInstance();
        IPokerArchetypeHandler GetPairHandlerInstance();
        IPokerArchetypeHandler GetTwoPairHandlerInstance();
        IPokerArchetypeHandler GetThreeOfAKindHandlerInstance();
        IPokerArchetypeHandler GetStraightHandlerInstance();
        IPokerArchetypeHandler GetFlushHandlerInstance();
        IPokerArchetypeHandler GetFullHouseHandlerInstance();
        IPokerArchetypeHandler GetFourOfAKindHandlerInstance();
        IPokerArchetypeHandler GetStraightFlushHandlerInstance();
        IPokerArchetypeHandler GetRoyalFlushHandlerInstance();
    }
}
