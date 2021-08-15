using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;

namespace GameCollection.Games.Poker.PokerHandSorting
{
    public class ClassicHandSorter : IPokerHandSorter
    {
        AbstractHighCardValueIterator highCardValueIterator;

        AbstractHighKindValueIterator highKindValueIterator;

        public ClassicHandSorter(AbstractHighCardValueIterator passedHighCardValueIterator, AbstractHighKindValueIterator passedHighKindValueIterator)
        {
            highCardValueIterator = passedHighCardValueIterator;
            highKindValueIterator = passedHighKindValueIterator;
        }

        public List<IPokerCard> SortHand(List<IPokerCard> passedCards)
        {
            List<IPokerCard> sortedHand = new List<IPokerCard>();

            List<IPokerCard> unsortedHand = new List<IPokerCard>(passedCards);

            List<IPokerCard> orderedSetCards = GetSetCards(unsortedHand);

            int numberOfSets = orderedSetCards.Count;

            if(numberOfSets > 0)
            {
                sortedHand.AddRange(orderedSetCards);

                unsortedHand = RemoveCardsFromList(unsortedHand, orderedSetCards);
            }

            List<IPokerCard> orderedHighCards = OrderCardsInList(unsortedHand);

            sortedHand.AddRange(orderedHighCards);

            return sortedHand;
        }

        private List<IPokerCard> OrderCardsInList(List<IPokerCard> passedCards)
        {
            List<IPokerCard> sortedCardList = new List<IPokerCard>();

            List<IPokerCard> cardList = new List<IPokerCard>(passedCards);

            IPokerCard currentBestCard;

            do
            {
                currentBestCard = GetBestCard(cardList);

                if (currentBestCard != null)
                {
                    sortedCardList.Add(currentBestCard);

                    cardList = RemoveCardFromList(cardList, currentBestCard);
                }

            } while (currentBestCard != null);

            return sortedCardList;
        }

        private List<IPokerCard> RemoveCardsFromList(List<IPokerCard> passedCards, List<IPokerCard> passedCardsToRemove)
        {
            List<IPokerCard> cardList = new List<IPokerCard>(passedCards);

            foreach(IPokerCard card in cardList)
            {
                cardList = RemoveCardFromList(cardList, card);
            }

            return cardList;
        }

        private List<IPokerCard> RemoveCardFromList(List<IPokerCard> passedCards, IPokerCard passedCardToRemove)
        {
            List<IPokerCard> cardList = new List<IPokerCard>(passedCards);

            cardList.Remove(passedCardToRemove);

            return cardList;
        }

        private List<IPokerCard> GetSetCards(List<IPokerCard> passedCards)
        {
            List<IPokerCard> setCards = new List<IPokerCard>();

            List<IPokerCard> cardsList = new List<IPokerCard>(passedCards);

            List<IPokerCard> currentBestSet;

            do
            {
                currentBestSet = GetBestSet(cardsList);

                if (currentBestSet != null)
                {
                    setCards.AddRange(currentBestSet);

                    cardsList = RemoveCardsFromList(cardsList, passedCards);
                }

            } while (currentBestSet != null);

            return setCards;
        }

        private List<IPokerCard> GetBestSet(List<IPokerCard> passedCards)
        {
            List<IPokerCard> bestSet = highKindValueIterator.GetHighestPartOfHand(passedCards);

            return bestSet;
        }

        private IPokerCard GetBestCard(List<IPokerCard> passedCards)
        {
            IPokerCard bestCard = highCardValueIterator.GetHighCard(passedCards);

            return bestCard;
        }
    }
}
