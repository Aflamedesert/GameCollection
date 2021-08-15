using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandArchetypes
{
    public class PokerRoyalFlushArchetype : IPokerHandArchetype
    {
        const int FirstIndex = 0;

        int? currentValue;


        public PokerRoyalFlushArchetype(List<IPokerCard> passedCards, List<string> passedOrderedSuitRankings)
        {
            string handSuit = findSuitOfHand(passedCards);

            currentValue = findSuitRank(handSuit, passedOrderedSuitRankings);
        }

        private string findSuitOfHand(List<IPokerCard> passedCards)
        {
            int numberOfCards = passedCards.Count;

            if(numberOfCards > 0)
            {
                IPokerCard firstCard = passedCards[FirstIndex];

                string suit = firstCard.getSuit();

                return suit;
            }
            else
            {
                return null;
            }
            
        }

        private int findSuitRank(string passedSuit, List<string> passedOrderedSuitRankings)
        {
            int rank = 0;

            int numberOfSuits = passedOrderedSuitRankings.Count;

            for(int i = 0; i < numberOfSuits; i++)
            {
                string currentSuit = passedOrderedSuitRankings[i];

                if(currentSuit == passedSuit)
                {
                    rank = i + 1;
                    break;
                }
            }

            return rank;
        }

        public int? getValuation()
        {
            return currentValue;
        }

        public bool hasBackUpValuation()
        {
            return false;
        }

        public void incrementBackUpValuation()
        {
            if(currentValue != null)
            {
                currentValue = null;
            }
        }
    }
}
