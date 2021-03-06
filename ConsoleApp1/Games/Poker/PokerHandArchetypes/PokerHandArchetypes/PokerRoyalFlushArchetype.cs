using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes
{
    public class PokerRoyalFlushArchetype : IPokerHandArchetype
    {
        int? currentValue;

        bool hasBeenEvaluated;

        string archetypeIdentifier;

        public PokerRoyalFlushArchetype(List<IPokerCard> passedCards, List<string> passedOrderedSuitRankings)
        {
            string handSuit = findSuitOfHand(passedCards);

            currentValue = findSuitRank(handSuit, passedOrderedSuitRankings);

            archetypeIdentifier = "RoyalFlush";

            hasBeenEvaluated = false;
        }

        private string findSuitOfHand(List<IPokerCard> passedCards)
        {
            int numberOfCards = passedCards.Count;

            if (numberOfCards > 0)
            {
                IPokerCard firstCard = passedCards[Constants.FirstIndex];

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

            for (int i = 0; i < numberOfSuits; i++)
            {
                string currentSuit = passedOrderedSuitRankings[i];

                if (currentSuit == passedSuit)
                {
                    rank = i + 1;
                    break;
                }
            }

            return rank;
        }

        public int? GetValuation()
        {
            if (hasBeenEvaluated == false)
            {
                hasBeenEvaluated = true;
                return currentValue;
            }
            else
            {
                return null;
            }
        }

        public string GetArchetypeIdentifier()
        {
            return archetypeIdentifier;
        }
    }
}
