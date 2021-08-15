using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;
using GameCollection.SharedCode.CardGames.Hand.HandBehavior.AddingHandBehavior;
using GameCollection.SharedCode.CardGames.Hand.HandBehavior.DiscardingWholeHandBehavior;
using GameCollection.SharedCode.CardGames.Hand.HandBehavior.HandCheckingBehavior;

namespace GameCollection.Games.BlackJack.Hands
{
    public abstract class AbstractBlackJackHand : IBlackJackHand
    {
        ClassicAddingHandBehavior<ICard> handAdder;

        ClassicHandEmptyingBehavior<ICard> handDiscarder;

        ClassicHandCheckingBehavior handChecker;

        protected List<ICard> hand;

        protected List<FaceCard> acesList;

        protected int handValue;

        protected bool handHasChanged;

        protected AbstractBlackJackHand(List<ICard> passedStartingHand = null)
        {
            handAdder = new ClassicAddingHandBehavior<ICard>(hand);

            handDiscarder = new ClassicHandEmptyingBehavior<ICard>(hand);

            handChecker = new ClassicHandCheckingBehavior(hand);

            ResetHandEvaluation();

            if (passedStartingHand != null)
            {
                hand = new List<ICard>(passedStartingHand);
                handHasChanged = true;
            }
        }

        public void Add(ICard passedCard)
        {
            handAdder.Add(passedCard);
            handHasChanged = true;
        }

        public void Add(List<ICard> passedCards)
        {
            handAdder.Add(passedCards);
            handHasChanged = true;
        }

        public List<ICard> DiscardHand()
        {
            List<ICard> discardedHand = handDiscarder.EmptyHand();

            ResetHandEvaluation();

            return discardedHand;
        }

        public bool HasAce()
        {
            const string AceType = "Ace";

            return handChecker.ContainsCard(AceType);
        }

        public int GetHandValue()
        {
            if (handHasChanged == true)
            {
                handValue = EvaluateHand();
                handHasChanged = false;
            }

            return handValue;
        }

        protected int EvaluateHand()
        {
            int currentHandValue = 0;

            int numberOfCardsInHand = hand.Count;

            for (int i = 0; i < numberOfCardsInHand; i++)
            {
                ICard currentCard = hand[i];

                int convertedValue;

                if (currentCard is NumberCard)
                {
                    convertedValue = Convert.ToInt32(currentCard.getType());

                }
                else
                {
                    convertedValue = GetFaceCardValue((FaceCard)currentCard);
                }

                currentHandValue += convertedValue;
            }

            return currentHandValue;
        }

        protected int GetFaceCardValue(FaceCard passedFaceCard)
        {
            const int faceCardValue = 10;

            const int aceValue = 1;

            string faceCardType = passedFaceCard.getType();

            if (faceCardType == "Ace")
            {
                if(acesList.Contains(passedFaceCard) == false)
                {
                    acesList.Add(passedFaceCard);
                }

                return aceValue;
            }
            else
            {
                return faceCardValue;
            }
        }

        public bool isEmpty()
        {
            return handChecker.isEmpty();
        }

        public bool ContainsCard(string passedType = null, string passedSuit = null)
        {
            return handChecker.ContainsCard(passedType, passedSuit);
        }

        protected void ResetHandEvaluation()
        {
            if(hand == null)
            {
                hand = new List<ICard>();
            }
            else
            {
                if(handChecker.isEmpty() == false)
                {
                    hand.Clear();
                }
            }

            if(acesList == null)
            {
                acesList = new List<FaceCard>();
            }
            else
            {
                int numberOfAces = acesList.Count;

                if(numberOfAces > 0)
                {
                    acesList.Clear();
                }
            }

            handHasChanged = true;
            handValue = 0;
        }

        public abstract List<string[]> GetHandDisplays();
    }
}
