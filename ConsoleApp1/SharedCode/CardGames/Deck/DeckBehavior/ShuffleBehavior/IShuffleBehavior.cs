using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.DeckBehavior.ShuffleBehavior
{
    public interface IShuffleBehavior
    {
        List<T> Shuffle<T>(List<T> passedCards);
    }
}
