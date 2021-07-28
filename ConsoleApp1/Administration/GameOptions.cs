using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games;
using GameCollection.Menu;

namespace GameCollection.Administration
{
    class GameOptions : IOptions
    {
        string[] gamesList;

        IGameFactory factory;

        const int StartingChoice = 1;

        int EndingChoice;

        public void setFactory(IGameFactory passedFactory)
        {
            factory = passedFactory;

            gamesList = factory.getOptionsList();

            EndingChoice = gamesList.Length;
        }

        public int getListSize()
        {
            return gamesList.Length;
        }

        public string getListOfOptions()
        {
            string listOfGames = "";

            for(int i = 0; i < gamesList.Length; i++)
            {
                if(i == gamesList.Length - 1)
                {
                    listOfGames += $"{i + 1} - {gamesList[i]}";
                }
                else
                {
                    listOfGames += $"{i + 1} - {gamesList[i]}" + Environment.NewLine;
                }
            }

            return listOfGames;
        }

        public bool isValidInput(int input)
        {
            if ((input >= StartingChoice) && (input <= EndingChoice))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isValidInput(string input)
        {
            if (Int32.TryParse(input, out int convertedInput))
            {
                return isValidInput(convertedInput);
            }
            else
            {
                return false;
            }
        }

        public IGameInterface SelectGame(int input)
        {
            return factory.SelectGame(input);
        }

        public IGameInterface SelectGame(string input)
        {
            return factory.SelectGame(input);
        }
    }
}
