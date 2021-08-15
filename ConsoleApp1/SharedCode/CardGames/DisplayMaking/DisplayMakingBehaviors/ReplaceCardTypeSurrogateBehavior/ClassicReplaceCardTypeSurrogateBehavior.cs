using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CardTypeCheckingBehavior;
using GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CharReplacementBehavior;

namespace GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.ReplaceCardTypeSurrogateBehavior
{
    public class ClassicReplaceCardTypeSurrogateBehavior : IReplaceCardTypeSurrogateBehavior
    {
        ICardTypeCheckingBehavior cardTypeCheckingBehavior;

        ICharReplacementBehavior charReplacementBehavior;

        public ClassicReplaceCardTypeSurrogateBehavior(ICardTypeCheckingBehavior passedCardTypeCheckingBehavior, ICharReplacementBehavior passedCharReplacementBehavior)
        {
            cardTypeCheckingBehavior = passedCardTypeCheckingBehavior;

            charReplacementBehavior = passedCharReplacementBehavior;
        }

        public string ReplaceCardTypeSurrogate(string passedLine, string passedCardType, char passedFlag)
        {
            if (passedLine.Contains(passedFlag))
            {
                if (cardTypeCheckingBehavior.isFaceCard(passedCardType))
                {
                    return ReplaceFaceCard(passedLine, passedCardType, passedFlag);
                }
                else if (cardTypeCheckingBehavior.isNumberCard(passedCardType))
                {
                    return ReplaceNumberCard(passedLine, passedCardType, passedFlag);
                }
                else
                {
                    return passedLine;
                }
            }
            else
            {
                return passedLine;
            }
        }

        private string ReplaceFaceCard(string passedLine, string passedCardType, char passedFlag)
        {
            char typeSurrogate = passedCardType[Constants.FirstIndex];

            string replacedString = passedLine.Replace(passedFlag, typeSurrogate);

            return replacedString;
        }

        private string ReplaceNumberCard(string passedLine, string passedCardType, char passedFlag)
        {
            int lineLength = passedLine.Length;

            int cardTypeCharacterCount = passedCardType.Length;

            for (int i = 0; i < lineLength; i++)
            {
                char currentCharacter = passedLine[i];

                if (currentCharacter == passedFlag)
                {
                    if (cardTypeCharacterCount > 1)
                    {
                        passedLine = charReplacementBehavior.ReplaceMultipleCharacters(passedLine, passedCardType, i);
                    }
                    else
                    {
                        char replacementCharacter = passedCardType[Constants.FirstIndex];

                        passedLine = charReplacementBehavior.ReplaceSingleCharacter(passedLine, replacementCharacter, i);
                    }
                }
            }

            return passedLine;
        }
    }
}
