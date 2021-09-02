using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandPatternCheckers
{
    public class SetChecker : IPokerHandPatternChecker
    {
        public bool containsPattern(List<IPokerCard> passedCards)
        {
            return hasSet(passedCards);
        }

        private bool hasSet(List<IPokerCard> passedCards)
        {
            List<IPokerCard> checkedCards = new List<IPokerCard>();

            foreach (IPokerCard card in passedCards)
            {
                if (hasCardMatch(card, checkedCards))
                {
                    return true;
                }
                else
                {
                    checkedCards.Add(card);
                }
            }

            return false;
        }

        private bool hasCardMatch(IPokerCard passedCard, List<IPokerCard> passedCardList)
        {
            int numberOfSets = passedCardList.Count;

            if (numberOfSets > 0)
            {
                string cardType = passedCard.getType();

                foreach (IPokerCard card in passedCardList)
                {
                    string currentCardType = card.getType();

                    if (currentCardType == cardType)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
