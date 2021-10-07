using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandArchetypes;

namespace GameCollection.Games.Poker.PlayingEntities
{
    public interface IPlayingEntity
    {
        string GetName();
        string GetPlayerType();
        int GetChipAmount();
        void AddChips(int passedAmount);
        void RemoveChips(int passedAmount);
    }
}
