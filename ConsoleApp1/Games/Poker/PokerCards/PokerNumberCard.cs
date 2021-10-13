using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.Poker.PokerCards
{
    public class PokerNumberCard : IPokerCard
    {
        int cardNumber;

        string cardSuit;

        public PokerNumberCard(int passedCardNumber, string passedSuit)
        {
            cardNumber = passedCardNumber;

            cardSuit = passedSuit;
        }

        public int getIntValue()
        {
            return cardNumber;
        }

        public string getSuit()
        {
            return cardSuit;
        }

        public string getType()
        {
            return cardNumber.ToString();
        }
    }
}
