using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking
{
    interface IDisplayMaker
    {
        string[] GetDisplay(string passedType, string passedSuit);
    }
}
