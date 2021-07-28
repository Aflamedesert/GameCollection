using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.RockPaperScissors
{
    class RPSInputHandler
    {
        public string getInputLine()
        {
            return Console.ReadLine();
        }

        public void waitForKey()
        {
            Console.ReadKey();
        }

        public bool isValidInput(string input, int startingChoice, int endingChoice)
        {
            if (Int32.TryParse(input, out int convertedInput))
            {
                if ((convertedInput >= startingChoice + 1) && (convertedInput <= endingChoice + 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
