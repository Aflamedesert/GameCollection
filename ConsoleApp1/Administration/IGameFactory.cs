using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games;
using GameCollection.Menu;

namespace GameCollection.Administration
{
    public interface IGameFactory
    {
        string[] getOptionsList();
        IGameInterface SelectGame(int input);
        IGameInterface SelectGame(string input);
    }
}
