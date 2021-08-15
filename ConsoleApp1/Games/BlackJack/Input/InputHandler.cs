using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.BlackJack.Input
{
    public class InputHandler
    {
        public string GetChoiceInput(int[] passedChoices)
        {
            string finalInput = null;

            string input = Console.ReadLine();

            if (isValidInputChoice(input, passedChoices))
            {
                finalInput = input;
            }

            return finalInput;
        }

        private bool isValidInputChoice(string input, int[] passedChoices)
        {
            if (int.TryParse(input, out int convertedInput))
            {
                return isValidInputChoice(convertedInput, passedChoices);
            }
            else
            {
                return false;
            }
        }

        private bool isValidInputChoice(int input, int[] passedChoices)
        {
            bool isAChoice = false;

            int numberOfChoices = passedChoices.Length;

            for (int i = 0; i < numberOfChoices; i++)
            {
                int currentChoice = passedChoices[i];

                if (input == currentChoice)
                {
                    isAChoice = true;
                    break;
                }
            }

            return isAChoice;
        }

        public string GetRangeInput(int passedLowLimit, int passedHighLimit)
        {
            string finalInput = null;

            string input = Console.ReadLine();

            if (isValidInputRange(input, passedLowLimit, passedHighLimit))
            {
                finalInput = input;
            }

            return finalInput;
        }

        private bool isValidInputRange(string input, int passedLowLimit, int passedHighLimit)
        {
            if (int.TryParse(input, out int convertedInput))
            {
                return isValidInputRange(convertedInput, passedLowLimit, passedHighLimit);
            }
            else
            {
                return false;
            }
        }

        private bool isValidInputRange(int input, int passedLowLimit, int passedHighLimit)
        {
            if ((input >= passedLowLimit) && (input <= passedHighLimit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
