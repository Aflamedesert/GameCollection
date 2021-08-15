using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandSorting;
using GameCollection.Games.Poker.PokerHandPatternChecking;
using GameCollection.Games.Poker.PokerArchetypeHandling;

namespace GameCollection.Games.Poker.PokerFactories
{
    public class ClassicPokerFactory
    {
        public PokerPatternCheckingPackage GetPatternCheckingPackageInstance()
        {
            SetChecker setChecker = GetSetCheckerInstance();

            StraightChecker straightChecker = GetStraightCheckerInstance();

            FlushChecker flushChecker = GetFlushCheckerInstance();

            return new PokerPatternCheckingPackage(setChecker, straightChecker, flushChecker);
        }

        public HighCardValueIterator GetHighCardIteratorInstance()
        {
            return new HighCardValueIterator();
        }

        public HighKindValueIterator GetHighKindIteratorInstance()
        {
            return new HighKindValueIterator();
        }

        public ClassicHandSorter GetHandSorterInstance()
        {
            return new ClassicHandSorter(GetHighCardIteratorInstance(), GetHighKindIteratorInstance());
        }

        public FlushChecker GetFlushCheckerInstance()
        {
            return new FlushChecker();
        }

        public StraightChecker GetStraightCheckerInstance()
        {
            return new StraightChecker(GetHandSorterInstance());
        }

        public SetChecker GetSetCheckerInstance()
        {
            return new SetChecker();
        }
    }
}
