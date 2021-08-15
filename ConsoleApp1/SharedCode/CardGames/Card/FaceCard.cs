using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Card
{
    public class FaceCard : ICard
    {
        protected string suit;

        protected string cardFace;

        protected string[] cardDisplay;

        public FaceCard(string passedFaceValue, string passedSuit, string[] passedCardDisplay)
        {
            cardFace = passedFaceValue;

            suit = passedSuit;

            cardDisplay = passedCardDisplay;
        }

        public string getSuit()
        {
            return suit;
        }

        public string getType()
        {
            return cardFace;
        }

        public string[] getDisplay()
        {
            return cardDisplay;
        }
    }
}
