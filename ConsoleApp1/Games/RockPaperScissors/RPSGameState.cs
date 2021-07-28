using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.RockPaperScissors
{
    class RPSGameState
    {
        public struct RockPaperScissorsGameState
        {
            public int playerWins;
            public int enemyWins;
            public int currentRoundNumber;
        }

        private RockPaperScissorsGameState gameState;

        public RPSGameState()
        {
            gameState.playerWins = 0;
            gameState.enemyWins = 0;
            gameState.currentRoundNumber = 0;
        }

        public void SetPlayerWins(int newWins)
        {
            gameState.playerWins = newWins;
        }

        public void SetEnemyWins(int newWins)
        {
            gameState.enemyWins = newWins;
        }

        public void SetCurrentRoundNumber(int newRoundNumber)
        {
            gameState.currentRoundNumber = newRoundNumber;
        }

        public void IncrementPlayerWins()
        {
            gameState.playerWins++;
        }

        public void IncrementEnemyWins()
        {
            gameState.enemyWins++;
        }

        public void IncrementCurrentRoundNumber()
        {
            gameState.currentRoundNumber++;
        }

        public int GetPlayerWins()
        {
            return gameState.playerWins;
        }

        public int GetEnemyWins()
        {
            return gameState.enemyWins;
        }

        public int GetCurrentRoundNumber()
        {
            return gameState.currentRoundNumber;
        }
    }
}
