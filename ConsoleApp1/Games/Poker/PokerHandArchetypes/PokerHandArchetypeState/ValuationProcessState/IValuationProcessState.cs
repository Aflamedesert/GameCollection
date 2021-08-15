using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeState.ValuationProcessState
{
    public interface IValuationProcessState
    {
        IPokerHandValueIterator getCurrentValuationProcess();
        int getValuationProcessCount();
        int getCurrentValuationIndex();
        void setCurrentValuationIndex(int passedIndex);
        List<IPokerCard> getCards();
        void setCards(List<IPokerCard> passedCards);
        List<IPokerCard> getCurrentHighCards();
        void setCurrentHighCards(List<IPokerCard> passedCards);
        int? getCurrentHighValue();
        void setCurrentHighValue(int? passedHighValue);
    }
}
