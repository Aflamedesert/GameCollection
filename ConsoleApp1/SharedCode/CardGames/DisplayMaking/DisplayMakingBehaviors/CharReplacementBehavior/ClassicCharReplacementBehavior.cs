using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CharReplacementBehavior
{
    class ClassicCharReplacementBehavior : ICharReplacementBehavior
    {
        public string ReplaceMultipleCharacters(string passedLine, string passedReplacement, int passedIndex)
        {
            char[] charArrayLine = passedLine.ToCharArray();

            int replacementLength = passedReplacement.Length;

            for (int i = 0; i < replacementLength; i++)
            {
                char currentCharacter = passedReplacement[i];

                int currentIndexInLine = passedIndex + i;

                charArrayLine[currentIndexInLine] = currentCharacter;
            }

            return new string(charArrayLine);
        }

        public string ReplaceSingleCharacter(string passedLine, char passedReplacement, int passedIndex)
        {
            char[] characterArray = passedLine.ToCharArray();

            characterArray[passedIndex] = passedReplacement;

            return new string(characterArray);
        }
    }
}
