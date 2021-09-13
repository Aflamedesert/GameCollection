using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHand.PokerHands;
using GameCollection.Games.Poker.PokerCards;


namespace GameCollection.Games.Poker.PokerHand
{
    public interface IPokerHandFactory
    {
        IPokerHand CreatePokerHandInstance(List<IPokerCard> passedStartingHand = null);
    }
}
