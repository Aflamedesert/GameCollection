using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerDisplay
{
    public interface IPokerDisplay
    {
        void SetPlayers(List<IPlayingEntity> passedPlayers);
        void StartDisplay();
        void UpdateDisplay();
        void UpdatePot(int numberOfChipsInPot);
        void PlayerHasQuit(IPlayingEntity passedPlayer);
        void PlayerHasFolded(IPlayingEntity passedPlayer);
    }
}
