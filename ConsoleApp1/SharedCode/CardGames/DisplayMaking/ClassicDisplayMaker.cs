using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CardTypeCheckingBehavior;
using GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CharReplacementBehavior;
using GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.ReplaceCardSuitSurrogateBehavior;
using GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.ReplaceCardTypeSurrogateBehavior;
using GameCollection.SharedCode.CardGames.DisplayMaking.DisplayMakingBehaviors.CopyArrayBehavior;

namespace GameCollection.SharedCode.CardGames.DisplayMaking
{
    public class ClassicDisplayMaker : IDisplayMaker
    {
        ICardTypeCheckingBehavior cardTypeChecker;

        ICharReplacementBehavior charReplacer;

        ICopyArrayBehavior arrayCopier;

        IReplaceCardSuitSurrogateBehavior suitSurrogateReplacer;

        IReplaceCardTypeSurrogateBehavior typeSurrogateReplacer;

        string[] cardFrame;

        char displaySuitFlag;

        char displayTypeFlag;

        public ClassicDisplayMaker(string[] passedCardFrame, char passedDisplaySuitFlag, char passedDisplayTypeFlag)
        {
            cardFrame = passedCardFrame;
            displaySuitFlag = passedDisplaySuitFlag;
            displayTypeFlag = passedDisplayTypeFlag;

            cardTypeChecker = new ClassicCardTypeCheckingBehavior();
            charReplacer = new ClassicCharReplacementBehavior();
            arrayCopier = new ClassicCopyArrayBehavior();
            suitSurrogateReplacer = new ClassicReplaceCardSuitSurrogateBehavior();
            typeSurrogateReplacer = new ClassicReplaceCardTypeSurrogateBehavior(cardTypeChecker, charReplacer);
        }

        public string[] GetDisplay(string passedCardSuit, string passedCardType)
        {
            string[] finishedDisplay = arrayCopier.CopyArray(cardFrame);

            for(int i = 0; i < finishedDisplay.Length; i++)
            {
                ref string currentLine = ref finishedDisplay[i];

                if (LineContainsChar(currentLine, displaySuitFlag))
                {
                    currentLine = suitSurrogateReplacer.ReplaceCardSuitSurrogate(currentLine, passedCardSuit, displaySuitFlag);
                }

                if (LineContainsChar(currentLine, displayTypeFlag))
                {
                    currentLine = typeSurrogateReplacer.ReplaceCardTypeSurrogate(currentLine, passedCardType, displayTypeFlag);
                }
            }

            return finishedDisplay;
        }

        private bool LineContainsChar(string passedLine, char passedFlag)
        {
            if (passedLine.Contains(passedFlag))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
