using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games;
using GameCollection.Administration;

namespace GameCollection.Menu
{
    class GameMenu : IMenu
    {
        IOptions optionsList;

        public void setOptions(IOptions passedOptions)
        {
            optionsList = passedOptions;
        }

        public IGameInterface Run()
        {
            IGameInterface returnGame = null;

            string input;

            while (returnGame == null)
            {
                Console.Clear();
                Console.WriteLine("What would you like to play?");

                Console.WriteLine(optionsList.getListOfOptions());

                input = Console.ReadLine();


                if (optionsList.isValidInput(input))
                {
                    IGameInterface selectedGame = optionsList.SelectGame(input);

                    return selectedGame;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            return returnGame;
        }
    }
}
