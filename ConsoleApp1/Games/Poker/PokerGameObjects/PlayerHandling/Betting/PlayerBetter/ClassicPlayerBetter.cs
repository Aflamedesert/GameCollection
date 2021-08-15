using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.Betting.GameBetter;

namespace GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.Betting.PlayerBetter
{
    public class ClassicPlayerBetter : IPlayerBetter
    {
        IGameBetter pot;

        int chips;

        int anteAmount;

        public ClassicPlayerBetter(IGameBetter passedPot, int passedStartingChips, int passedAnteAmount)
        {
            pot = passedPot;
            chips = passedStartingChips;
            anteAmount = passedAnteAmount;
        }

        public void Ante()
        {
            if (anteAmount >= chips)
            {
                AddChipsToPot(anteAmount);
            }
            else
            {
                //player cannot make ante, so they lose
            }
        }

        public void Bet(int passedBetAmount)
        {
            if(passedBetAmount <= chips)
            {
                AddChipsToPot(passedBetAmount);
            }
            else
            {
                throw new ArgumentOutOfRangeException("passedBetAmount", $"The player cannot bet {passedBetAmount} because the player only has {chips} chips.");
            }
        }

        public int GetNumberOfChips()
        {
            return chips;
        }

        public void SetNumberOfChips(int passedNumberOfChips)
        {
            chips = passedNumberOfChips;
        }

        private void AddChipsToPot(int passedChips)
        {
            pot.AddChips(passedChips);
            chips -= passedChips;
        }
    }
}
