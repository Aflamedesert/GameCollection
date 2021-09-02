using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.PokerHandArchetypeState
{
    public class ClassicValuationProcessState : IValuationProcessState
    {
        List<IPokerHandValueIterator> valuationProcess;

        IPokerHandValueIterator currentValueIterator;

        int currentValueIteratorIndex;

        List<IPokerCard> cards;

        List<IPokerCard> currentHighCards;

        int? currentValue;

        public ClassicValuationProcessState(List<IPokerCard> passedCards, List<IPokerHandValueIterator> passedValuationProcess)
        {
            valuationProcess = new List<IPokerHandValueIterator>(passedValuationProcess);
            Construct(passedCards);
        }

        public ClassicValuationProcessState(List<IPokerCard> passedCards, IPokerHandValueIterator passedValueIterator)
        {
            valuationProcess = new List<IPokerHandValueIterator>()
            {
                passedValueIterator
            };
            Construct(passedCards);
        }

        private void Construct(List<IPokerCard> passedCards)
        {
            cards = new List<IPokerCard>(passedCards);
            currentValueIteratorIndex = 0;
            currentValueIterator = valuationProcess[currentValueIteratorIndex];
            currentHighCards = null;
            currentValue = null;
        }

        public List<IPokerCard> getCards()
        {
            if (cards != null)
            {
                return new List<IPokerCard>(cards);
            }
            else
            {
                return cards;
            }
        }

        public List<IPokerCard> getCurrentHighCards()
        {
            if (currentHighCards != null)
            {
                return new List<IPokerCard>(currentHighCards);
            }
            else
            {
                return currentHighCards;
            }
        }

        public int? getCurrentHighValue()
        {
            return currentValue;
        }

        public int getCurrentValuationIndex()
        {
            return currentValueIteratorIndex;
        }

        public IPokerHandValueIterator getCurrentValuationProcess()
        {
            return currentValueIterator;
        }

        public int getValuationProcessCount()
        {
            return valuationProcess.Count;
        }

        public void setCards(List<IPokerCard> passedCards)
        {
            if (passedCards != null)
            {
                cards = new List<IPokerCard>(passedCards);
            }
            else
            {
                cards = passedCards;
            }
        }

        public void setCurrentHighCards(List<IPokerCard> passedCards)
        {
            if (passedCards != null)
            {
                currentHighCards = new List<IPokerCard>(passedCards);
            }
            else
            {
                currentHighCards = passedCards;
            }
        }

        public void setCurrentHighValue(int? passedHighValue)
        {
            currentValue = passedHighValue;
        }

        public void setCurrentValuationIndex(int passedIndex)
        {
            if (passedIndex > 0 && passedIndex < valuationProcess.Count)
            {
                currentValueIteratorIndex = passedIndex;
                currentValueIterator = valuationProcess[currentValueIteratorIndex];
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The argument you gave, passedIndex = {passedIndex}, was out of the bounds of the Valuation Process list!");
            }
        }
    }
}
