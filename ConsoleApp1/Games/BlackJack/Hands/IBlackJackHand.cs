using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.Games.BlackJack.Hands
{
    public interface IBlackJackHand
    {
        void Add(ICard passedCard);
        void Add(List<ICard> passedCards);
        List<ICard> DiscardHand();
        bool isEmpty();
        bool ContainsCard(string passedType = null, string passedSuit = null);
        int GetHandValue();
        bool HasAce();
        List<string[]> GetHandDisplays();
    }
}
