using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.DeckMakingBehavior.InstanciateDeckSetupBehavior
{
    interface IDeckSetupInstantiationBehavior<T>
    {
        List<T> InstanciateDeckSetup(string[,] deckSetup);
    }
}
