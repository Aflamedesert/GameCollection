using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.BlackJack.Input;
using GameCollection.Games.BlackJack.Hands;

namespace GameCollection.Games.BlackJack.Output
{
    class ConsoleHandler
    {
        InputHandler inputHandler;

        OutputHandler outputHandler;

        DisplayHandler displayHandler;

        public ConsoleHandler(DisplayHandler passedDisplayHandler, InputHandler passedInputHandler = null, OutputHandler passedOutputHandler = null)
        {
            if(passedInputHandler == null)
            {
                inputHandler = new InputHandler();
            }
            else
            {
                inputHandler = passedInputHandler;
            }

            if(passedOutputHandler == null)
            {
                outputHandler = new OutputHandler();
            }
            else
            {
                outputHandler = passedOutputHandler;
            }

            displayHandler = passedDisplayHandler;
        }

        public string PlayAgainMenu(int passedScore)
        {
            string input = null;

            int[] choices = new int[]
            {
                1,
                2
            };

            while(input == null)
            {
                outputHandler.ScoreMessage(passedScore);

                outputHandler.PlayAgainMessage();

                input = inputHandler.GetChoiceInput(choices);

                if(input == null)
                {
                    outputHandler.InvalidInputMessage();
                    outputHandler.Pause();
                }

                outputHandler.ClearScreen();
            }

            return input;
        }

        public string MoveMenu()
        {
            string input = null;

            int[] choices = new int[]
            {
                1,
                2
            };

            while(input == null)
            {
                outputHandler.PrintNewLine();

                outputHandler.MovesMessage();

                input = inputHandler.GetChoiceInput(choices);

                if (input == null)
                {
                    outputHandler.InvalidInputMessage();
                    outputHandler.Pause();
                }
            }

            return input;
        }

        public int BettingMenu(int passedScore, int passedLowBetLimit)
        {
            string input = null;

            while (input == null)
            {
                outputHandler.ClearScreen();

                outputHandler.ScoreMessage(passedScore);

                displayHandler.Display();

                outputHandler.BettingMessage(passedLowBetLimit);

                input = inputHandler.GetRangeInput(passedLowBetLimit, passedScore);

                if(input == null)
                {
                    outputHandler.InvalidInputMessage();
                    outputHandler.Pause();
                }
            }

            int convertedInput = Convert.ToInt32(input);

            return convertedInput;
        }

        public int AceValueMenu(int passedNumberOfAces, string passedAceSuit)
        {
            const string AceCardType = "Ace";

            const int AceHighValue = 11;

            const int AceLowValue = 1;

            const int IndexOffset = 1;

            passedNumberOfAces += IndexOffset;

            int[] choices = new int[]
            {
                AceLowValue,
                AceHighValue
            };

            string input = null;

            while(input == null)
            {
                outputHandler.AcesLeftMessage(passedNumberOfAces);

                outputHandler.CurrentCardMessage(AceCardType, passedAceSuit);

                outputHandler.AceValueMessage(AceLowValue, AceHighValue);

                input = inputHandler.GetChoiceInput(choices);

                if(input == null)
                {
                    outputHandler.InvalidInputMessage();
                    outputHandler.Pause();
                }
            }

            int convertedInput = Convert.ToInt32(input);

            return convertedInput;
        }

        public string RoundMenu(int passedScore)
        {
            outputHandler.ClearScreen();

            outputHandler.ScoreMessage(passedScore);

            displayHandler.Display();

            string input = MoveMenu();

            if(input == "1")
            {
                outputHandler.HitMessage();
                outputHandler.Pause();
            }
            else
            {
                outputHandler.StandingMessage();
                outputHandler.Pause();
            }

            return input;
        }

        public void ShowResults(string passedResult)
        {
            switch (passedResult)
            {
                case "TieBust":
                    outputHandler.TieBustMessage();
                    outputHandler.Pause();
                    break;
                case "Tie":
                    outputHandler.TieMessage();
                    outputHandler.Pause();
                    break;
                case "DealerBust":
                    outputHandler.DealerBustingMessage();
                    outputHandler.Pause();
                    break;
                case "PlayerBust":
                    outputHandler.PlayerBustingMessage();
                    outputHandler.Pause();
                    break;
                case "BlackJack":
                    outputHandler.BlackJackMessage();
                    outputHandler.Pause();
                    break;
                case "BeatDealer":
                    outputHandler.BeatingDealerMessage();
                    outputHandler.Pause();
                    break;
                case "LoseToDealer":
                    outputHandler.LosingToDealerMessage();
                    outputHandler.Pause();
                    break;
            }

            outputHandler.ClearScreen();
        }

        public void DisplayGame()
        {
            outputHandler.ClearScreen();
            displayHandler.Display();
        }

        public void QuitResponse()
        {
            outputHandler.QuittingMessage();
            outputHandler.Pause();
        }

        public void OpeningResponse()
        {
            outputHandler.OpeningMessage();
            outputHandler.Pause();
        }

        public void DealerDrawResponse(string passedType, string passedSuit)
        {
            outputHandler.ClearScreen();
            displayHandler.Display();

            outputHandler.DealerDrawMessage(passedType, passedSuit);
            outputHandler.Pause();
        }

        public void GameOverResponse()
        {
            outputHandler.FinalGameOverMessage();
            outputHandler.Pause();
        }
    }
}
