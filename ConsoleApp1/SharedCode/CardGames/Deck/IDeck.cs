using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.SharedCode.CardGames.Deck
{
    interface IDeck<T>
    {
        T Draw();
        List<T> Draw(int passedDrawNumber);
        void Discard(T passedDiscardedCard);
        void Discard(List<T> passedDiscardedCards);
        List<T> Shuffle(List<T> passedCards);
        string[] GetCardBackDisplay();
    }
}
