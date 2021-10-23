using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerBettingSystem.MinimumBetCalculation
{
    public class ClassicMinimumBetCalculator<T> : IMinimumBetCalculator<T> where T : IBettingRoundStateBehavior
    {
        List<T> players;

        public ClassicMinimumBetCalculator(List<T> passedPlayerInterfaces = null)
        {
            if (passedPlayerInterfaces == null)
            {
                players = new List<T>();
            }
        }

        public void SetPlayerInterfaces(List<T> passedPlayerInterfaces)
        {
            if (passedPlayerInterfaces == null)
            {
                throw new NullReferenceException("passedPlayerInterfaces cannot be null");
            }

            if (passedPlayerInterfaces.Count == 0)
            {
                throw new ArgumentOutOfRangeException(ToString(), "passedPlayerInterfaces must one conatin at least one element");
            }

            players = passedPlayerInterfaces;
        }

        public int GetMinimumBet()
        {
            int minimumBetAmount = 0;

            foreach (T player in players)
            {
                int currentPlayerBetAmount = player.GetAmountBet();

                if (currentPlayerBetAmount > minimumBetAmount)
                {
                    minimumBetAmount = currentPlayerBetAmount;
                }
            }

            return minimumBetAmount;
        }

        public void ClearAll()
        {
            foreach (T player in players)
            {
                player.Clear();
            }
        }
    }
}
