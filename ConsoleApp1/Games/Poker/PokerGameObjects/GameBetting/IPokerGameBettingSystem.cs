using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;

namespace GameCollection.Games.Poker.PokerGameObjects.GameBetting
{
    public interface IPokerGameBettingSystem
    {
        void Ante(List<IPlayingEntity> passedPlayingEntities);
        int GetAmountOfChipsInPot();
        void AddChipsToPot(int passedChipAmount);
        int RemoveChipsFromPot(int passedChipsToRemove);
        int EmptyPot();

        IArtificialPlayerBetter GetArtificialPlayerBetter();
        IHumanPlayerBetter GetHumanPlayerBetter();
    }
}
