using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface
{
    public interface IClassicPlayerInterface : IGetPlayerNameBehavior, IGetCardsInHandBehavior, IChipsHandlingAndFoldingBehavior, IAddToHandBehavior, IEmptyHandBehavior, ICallableBettingBehavior, ICheckableBettingBehavior
    {
        //interface that serves as the standard, core player interface
    }
}
