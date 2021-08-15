using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.Poker.PokerCards
{
    public class PokerNumberCard : NumberCard, IPokerCard
    {
        public PokerNumberCard(int passedCardNumber, string passedSuit, string[] passedCardDisplay) : base(passedCardNumber, passedSuit, passedCardDisplay)
        {
            //runs NumberCard constructor
        }

        public int getIntValue()
        {
            return cardNumber;
        }
    }
}
