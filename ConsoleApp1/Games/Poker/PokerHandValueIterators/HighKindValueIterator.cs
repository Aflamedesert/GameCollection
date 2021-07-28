using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandValueIterators
{
    class HighKindValueIterator : AbstractHighKindValueIterator
    {
        const int FirstIndex = 0;

        private delegate bool isTrimTarget(List<IPokerCard> passedSet);

        private bool hasMultipleCardsInSet(List<IPokerCard> passedSet)
        {
            const int MinimumSetSize = 1;

            int setSize = passedSet.Count;

            if(setSize > MinimumSetSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override List<IPokerCard> GetHighSetOfCards(List<IPokerCard> passedCards)
        {
            int numberOfCards = passedCards.Count;

            if(numberOfCards > 1)
            {
                List<List<IPokerCard>> cardSets = CreateCardSets(passedCards);

                int numberOfSets = cardSets.Count;

                if (numberOfSets > 1)
                {
                    List<List<IPokerCard>> biggestSet = FindLargestSet(cardSets);

                    if (biggestSet.Count > 1)
                    {
                        return CompareSetsOfSameSize(biggestSet);
                    }
                    else
                    {
                        return biggestSet[FirstIndex];
                    }
                }
                else if(numberOfSets == 1)
                {
                    return cardSets[FirstIndex];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private List<IPokerCard> CompareSetsOfSameSize(List<List<IPokerCard>> passedCardSets)
        {
            int highestSetValue = 0;

            List<IPokerCard> highestSet = null;

            foreach(List<IPokerCard> set in passedCardSets)
            {
                int currentSetValue = set[FirstIndex].getIntValue();

                if(currentSetValue > highestSetValue)
                {
                    highestSetValue = currentSetValue;

                    highestSet = set;
                }
            }

            return highestSet;
        }

        private List<List<IPokerCard>> FindLargestSet(List<List<IPokerCard>> passedCardSets)
        {
            int highestSetSize = FindGreatestSetSize(passedCardSets);

            List<List<IPokerCard>> highestSets = GetSetOfSize(passedCardSets, highestSetSize);

            return highestSets;
        }

        private List<List<IPokerCard>> GetSetOfSize(List<List<IPokerCard>> passedCardSets, int passedSize)
        {
            List<List<IPokerCard>> foundSets = new List<List<IPokerCard>>();

            foreach(List<IPokerCard> set in passedCardSets)
            {
                int currentSetSize = set.Count;

                if(currentSetSize == passedSize)
                {
                    foundSets.Add(set);
                }
            }

            return foundSets;
        }

        private int FindGreatestSetSize(List<List<IPokerCard>> passedCardSets)
        {
            int highestSetSize = 1;

            foreach (List<IPokerCard> set in passedCardSets)
            {
                int currentSetSize = set.Count;

                if (currentSetSize > highestSetSize)
                {
                    highestSetSize = currentSetSize;
                }
            }

            return highestSetSize;
        }

        private List<List<IPokerCard>> CreateCardSets(List<IPokerCard> passedCards)
        {
            List<List<IPokerCard>> cardSets = new List<List<IPokerCard>>();

            foreach (IPokerCard card in passedCards)
            {
                List<IPokerCard> setMatch = FindMatchingSet(card, cardSets);

                if (setMatch != null)
                {
                    setMatch.Add(card);
                }
                else
                {
                    List<IPokerCard> newSet = new List<IPokerCard>();

                    newSet.Add(card);

                    cardSets.Add(newSet);
                }
            }

            cardSets = TrimSets(cardSets, hasMultipleCardsInSet);

            return cardSets;
        }

        private List<List<IPokerCard>> TrimSets(List<List<IPokerCard>> passedCardSets, isTrimTarget passedTargetFinder)
        {
            List<List<IPokerCard>> trimmedSets = new List<List<IPokerCard>>();

            foreach(List<IPokerCard> set in passedCardSets)
            {
                if (passedTargetFinder(set))
                {
                    trimmedSets.Add(set);
                }
            }

            return trimmedSets;
        }

        private List<IPokerCard> FindMatchingSet(IPokerCard passedCard, List<List<IPokerCard>> cardSets)
        {
            int numberOfCardSets = cardSets.Count;

            if(numberOfCardSets > 0)
            {
                string cardType = passedCard.getType();

                foreach (List<IPokerCard> set in cardSets)
                {
                    string setType = set[FirstIndex].getType();

                    if (cardType == setType)
                    {
                        return set;
                    }
                }
            }

            return null;
        }
    }
}
