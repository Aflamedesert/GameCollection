using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Card
{
    public interface ICard
    {
        string getSuit();
        string getType();
        string[] getDisplay();
    }
}
