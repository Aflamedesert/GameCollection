using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerHandSorting;

namespace GameCollection.Games.Poker.PokerHandArchetypes
{
    public class PokerHighCardArchetype : IPokerHandArchetype
    {
        AbstractHighCardValueIterator highCardValueIterator;

        List<IPokerCard> cards;

        IPokerCard currentHighCard;

        int? currentHighCardValue;

        public PokerHighCardArchetype(List<IPokerCard> passedCards, AbstractHighCardValueIterator passedHighCardIterator)
        {
            cards = new List<IPokerCard>(passedCards);

            highCardValueIterator = passedHighCardIterator;

            Evaluate();
        }

        private void Evaluate()
        {
            IPokerCard highCard = getHighCard();

            if(highCard != null)
            {
                currentHighCard = highCard;
                currentHighCardValue = highCard.getIntValue();
            }
            else
            {
                currentHighCard = null;
                currentHighCardValue = null;
            }
        }

        private IPokerCard getHighCard()
        {
            if(hasBackUpValuation() == true)
            {
                IPokerCard highCard = highCardValueIterator.GetHighCard(cards);
                return highCard;
            }
            else
            {
                return null;
            }
        }

        public int? getValuation()
        {
            return currentHighCardValue;
        }

        public bool hasBackUpValuation()
        {
            int remaingingCards = cards.Count;

            if (remaingingCards > 0)
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
            if(hasBackUpValuation() == true)
            {
                cards.Remove(currentHighCard);
                Evaluate();
            }
            else
            {
                currentHighCard = null;
            }
        }
    }
}
