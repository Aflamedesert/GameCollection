using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.SharedCode.Utilities.Exceptions;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerRoyalFlushHelper;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.PokerStraightFlushHelper;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerMatcherHelper.StandardMatcherHelper.PokerMatcherHelper;

namespace GameCollection.Games.Poker.PokerArchetypeMatching.PokerArchetypeMatchers
{
    public class ClassicPokerArchetypeMatcher : IPokerArchetypeMatcher
    {
        IPokerMatcherHelper archetypeHelper;

        IStraightFlushHelper straightFlushHelper;

        IRoyalFlushHelper royalFlushHelper;



        bool? isFlushVariable;

        bool? isStraightVariable;

        bool? hasSetVariable;

        bool? isRoyalFlushVariable;

        List<int> setTargetVariable;

        public ClassicPokerArchetypeMatcher(
            IPokerMatcherHelper passedArchetypeHelper, IStraightFlushHelper passedStraightFlushHelper, IRoyalFlushHelper passedRoyalFlushHelper,
            bool? isFlush = null, bool? isStraight = null, bool? hasSet = null, bool? isRoyalFlush = null, List<int> setTarget = null
            )
        {
            archetypeHelper = passedArchetypeHelper;
            straightFlushHelper = passedStraightFlushHelper;
            royalFlushHelper = passedRoyalFlushHelper;

            if (isFlush == null && isStraight == null && hasSet == null && setTarget == null && isRoyalFlush == null)
            {
                throw new UnintendedArgumentSetupException("ClassicPokerArchetypeMatcher : no query methods are activated");
            }

            isFlushVariable = isFlush;
            isStraightVariable = isStraight;
            hasSetVariable = hasSet;
            setTargetVariable = setTarget;
            isRoyalFlushVariable = isRoyalFlush;
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            if (isRoyalFlushVariable != null)
            {
                return CheckForRoyalFlush(passedCards);
            }

            if (isFlushVariable == true && isStraightVariable == true)
            {
                return CheckForStraightFlush(passedCards);
            }

            return archetypeHelper.isPatternMatch(passedCards, isFlushVariable, isStraightVariable, hasSetVariable, setTargetVariable);
        }

        private bool CheckForRoyalFlush(List<IPokerCard> passedCards)
        {
            return royalFlushHelper.isRoyalFlush(passedCards);
        }

        private bool CheckForStraightFlush(List<IPokerCard> passedCards)
        {
            bool isRoyalFlush = CheckForRoyalFlush(passedCards);

            if (isRoyalFlush == false)
            {
                List<IPokerCard> straightFlush = straightFlushHelper.FindStraightFlush(passedCards);

                if (straightFlush == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
