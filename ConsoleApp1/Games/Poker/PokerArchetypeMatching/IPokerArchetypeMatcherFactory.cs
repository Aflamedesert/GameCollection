using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerArchetypeMatchers;

namespace GameCollection.Games.Poker.PokerArchetypeMatching
{
    public interface IPokerArchetypeMatcherFactory
    {
        IPokerArchetypeMatcher GetHighCardMatcherInstance();
        IPokerArchetypeMatcher GetPairMatcherInstance();
        IPokerArchetypeMatcher GetTwoPairMatcherInstance();
        IPokerArchetypeMatcher GetThreeOfAKindMatcherInstance();
        IPokerArchetypeMatcher GetStraightMatcherInstance();
        IPokerArchetypeMatcher GetFlushMatcherInstance();
        IPokerArchetypeMatcher GetFullHouseMatcherInstance();
        IPokerArchetypeMatcher GetFourOfAKindMatcherInstance();
        IPokerArchetypeMatcher GetStraightFlushMatcherInstance();
        IPokerArchetypeMatcher GetRoyalFlushMatcherInstance();
    }
}
