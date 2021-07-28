using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.Poker.PokerCards
{
    class PokerFaceCard : FaceCard, IPokerCard
    {
        int cardValue;

        public PokerFaceCard(string passedCardType, int passedCardValue, string passedSuit, string[] passedCardDisplay) : base(passedCardType, passedSuit, passedCardDisplay)
        {
            //runs FaceCard's constructor and...
            cardValue = passedCardValue;
        }

        public int getIntValue()
        {
            return cardValue;
        }
    }
}
