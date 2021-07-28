using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.SharedCode.CardGames.Hand.HandBehavior.HandCheckingBehavior
{
    class ClassicHandCheckingBehavior
    {
        List<ICard> hand;

        public ClassicHandCheckingBehavior(List<ICard> passedCards)
        {
            hand = passedCards;
        }

        public bool isEmpty()
        {
            if (hand.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ContainsCard(string passedType = null, string passedSuit = null)
        {
            if ((passedType != null) && (passedSuit != null))
            {
                return HasSpecificCard(passedType, passedSuit);
            }
            else if (passedType != null)
            {
                return HasType(passedType);
            }
            else if (passedSuit != null)
            {
                return HasSuit(passedSuit);
            }

            return false;
        }

        private bool HasType(string passedType)
        {
            int numberOfCards = hand.Count;

            for (int i = 0; i < numberOfCards; i++)
            {
                ICard currentCard = hand[i];

                string currentCardType = currentCard.getType();

                if (currentCardType == passedType)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasSuit(string passedSuit)
        {
            int numberOfCards = hand.Count;

            for (int i = 0; i < numberOfCards; i++)
            {
                ICard currentCard = hand[i];

                string currentCardSuit = currentCard.getSuit();

                if (currentCardSuit == passedSuit)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasSpecificCard(string passedType, string passedSuit)
        {
            int numberOfCards = hand.Count;

            for (int i = 0; i < numberOfCards; i++)
            {
                ICard currentCard = hand[i];

                string currentCardType = currentCard.getType();

                string currentCardSuit = currentCard.getSuit();

                if ((currentCardType == passedType) && (currentCardSuit == passedSuit))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
