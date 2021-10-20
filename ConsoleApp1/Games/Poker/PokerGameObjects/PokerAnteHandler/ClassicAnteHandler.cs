using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;
using GameCollection.Games.Poker.PokerGameObjects.PokerPot;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerAnteHandler
{
    public class ClassicAnteHandler<T> : IAnteHandler<T> where T : IChipHandlingBehavior
    {
        IPokerPot pot;

        int anteAmount;

        public ClassicAnteHandler(IPokerPot passedPot, int passedAnteAmount)
        {
            pot = passedPot;

            anteAmount = passedAnteAmount;
        }

        public void Ante(List<T> passedPlayerInterfaces)
        {
            foreach (T player in passedPlayerInterfaces)
            {
                player.RemoveChipsFromPlayer(anteAmount);

                pot.AddToPot(anteAmount);
            }
        }
    }
}
