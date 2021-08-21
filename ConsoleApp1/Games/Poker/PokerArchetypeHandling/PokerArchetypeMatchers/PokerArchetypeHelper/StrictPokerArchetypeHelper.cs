using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.Utilities.Exceptions;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerHandPatternChecking.SetDataMatcher;
using GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerArchetypeHelper.PokerArchetypeHelperBase;


namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeMatchers.PokerArchetypeHelper
{
    public class StrictPokerArchetypeHelper : IPokerArchetypeHelper
    {
        IPokerArchetypeHelperBase helperBase;

        public StrictPokerArchetypeHelper(IPokerArchetypeHelperBase passedHelperBase)
        {
            helperBase = passedHelperBase;
        }

        public StrictPokerArchetypeHelper(ISetDiagnosticsTool passedSetDiagnosticsTool, ISetDataMatcher passedSetDataMatcher, PokerPatternCheckingPackage passedPatternCheckingPackage)
        {
            helperBase = new ClassicPokerArchetypeHelperBase(passedSetDiagnosticsTool, passedSetDataMatcher, passedPatternCheckingPackage);
        }

        public bool isPatternMatch(List<IPokerCard> passedCards, bool? isFlush = null, bool? isStraight = null, bool? hasSet = null, List<int> setTarget = null)
        {
            if ((isFlush == null) && (isStraight == null) && (hasSet == null) && (setTarget == null))
            {
                throw new UnintendedArgumentSetupException("ClassicPokerArchetypeHelper : didn't search for any patterns");
            }

            if (isFlush == null)
            {
                isFlush = false;
            }

            if(isStraight == null)
            {
                isStraight = false;
            }

            if((hasSet == null) && (setTarget == null))
            {
                hasSet = false;
            }

            return helperBase.isPatternMatch(passedCards, isFlush, isStraight, hasSet, setTarget);
        }
    }
}
