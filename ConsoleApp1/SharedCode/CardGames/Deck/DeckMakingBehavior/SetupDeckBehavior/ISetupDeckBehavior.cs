using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.DeckMakingBehavior.SetupDeckBehavior
{
    public interface ISetupDeckBehavior
    {
        string[,] SetupDeck();
    }
}
