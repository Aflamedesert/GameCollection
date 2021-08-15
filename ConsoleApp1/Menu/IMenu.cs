using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games;
using GameCollection.Administration;

namespace GameCollection.Menu
{
    public interface IMenu
    {
        void setOptions(IOptions passedOptions);
        IGameInterface Run();
    }
}
