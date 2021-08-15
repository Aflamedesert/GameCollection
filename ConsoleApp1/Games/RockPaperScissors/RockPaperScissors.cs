using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.RockPaperScissors
{
    public class RockPaperScissors : IGameInterface
    {
        private const int EndingChoiceIndex = (int)Choices.Scissors;

        private const int StartingChoiceIndex = (int)Choices.Rock;

        private const int InputToIndexOffsetNumber = 1;

        private enum Choices { Rock, Paper, Scissors };

        private enum Results { Victory, Defeat, Tie };

        private RPSOutputHandler outputHandler;

        private RPSInputHandler inputHandler;

        private int victoryWinNumber;

        private bool hasQuit;

        public RockPaperScissors(int winNumber)
        {
            victoryWinNumber = winNumber;
            outputHandler = new RPSOutputHandler();
            inputHandler = new RPSInputHandler();
            hasQuit = false;
        }

        public void Play()
        {

            GameLoop(victoryWinNumber);
        }

        private void Restart()
        {
            outputHandler.RestartGame();
            GameLoop(victoryWinNumber);
        }

        private void Quit()
        {
            hasQuit = true;
        }

        private void GameLoop(int winNumberParameter)
        {
            RPSGameState GameState = new RPSGameState();

            while((GameState.GetPlayerWins() < winNumberParameter) && (GameState.GetEnemyWins() < winNumberParameter) && (hasQuit == false))
            {
                PlayRound(GameState, winNumberParameter);
            }
        }

        private void PlayRound(RPSGameState gameState, int winThreshold)
        {
            string input;

            outputHandler.ChooseOption();
            input = inputHandler.getInputLine();

            if (input == "r")
            {
                Restart();
                return;
            }
            else if (input == "q")
            {
                Quit();
                return;
            }

            if (inputHandler.isValidInput(input, StartingChoiceIndex, EndingChoiceIndex))
            {
                int convertedInput = Convert.ToInt32(input) - InputToIndexOffsetNumber;

                int enemyOutput = GenerateRandomNumber(StartingChoiceIndex, EndingChoiceIndex);

                gameState.IncrementCurrentRoundNumber();

                outputHandler.RoundCounter(gameState.GetCurrentRoundNumber());

                ResultHandler(gameState, convertedInput, enemyOutput, winThreshold);
            }
            else
            {
                outputHandler.InvalidInput();
            }
        }

        private void ResultHandler(RPSGameState gameState, int convertedInput, int enemyOutput, int winThreshold)
        {
            if (CheckResult(convertedInput, enemyOutput) == (int)Results.Victory)
            {
                gameState.IncrementPlayerWins();
                outputHandler.Win(winThreshold, gameState.GetPlayerWins());
            }
            else if (CheckResult(convertedInput, enemyOutput) == (int)Results.Defeat)
            {
                gameState.IncrementEnemyWins();
                outputHandler.Lose(winThreshold, gameState.GetEnemyWins());
            }
            else
            {
                outputHandler.TieRound();
            }
        }

        private int GenerateRandomNumber(int min, int max)
        {
            Random randomGenerator = new Random();
            return randomGenerator.Next(min, max);
        }

        private int CheckResult(int playerChoice, int enemyChoice)
        {
            if(isNextChoice(playerChoice, enemyChoice))
            {
                return (int)Results.Defeat;
            }
            else if(isPreviousChoice(playerChoice, enemyChoice))
            {
                return (int)Results.Victory;
            }
            else
            {
                return (int)Results.Tie;
            }
        }

        private bool isNextChoice(int yourChoice, int opponentChoice)
        {
            if(opponentChoice == NextChoice(yourChoice))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isPreviousChoice(int yourChoice, int opponentChoice)
        {
            if(opponentChoice == PreviousChoice(yourChoice))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int NextChoice(int choice)
        {
            if(choice < EndingChoiceIndex)
            {
                choice++;
            }
            else
            {
                choice = StartingChoiceIndex;
            }
            return choice;
        }

        private int PreviousChoice(int choice)
        {
            if(choice > StartingChoiceIndex)
            {
                choice--;
            }
            else
            {
                choice = EndingChoiceIndex;
            }
            return choice;
        }
    }
}
