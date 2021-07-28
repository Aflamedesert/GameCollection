using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CardTypeCheckingBehavior
{
    class ClassicCardTypeCheckingBehavior : ICardTypeCheckingBehavior
    {
        public bool isFaceCard(string passedCardType)
        {
            bool stringIsWord = true;

            int cardTypeLength = passedCardType.Length;

            for (int i = 0; i < cardTypeLength; i++)
            {
                char currentCharacter = passedCardType[i];

                if (Char.IsLetter(currentCharacter) == false)
                {
                    stringIsWord = false;
                    break;
                }
            }

            return stringIsWord;
        }

        public bool isNumberCard(string passedCardType)
        {
            bool stringIsNumeric = true;

            int cardTypeLength = passedCardType.Length;

            for (int i = 0; i < cardTypeLength; i++)
            {
                char currentCharacter = passedCardType[i];

                if (Char.IsDigit(currentCharacter) == false)
                {
                    stringIsNumeric = false;
                    break;
                }
            }

            return stringIsNumeric;
        }
    }
}
