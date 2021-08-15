using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Administration;
using GameCollection.Menu;

namespace GameCollection.Games.RockPaperScissors
{
    public class RPSFactory : IGameFactory
    {
        string[] optionsList;

        public RPSFactory()
        {
            optionsList = new string[]
            {
                "2 out of 3",
                "3 out of 5",
                "4 out of 7",
                "Quit"
            };
        }

        public string[] getOptionsList()
        {
            return optionsList;
        }

        public IGameInterface SelectGame(string input)
        {
            return SelectGame(Convert.ToInt32(input));
        }

        public IGameInterface SelectGame(int input)
        {
            if(input == 1)
            {
                return new RockPaperScissors(2);
            }
            else if(input == 2)
            {
                return new RockPaperScissors(3);
            }
            else if(input == 3)
            {
                return new RockPaperScissors(4);
            }
            else
            {
                return null;
            }
        }
    }
}
