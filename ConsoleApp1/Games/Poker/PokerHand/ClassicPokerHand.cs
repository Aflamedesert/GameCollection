using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Hand.HandBehavior.StartingHandBehavior;
using GameCollection.SharedCode.CardGames.Hand.HandBehavior.DiscardingWholeHandBehavior;
using GameCollection.SharedCode.CardGames.Hand.HandBehavior.HandCheckingBehavior;
using GameCollection.SharedCode.CardGames.Hand.HandBehavior.AddingHandBehavior;
using GameCollection.SharedCode.CardGames.Card;
using GameCollection.Games.Poker.PokerHandSorting;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHand
{
    class ClassicPokerHand : IPokerHand
    {
        IPokerHandSorter handSorter;

        List<IPokerCard> hand;

        ClassicHandEmptyingBehavior<IPokerCard> handDiscarder;

        ClassicHandCheckingBehavior handChecker;

        ClassicAddingHandBehavior<IPokerCard> handAdder;

        public ClassicPokerHand(IPokerHandSorter passedSorter, List<IPokerCard> passedStartingCards = null)
        {
            ClassicStartingHandBehavior<IPokerCard> startingHandBehavior = new ClassicStartingHandBehavior<IPokerCard>(hand);

            hand = startingHandBehavior.GetStartingHand();

            handDiscarder = new ClassicHandEmptyingBehavior<IPokerCard>(hand);

            handAdder = new ClassicAddingHandBehavior<IPokerCard>(hand);

            handSorter = passedSorter;
        }

        public void Add(IPokerCard passedCard)
        {
            handAdder.Add(passedCard);
        }

        public void Add(List<IPokerCard> passedCards)
        {
            handAdder.Add(passedCards);
        }

        public List<IPokerCard> GetPokerHand()
        {
            List<IPokerCard> handCopyList = new List<IPokerCard>(hand);

            return handCopyList;
        }

        public void SortHand()
        {
            hand = handSorter.SortHand(GetPokerHand());
        }

        public List<IPokerCard> DiscardHand()
        {
            return handDiscarder.EmptyHand();
        }

        public IPokerCard Discard(IPokerCard passedCard)
        {
            bool handContainsCard = hand.Contains(passedCard);

            if (handContainsCard == true)
            {
                IPokerCard cardToDiscard = passedCard;

                hand.Remove(passedCard);

                return cardToDiscard;
            }
            else
            {
                return null;
            }
        }

        public IPokerCard Discard(string passedCardType, string passedCardSuit)
        {
            if(handChecker.ContainsCard(passedCardType, passedCardSuit))
            {
                IPokerCard convertedCard = RemoveCardFromHand(passedCardType, passedCardSuit);

                return convertedCard;
            }
            else
            {
                return null;
            }
        }

        private IPokerCard RemoveCardFromHand(string passedCardType, string passedCardSuit)
        {
            int numberOfCards = hand.Count;

            for(int i = 0; i < numberOfCards; i++)
            {
                IPokerCard currentCard = hand[i];

                if(CardIsMatch(currentCard, passedCardType, passedCardSuit))
                {
                    hand.RemoveAt(i);
                    return currentCard;
                }
            }

            return null;
        }

        private bool CardIsMatch(IPokerCard passedCard, string passedCardType, string passedCardSuit)
        {
            string testCardType = passedCard.getType();

            string testCardSuit = passedCard.getSuit();

            if(testCardType == passedCardType)
            {
                if(testCardSuit == passedCardSuit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
