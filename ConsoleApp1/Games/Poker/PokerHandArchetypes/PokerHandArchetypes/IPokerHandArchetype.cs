using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes
{
    public interface IPokerHandArchetype
    {
        string GetArchetypeIdentifier(); 
        int? GetValuation();
    }
}
