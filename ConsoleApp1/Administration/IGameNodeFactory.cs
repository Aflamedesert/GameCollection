using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Menu;

namespace GameCollection.Administration
{
    public interface IGameNodeFactory : IGameFactory
    {
        void setSelfNode(MenuNodeFascade passedSelfNode);
        void setHighLevelFactory(HighLevelFactory passedHighFactory);
    }
}
