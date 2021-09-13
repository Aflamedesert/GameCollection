using GameCollection.Games.Poker.PokerHand.PokerHands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandSorting;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHand
{
    public class ClassicPokerHandFactory : IPokerHandFactory
    {
        IPokerHandSorterFactory sorterFactory;

        public ClassicPokerHandFactory(IPokerHandSorterFactory passedHandSorterFactory)
        {
            sorterFactory = passedHandSorterFactory;
        }

        public IPokerHand CreatePokerHandInstance(List<IPokerCard> passedStartingHand = null)
        {
            return new ClassicPokerHand(sorterFactory.GetHandSorterInstance(), passedStartingHand);
        }
    }
}
