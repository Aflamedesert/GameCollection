using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CopyArrayBehavior
{
    public interface ICopyArrayBehavior
    {
        T[] CopyArray<T>(T[] passedArrayToCopy);
    }
}
