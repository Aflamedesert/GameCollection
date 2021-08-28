using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeFactories.PokerHandArchetypeComponentFactories;
using GameCollection.Games.Poker.PokerHandValueIterators.PokerHandValueIteratorFactories;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.EvaluationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeBehaviors.IncrementingValuationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeState.ValuationProcessState;

namespace GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeFactories
{
    public class ClassicPokerHandArchetypeFactory : IPokerHandArchetypeFactory
    {
        IPokerHandArchetypeComponentFactory componentFactory;

        IPokerHandValueIteratorFactory valueIteratorFactory;

        List<string> suitRankings;

        public ClassicPokerHandArchetypeFactory(IPokerHandArchetypeComponentFactory passedComponentFactory, IPokerHandValueIteratorFactory passedValueIteratorFactory, List<string> passedSuitRankings)
        {
            componentFactory = passedComponentFactory;
            valueIteratorFactory = passedValueIteratorFactory;

            suitRankings = passedSuitRankings;
        }

        public IPokerHandArchetype GetFlushArchetypeInstance(List<IPokerCard> passedCards)
        {
            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighCardValueIteratorInstance();

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess);
        }

        public IPokerHandArchetype GetFourOfAKindArchetypeInstance(List<IPokerCard> passedCards)
        {
            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighCardValueIteratorInstance()
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess);
        }

        public IPokerHandArchetype GetFullHouseArchetypeInstance(List<IPokerCard> passedCards)
        {
            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighKindValueIteratorInstance();

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess);
        }

        public IPokerHandArchetype GetHighCardArchetypeInstance(List<IPokerCard> passedCards)
        {
            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighCardValueIteratorInstance();

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess);
        }

        public IPokerHandArchetype GetPairArchetypeInstance(List<IPokerCard> passedCards)
        {
            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighCardValueIteratorInstance()
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess);
        }

        public IPokerHandArchetype GetRoyalFlushArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerRoyalFlushArchetype(passedCards, suitRankings);
        }

        public IPokerHandArchetype GetStraightArchetypeInstance(List<IPokerCard> passedCards)
        {
            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighCardValueIteratorInstance();

            return GetClassicNonIncrementablePokerHandArchetype(passedCards, valuationProcess);
        }

        public IPokerHandArchetype GetStraightFlushArchetypeInstance(List<IPokerCard> passedCards)
        {
            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighCardValueIteratorInstance();

            return GetClassicNonIncrementablePokerHandArchetype(passedCards, valuationProcess);
        }

        public IPokerHandArchetype GetThreeOfAKindArchetypeInstance(List<IPokerCard> passedCards)
        {
            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighCardValueIteratorInstance()
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess);
        }

        public IPokerHandArchetype GetTwoPairArchetypeInstance(List<IPokerCard> passedCards)
        {
            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighCardValueIteratorInstance()
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess);
        }

        private ClassicIncrementablePokerHandArchetype GetClassicIncrementablePokerHandArchetypeInstance(List<IPokerCard> passedCards, List<IPokerHandValueIterator> passedValuationProcess)
        {
                (
                IValuationProcessState state, 
                IEvaluationBehavior evaluator, 
                IValuationProcessIncrementor incrementor
                ) components = componentFactory.CreateComponents(passedCards, passedValuationProcess);

            return new ClassicIncrementablePokerHandArchetype(components.state, components.evaluator, components.incrementor);
        }

        private ClassicIncrementablePokerHandArchetype GetClassicIncrementablePokerHandArchetypeInstance(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationProcess)
        {
            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                passedValuationProcess
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess);
        }

        private ClassicNonIncrementablePokerHandArchetype GetClassicNonIncrementablePokerHandArchetype(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationProcess)
        {
            return new ClassicNonIncrementablePokerHandArchetype(passedCards, passedValuationProcess);
        }
    }
}
