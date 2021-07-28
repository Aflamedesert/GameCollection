using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.BlackJack.Output
{
    class OutputHandler
    {
        public void OpeningMessage()
        {
            Console.WriteLine("Welcome to BlackJack");
        }

        public void PlayAgainMessage()
        {
            Console.WriteLine("Would you like to Play Again?");
            Console.WriteLine("1 - Yes");
            Console.WriteLine("2 - No");
        }

        public void MovesMessage()
        {
            Console.WriteLine("What will your move be?");
            Console.WriteLine("1. Hit");
            Console.WriteLine("2. Stand");
        }

        public void InvalidInputMessage()
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine("Press any button to try again!");
        }

        public void HitMessage()
        {
            Console.WriteLine("Hit!!!");
        }

        public void FinalGameOverMessage()
        {
            Console.WriteLine("Bum Bum BUM...");
            Console.WriteLine("Game Over!!!");
        }

        public void TieBustMessage()
        {
            Console.WriteLine("Both you and the Dealer have busted!!!");
            TieClincher();
        }

        public void TieMessage()
        {
            Console.WriteLine("The Player and the Dealer have Tied!!!");
            TieClincher();
        }

        private void TieClincher()
        {
            Console.WriteLine("Nobody Wins, Nobody Loses");
        }

        public void QuittingMessage()
        {
            Console.WriteLine("Quitting...");
        }

        public void ScoreMessage(int passedScore)
        {
            Console.WriteLine($"Score : {passedScore}");
        }

        public void StandingMessage()
        {
            Console.WriteLine("Standed");
        }

        public void DealerBustingMessage()
        {
            Console.WriteLine("The Dealer has Busted");
        }

        public void BlackJackMessage()
        {
            Console.WriteLine("BlackJack!!!");
        }

        public void PlayerBustingMessage()
        {
            Console.WriteLine("You have Busted, You Lose!!!");
        }

        public void BeatingDealerMessage()
        {
            Console.WriteLine("You Beat the Dealer, You Win!!!");
        }

        public void LosingToDealerMessage()
        {
            Console.WriteLine("You Lost to the Dealer, You Lose!!!");
        }

        public void BettingMessage(int passedLowBetLimit)
        {
            Console.WriteLine($"Low Limit : {passedLowBetLimit}");
            Console.WriteLine("How much would you like to bet?");
        }

        public void AcesLeftMessage(int passedNumberOfAces)
        {
            Console.WriteLine($"Aces Left : {passedNumberOfAces}");
        }

        public void CurrentCardMessage(string passedCardType, string passedCardSuit)
        {
            Console.WriteLine($"Current Card : {passedCardType} of {passedCardSuit}");
        }

        public void AceValueMessage(int passedLowAceValue, int passedHighAceValue)
        {
            Console.WriteLine($"Choose Ace Value: {passedLowAceValue} or {passedHighAceValue}");
        }

        public void DealerDrawMessage(string passedType, string passedSuit)
        {
            Console.WriteLine($"The Dealer has a drawn a {passedType} of {passedSuit}.");
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void Pause()
        {
            Console.ReadKey();
        }

        public void PrintNewLine()
        {
            Console.WriteLine();
        }
    }
}
