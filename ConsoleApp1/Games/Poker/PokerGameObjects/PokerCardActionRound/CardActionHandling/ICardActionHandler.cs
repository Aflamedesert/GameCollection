using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerCardActionRound.CardActionHandling
{
    public interface ICardActionHandler<T> : ISetPlayerInterface<T>, IDiscardBehavior
    {
        //empty interface, used to compile a collection of behavior interfaces
    }
}
