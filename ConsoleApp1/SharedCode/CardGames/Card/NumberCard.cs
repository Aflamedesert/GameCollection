using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Card
{
    public class NumberCard : ICard
    {
        protected int cardNumber;

        protected string suit;

        protected string[] cardDisplay;

        public NumberCard(int passedCardNumber, string passedSuit, string[] passedCardDisplay)
        {
            cardNumber = passedCardNumber;

            suit = passedSuit;

            cardDisplay = passedCardDisplay;
        }

        public string getSuit()
        {
            return suit;
        }

        public string getType()
        {
            return Convert.ToString(cardNumber);
        }

        public string[] getDisplay()
        {
            return cardDisplay;
        }
    }
}
