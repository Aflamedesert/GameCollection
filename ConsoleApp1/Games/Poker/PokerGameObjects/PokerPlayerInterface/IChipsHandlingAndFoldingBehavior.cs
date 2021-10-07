using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface
{
    public interface IChipsHandlingAndFoldingBehavior : IChipHandlingBehavior, IFoldingBehavior
    {
        //empty interface used as a way to group together the interfaces needed to be accessed by the BetHandler class
    }
}
