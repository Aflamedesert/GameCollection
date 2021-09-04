using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.Utilities.Exceptions;

namespace GameCollection.Games.Poker.PokerArchetypeComparator
{
    public class ClassicPokerArchetypeComparator : IPokerArchetypeComparator
    {
        public bool? isFirstBetterThanSecond<T>(T passedFirstArchetype, T passedSecondArchetype) where T :  IPokerHandArchetype
        {
            string firstArchetypeIdentifier = passedFirstArchetype.GetArchetypeIdentifier();

            string secondArchetypeIdentifier = passedSecondArchetype.GetArchetypeIdentifier();

            if(firstArchetypeIdentifier != secondArchetypeIdentifier)
            {
                throw new UnintendedArgumentSetupException("ClassicPokerArchetypeComparator", "The two passedArchetypes must be of the same type");
            }

            int? firstValue = passedFirstArchetype.GetValuation();

            int? secondValue = passedSecondArchetype.GetValuation();

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

                    firstValue = passedFirstArchetype.GetValuation();

                    secondValue = passedSecondArchetype.GetValuation();
                }
            } 

            return null;
        }
    }
}
