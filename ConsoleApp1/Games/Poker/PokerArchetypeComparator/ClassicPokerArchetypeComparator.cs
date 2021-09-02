using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.Games.Poker.PokerArchetypeComparator
{
    public class ClassicPokerArchetypeComparator : IPokerArchetypeComparator
    {
        public bool? isFirstBetterThanSecond<T>(T passedFirstArchetype, T passedSecondArchetype) where T :  IPokerHandArchetype
        {
            int? firstValue = passedFirstArchetype.getValuation();

            int? secondValue = passedSecondArchetype.getValuation();

            while ((firstValue != null) && (secondValue != null))
            {

                if (firstValue > secondValue)
                {
                    return true;
                }
                else if (firstValue < secondValue)
                {
                    return false;
                }
                else
                {
                    if((passedFirstArchetype is IPokerIncrementable) && (passedSecondArchetype is IPokerIncrementable))
                    {
                        (passedFirstArchetype as IPokerIncrementable).Increment();

                        (passedSecondArchetype as IPokerIncrementable).Increment();
                    }

                    firstValue = passedFirstArchetype.getValuation();

                    secondValue = passedSecondArchetype.getValuation();
                }
            } 

            return null;
        }
    }
}
