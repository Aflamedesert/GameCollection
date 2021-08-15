using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandValueIterators
{
    public class HighCardValueIterator : AbstractHighCardValueIterator
    {
        const int FirstIndex = 0;

        public override IPokerCard GetHighCard(List<IPokerCard> passedCards)
        {
            IPokerCard highCard = null;

            int numberOfCards = passedCards.Count;

            if (numberOfCards > 1)
            {
                int highCardValue = 0;

                for (int i = 0; i < numberOfCards; i++)
                {
                    IPokerCard currentCard = passedCards[i];

                    int currentCardValue = currentCard.getIntValue();

                    if (currentCardValue > highCardValue)
                    {
                        highCardValue = currentCardValue;

                        highCard = currentCard;
                    }
                }
            }
            else if (numberOfCards == 1)
            {
                highCard = passedCards[FirstIndex];
            }

            return highCard;
        }
    }
}
