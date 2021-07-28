using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CharReplacementBehavior
{
    interface ICharReplacementBehavior
    {
        string ReplaceSingleCharacter(string passedLine, char passedReplacement, int passedIndex);
        string ReplaceMultipleCharacters(string passedLine, string passedReplacement, int passedIndex);
    }
}
