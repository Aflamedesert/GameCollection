using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandSorting.HandSorting;

namespace GameCollection.Games.Poker.PokerHandSorting
{
    public interface IPokerHandSorterFactory
    {
        IPokerHandSorter GetHandSorterInstance();
    }
}
