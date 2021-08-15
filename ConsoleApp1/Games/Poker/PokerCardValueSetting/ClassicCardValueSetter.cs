using GameCollection.SharedCode.CardGames.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerCardValueSetting
{
    public class ClassicCardValueSetter : IPokerCardValueSetter
    {
        int JackValue;
        int QueenValue;
        int KingValue;
        int AceValue;

        public ClassicCardValueSetter(int passedJackValue, int passedQueenValue, int passedKingValue, int passsedAceValue)
        {
            JackValue = passedJackValue;
            QueenValue = passedQueenValue;
            KingValue = passedKingValue;
            AceValue = passsedAceValue;
        }

        public int ConvertToIntValue(ICard passedCard)
        {
            const string JackType = "Jack";
            const string QueenType = "Queen";
            const string KingType = "King";

            string cardType = passedCard.getType();

            if(passedCard is FaceCard)
            {
                if(cardType == JackType)
                {
                    return JackValue;
                }
                else if(cardType == QueenType)
                {
                    return QueenValue;
                }
                else if(cardType == KingType)
                {
                    return KingValue;
                }
                else
                {
                    return AceValue;
                }
            }
            else
            {
                int convertedCardType = Convert.ToInt32(cardType);
                return convertedCardType;
            }
        }
    }
}
