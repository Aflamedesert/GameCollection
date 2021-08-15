using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandSorting;

namespace GameCollection.Games.Poker.PokerHandPatternChecking
{
    public class StraightChecker : IPokerHandPatternChecker
    {
        IPokerHandSorter handSorter;

        public StraightChecker(IPokerHandSorter passedSorter)
        {
            handSorter = passedSorter;
        }

        public bool containsPattern(List<IPokerCard> passedCards)
        {
            return isStraight(passedCards);
        }

        private bool isStraight(List<IPokerCard> passedCards)
        {
            List<IPokerCard> sortedCards = handSorter.SortHand(passedCards);

            int numberOfCards = sortedCards.Count;

            if(numberOfCards > 1)
            {
                for (int i = 0; i < numberOfCards - 1; i++)
                {
                    int currentCardValue = sortedCards[i].getIntValue();

                    int nextCardValue = sortedCards[i + 1].getIntValue();

                    if (nextCardValue != currentCardValue - 1)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
