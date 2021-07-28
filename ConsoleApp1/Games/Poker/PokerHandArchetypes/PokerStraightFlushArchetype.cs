using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandArchetypes
{
    class PokerStraightFlushArchetype : IPokerHandArchetype
    {
        const int FirstIndex = 0;

        int? highValue;

        List<string> orderedSuitRankings;

        List<IPokerCard> cards;

        bool hasGottenSuitRank;

        public PokerStraightFlushArchetype(List<IPokerCard> passedCards, AbstractHighCardValueIterator passedHighCardIterator, List<string> passedOrderedSuitRankings)
        {
            cards = new List<IPokerCard>(passedCards);

            orderedSuitRankings = passedOrderedSuitRankings;

            hasGottenSuitRank = false;

            Construct(passedCards, passedHighCardIterator);
        }

        private void Construct(List<IPokerCard> passedCards, AbstractHighCardValueIterator passedHighCardIterator)
        {
            int numberOfCards = passedCards.Count;

            if (numberOfCards > 0)
            {
                IPokerCard highCard = passedHighCardIterator.GetHighCard(cards);

                highValue = highCard.getIntValue();
            }
            else
            {
                highValue = null;
            }
        }

        public int? getValuation()
        {
            return highValue;
        }

        public bool hasBackUpValuation()
        {
            if(hasGottenSuitRank == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void incrementBackUpValuation()
        {
            if(hasGottenSuitRank == false)
            {
                highValue = getSuitRank();
                hasGottenSuitRank = true;
            }
            else
            {
                highValue = null;
            }
        }

        private int getSuitRank()
        {
            IPokerCard firstCard = cards[FirstIndex];

            string suit = firstCard.getSuit();

            int suitRank = findRanking(suit);

            return suitRank;
        }

        private int findRanking(string passedSuit)
        {
            int location = 0;

            int numberOfSuits = orderedSuitRankings.Count;

            for(int i = 0; i < numberOfSuits; i++)
            {
                string currentSuit = orderedSuitRankings[i];

                if(passedSuit == currentSuit)
                {
                    location = i + 1;
                    break;
                }
            }

            return location;
        }
    }
}
