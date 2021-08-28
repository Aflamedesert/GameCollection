using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeFactories
{
    public interface IPokerHandArchetypeFactory
    {
        IPokerHandArchetype GetRoyalFlushArchetypeInstance(List<IPokerCard> passedCards);
        IPokerHandArchetype GetStraightFlushArchetypeInstance(List<IPokerCard> passedCards);
        IPokerHandArchetype GetFourOfAKindArchetypeInstance(List<IPokerCard> passedCards);
        IPokerHandArchetype GetFullHouseArchetypeInstance(List<IPokerCard> passedCards);
        IPokerHandArchetype GetFlushArchetypeInstance(List<IPokerCard> passedCards);
        IPokerHandArchetype GetStraightArchetypeInstance(List<IPokerCard> passedCards);
        IPokerHandArchetype GetThreeOfAKindArchetypeInstance(List<IPokerCard> passedCards);
        IPokerHandArchetype GetTwoPairArchetypeInstance(List<IPokerCard> passedCards);
        IPokerHandArchetype GetPairArchetypeInstance(List<IPokerCard> passedCards);
        IPokerHandArchetype GetHighCardArchetypeInstance(List<IPokerCard> passedCards);
    }
}
