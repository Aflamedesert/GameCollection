using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CopyArrayBehavior
{
    class ClassicCopyArrayBehavior : ICopyArrayBehavior
    {
        public T[] CopyArray<T>(T[] passedArrayToCopy)
        {
            int copyLength = passedArrayToCopy.Length;

            T[] arrayCopy = new T[copyLength];

            for (int i = 0; i < copyLength; i++)
            {
                arrayCopy[i] = passedArrayToCopy[i];
            }

            return arrayCopy;
        }
    }
}
