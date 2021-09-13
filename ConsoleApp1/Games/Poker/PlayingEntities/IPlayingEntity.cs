using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState;

namespace GameCollection.Games.Poker.PlayingEntities
{
    public interface IPlayingEntity
    {
        IPlayerGameInterface GetGameInterface();
        string GetName();
        int GetChipAmount();
        void SetChipAmount(int passedChipAmount);
        void PlayTurn();
        void Bet();
    }
}
