using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PlayingEntities
{
    public class ClassicPlayingEntity : IPlayingEntity
    {
        string playerName;

        string playerType;

        int chips;

        public ClassicPlayingEntity(string passedPlayerName, string passedPlayerType, int passedStartingChips = 0)
        {
            playerName = passedPlayerName;

            playerType = passedPlayerType;

            chips = passedStartingChips;
        }

        public string GetName()
        {
            return playerName;
        }

        public string GetPlayerType()
        {
            return playerType;
        }

        public int GetChipAmount()
        {
            return chips;
        }

        public void AddChips(int passedAmount)
        {
            chips += passedAmount;
        }

        public void RemoveChips(int passedAmount)
        {
            chips -= passedAmount;
        }
    }
}
