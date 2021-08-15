using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandValueIterators;

namespace GameCollection.Games.Poker.PokerHandArchetypes
{
    public class PokerStraightArchetype : IPokerHandArchetype
    {
        int? highCardValue;

        public PokerStraightArchetype(List<IPokerCard> passedCards, AbstractHighCardValueIterator passedHighCardIterator)
        {
            Construct(passedCards, passedHighCardIterator);
        }

        private void Construct(List<IPokerCard> passedCards, AbstractHighCardValueIterator passedHighCardIterator)
        {
            int numberOfCards = passedCards.Count;

            if(numberOfCards > 0)
            {
                List<IPokerCard> cards = new List<IPokerCard>(passedCards);

                IPokerCard highCard = passedHighCardIterator.GetHighCard(cards);

                highCardValue = highCard.getIntValue();
            }
            else
            {
                highCardValue = null;
            }
        }

        public int? getValuation()
        {
            return highCardValue;
        }

        public bool hasBackUpValuation()
        {
            return false;
        }

        public void incrementBackUpValuation()
        {
            highCardValue = null;
        }
    }
}
