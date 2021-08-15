using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.BlackJack.Hands;

namespace GameCollection.Games.BlackJack.Output
{
    public class DisplayHandler
    {
        string[] cardBackDisplay;

        BlackJackPlayerHand playerHand;

        BlackJackDealerHand dealerHand;

        public DisplayHandler(string[] passedCardBackDisplay, BlackJackPlayerHand passedPlayerHand, BlackJackDealerHand passedDealerHand)
        {
            cardBackDisplay = passedCardBackDisplay;

            playerHand = passedPlayerHand;

            dealerHand = passedDealerHand;
        }

        public void Display()
        {
            string[] dealerHandOutput = CreateHandOutput(dealerHand);
            string[] backgroundOutput = CreateBackgroundDisplay();
            string[] playerHandOutput = CreateHandOutput(playerHand);

            PrintStringArray(dealerHandOutput);
            PrintStringArray(backgroundOutput);
            PrintStringArray(playerHandOutput);
        }

        private void PrintStringArray(string[] passedOutputArray)
        {
            int outputLineCount = passedOutputArray.Length;

            for (int i = 0; i < outputLineCount; i++)
            {
                string currentLine = passedOutputArray[i];

                Console.WriteLine(currentLine);
            }
        }

        private string[] CreateHandOutput(IBlackJackHand passedHand)
        {
            const int firstIndex = 0;

            const string SpaceCharacter = " ";

            List<string[]> handDisplays = passedHand.GetHandDisplays();

            int displayLineNumber = handDisplays[firstIndex].Length;

            int numberOfDisplays = handDisplays.Count;

            string[] finishedHandDisplays = new string[displayLineNumber];

            for (int i = 0; i < displayLineNumber; i++)
            {
                for (int x = 0; x < numberOfDisplays; x++)
                {
                    finishedHandDisplays[i] += handDisplays[x][i] + SpaceCharacter;
                }
            }

            return finishedHandDisplays;
        }

        private string[] CreateBackgroundDisplay()
        {
            return cardBackDisplay;
        }
    }
}
