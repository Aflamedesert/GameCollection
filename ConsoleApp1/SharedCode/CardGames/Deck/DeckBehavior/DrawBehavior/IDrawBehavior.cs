using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.DeckBehavior.DrawBehavior
{
    public interface IDrawBehavior<T>
    {
        T Draw();
        List<T> Draw(int passedDrawNumber);
    }
}
