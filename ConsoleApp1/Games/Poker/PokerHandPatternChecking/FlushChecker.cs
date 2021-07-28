using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandPatternChecking
{
    class FlushChecker : IPokerHandPatternChecker
    {
        const int FirstIndex = 0;

        public bool containsPattern(List<IPokerCard> passedCards)
        {
            return isFlush(passedCards);
        }

        private bool isFlush(List<IPokerCard> passedCards)
        {
            int numberOfCards = passedCards.Count;

            if(numberOfCards > 0)
            {
                string targetSuit = passedCards[FirstIndex].getSuit();

                for(int i = 1; i < numberOfCards; i++)
                {
                    string currentCardSuit = passedCards[i].getSuit();

                    if(currentCardSuit != targetSuit)
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
