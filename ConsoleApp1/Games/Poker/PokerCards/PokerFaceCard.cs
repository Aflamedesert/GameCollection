using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.Poker.PokerCards
{
    public class PokerFaceCard : IPokerCard
    {
        string cardType;

        string cardSuit;

        int cardValue;

        public PokerFaceCard(string passedCardType, string passedCardSuit, int passedCardValue)
        {
            cardType = passedCardType;

            cardSuit = passedCardSuit;

            cardValue = passedCardValue;
        }

        public int getIntValue()
        {
            return cardValue;
        }

        public string getSuit()
        {
            return cardSuit;
        }

        public string getType()
        {
            return cardType;
        }
    }
}
