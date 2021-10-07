using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandSorting.HandSorting;
using GameCollection.SharedCode.Utilities.Exceptions;

namespace GameCollection.Games.Poker.PokerHand.PokerHands
{
    public class ClassicPokerHand : IPokerHand
    {
        IPokerHandSorter handSorter;

        List<IPokerCard> hand;

        public ClassicPokerHand(IPokerHandSorter passedSorter, List<IPokerCard> passedStartingCards = null)
        {
            hand = new List<IPokerCard>();

            if(passedStartingCards != null)
            {
                hand.AddRange(passedStartingCards);
            }

            handSorter = passedSorter;
        }

        public void Add(IPokerCard passedCard)
        {
            if (VerifyInput(passedCard, nameof(Add)))
            {
                hand.Add(passedCard);
            }
        }

        public void Add(List<IPokerCard> passedCards)
        {
            if(VerifyInput(passedCards, nameof(Add)))
            {
                hand.AddRange(passedCards);
            }
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

        public List<IPokerCard> EmptyHand()
        {
            List<IPokerCard> outputHand = GetPokerHand();

            hand.Clear();

            return outputHand;
        }

        public IPokerCard Remove(IPokerCard passedCard)
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
                throw new ArgumentException($"Hand does not contain card to be discarded : {passedCard.getType()} of {passedCard.getSuit()}", "ClassicPokerHand");
            }
        }

        public List<IPokerCard> Remove(List<IPokerCard> passedCards)
        {
            List<IPokerCard> output = new List<IPokerCard>();

            if(VerifyInput(passedCards, nameof(Remove)))
            {
                if(passedCards.Count > hand.Count)
                {
                    throw new UnintendedArgumentSetupException("passedCards cannot contain more cards than are in the hand", nameof(Remove));
                }
                else
                {
                    foreach(IPokerCard card in passedCards)
                    {
                        IPokerCard removedCard = Remove(card);
                        output.Add(removedCard);
                    }
                }
            }

            return output;
        }

        public IPokerCard Remove(string passedCardType, string passedCardSuit)
        {
            if (ContainsCard(passedCardType, passedCardSuit))
            {
                IPokerCard convertedCard = RemoveCardFromHand(passedCardType, passedCardSuit);

                return convertedCard;
            }
            else
            {
                throw new ArgumentException("Hand does not contain card to be discarded", "ClassicPokerHand");
            }
        }

        public List<IPokerCard> Remove(List<(string cardType, string cardSuit)> passedCardSignatures)
        {
            List<IPokerCard> output = new List<IPokerCard>();

            if(passedCardSignatures == null)
            {
                throw new ArgumentNullException(nameof(Remove), "List of card signatures cannot be null");
            }

            else if(passedCardSignatures.Count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Remove), "must have at least one element in the list of card signatures");
            }
            
            else if(passedCardSignatures.Count > hand.Count)
            {
                throw new UnintendedArgumentSetupException("Cannot pass more card signatures than there are cards in the hand", nameof(Remove));
            }

            else
            {
                foreach((string cardType, string cardSuit) card in passedCardSignatures)
                {
                    IPokerCard removedCard = Remove(card.cardType, card.cardSuit);
                    output.Add(removedCard);
                }

                return output;
            }
        }

        private bool ContainsCard(string passedCardType, string passedCardSuit)
        {
            bool handContainsCard = false;

            foreach(IPokerCard card in hand)
            {
                string currentCardType = card.getType();

                string currentCardSuit = card.getSuit();

                if((currentCardType == passedCardType) && (currentCardSuit == passedCardSuit))
                {
                    handContainsCard = true;
                    break;
                }
            }

            return handContainsCard;
        }

        private IPokerCard RemoveCardFromHand(string passedCardType, string passedCardSuit)
        {
            int numberOfCards = hand.Count;

            for (int i = 0; i < numberOfCards; i++)
            {
                IPokerCard currentCard = hand[i];

                if (CardIsMatch(currentCard, passedCardType, passedCardSuit))
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

            if (testCardType == passedCardType)
            {
                if (testCardSuit == passedCardSuit)
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

        private bool VerifyInput(IPokerCard passedCard, string passedMethodName)
        {
            if(passedCard == null)
            {
                throw new ArgumentNullException(passedMethodName, "Argument cannot Be null");
            }

            return true;
        }

        private bool VerifyInput(List<IPokerCard> passedCard, string passedMethodName)
        {
            if(passedCard == null)
            {
                throw new ArgumentNullException(passedMethodName, "Argument cannot Be null");
            }
            else if(passedCard.Count <= 0)
            {
                throw new ArgumentOutOfRangeException(passedMethodName, "Argument must have at least one element");
            }

            return true;
        }
    }
}
