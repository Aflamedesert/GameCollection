using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Card;

namespace GameCollection.SharedCode.CardGames.Deck
{
    interface IDeckMaker<T>
    {
        List<T> GetDeck();
    }
}
