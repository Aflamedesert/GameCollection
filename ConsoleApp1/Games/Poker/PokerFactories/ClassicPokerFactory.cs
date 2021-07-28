using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandSorting;
using GameCollection.Games.Poker.PokerHandPatternChecking;

namespace GameCollection.Games.Poker.PokerFactories
{
    class ClassicPokerFactory
    {
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
