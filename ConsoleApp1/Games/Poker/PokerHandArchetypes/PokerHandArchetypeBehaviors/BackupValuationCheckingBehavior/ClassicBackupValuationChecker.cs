using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeState.ValuationProcessState;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.BackupValuationCheckingBehavior
{
    class ClassicBackupValuationChecker : IBackupValuationChecker
    {
        IValuationProcessState valuationState;

        public ClassicBackupValuationChecker(IValuationProcessState passedValuationState)
        {
            valuationState = passedValuationState;
        }

        public bool hasBackupValuation()
        {
            int numberOfCards = valuationState.getCards().Count;

            if(numberOfCards > 0)
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
