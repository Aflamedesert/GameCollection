using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.RockPaperScissors
{
    class RPSOutputHandler
    {
        public void ChooseOption()
        {
            Console.WriteLine("Choose Option:");
            Console.WriteLine("1 - Rock");
            Console.WriteLine("2 - Paper");
            Console.WriteLine("3 - Scissors");
        }

        public void Win(int winThreshold, int playerWinNumber)
        {
            if(winThreshold > playerWinNumber)
            {
                WinRound(winThreshold, playerWinNumber);
            }
            else
            {
                GameWin();
            }
        }

        public void Lose(int winThreshold, int enemyWinNumber)
        {
            if (winThreshold > enemyWinNumber)
            {
                LoseRound(winThreshold, enemyWinNumber);
            }
            else
            {
                GameLose();
            }
        }

        public void RoundCounter(int currentRound)
        {
            Console.WriteLine($"Round {currentRound}:");
        }

        public void TieRound()
        {
            Console.WriteLine("Tie, nobody wins!");
        }

        public void InvalidInput()
        {
            Console.WriteLine("Invalid Input! Try again!");
        }

        public void RestartGame()
        {
            Console.WriteLine("Restarting Game...");
        }

        private void LoseRound(int winThresholdNumber, int enemyWinNumber)
        {
            Console.WriteLine($"You lose! {winThresholdNumber - enemyWinNumber} lives left!");
        }

        private void WinRound(int winThresholdNumber, int playerWinNumber)
        {
            Console.WriteLine($"You win! Only {winThresholdNumber - playerWinNumber} more to go!");
        }

        private void GameWin()
        {
            Console.WriteLine("Congratulations! You win!");
            Console.ReadKey();
            Console.Clear();
        }

        private void GameLose()
        {
            Console.WriteLine("Oh no! You Lost!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
