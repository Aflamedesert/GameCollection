using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.Betting.GameBetter
{
    class ClassicGameBetter : IGameBetter
    {
        int chips;

        public ClassicGameBetter()
        {
            //add reference to game object
        }

        private void SetChipsToDefault()
        {
            chips = 0;
        }

        public void AddChips(int passedNumberOfChips)
        {
            chips += passedNumberOfChips;
        }

        public int EmptyPot()
        {
            int returnedChipValue = chips;
            SetChipsToDefault();
            return returnedChipValue;
        }

        public int GetAmountInPot()
        {
            return chips;
        }
    }
}
