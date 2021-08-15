using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games;
using GameCollection.Menu;

namespace GameCollection.Administration
{
    public interface IOptions
    {
        int getListSize();
        string getListOfOptions();
        void setFactory(IGameFactory passedFactory);
        bool isValidInput(int input);
        bool isValidInput(string input);
        IGameInterface SelectGame(int input);
        IGameInterface SelectGame(string input);
    }
}
