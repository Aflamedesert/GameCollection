using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHandValueIterators;
using GameCollection.Games.Poker.PokerHandValueIterators.ValueIterators;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.EvaluationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.IncrementingValuationBehavior;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents.PokerHandArchetypeState;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypeComponents;

namespace GameCollection.Games.Poker.PokerHandArchetypes
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
            string archetypeIdentifier = "Flush";

            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighCardValueIteratorInstance();

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, archetypeIdentifier);
        }

        public IPokerHandArchetype GetFourOfAKindArchetypeInstance(List<IPokerCard> passedCards)
        {
            string archetypeIdentifier = "FourOfAKind";

            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighCardValueIteratorInstance()
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, archetypeIdentifier);
        }

        public IPokerHandArchetype GetFullHouseArchetypeInstance(List<IPokerCard> passedCards)
        {
            string archetypeIdentifier = "FullHouse";

            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighKindValueIteratorInstance();

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, archetypeIdentifier);
        }

        public IPokerHandArchetype GetHighCardArchetypeInstance(List<IPokerCard> passedCards)
        {
            string archetypeIdentifier = "HighCard";

            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighCardValueIteratorInstance();

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, archetypeIdentifier);
        }

        public IPokerHandArchetype GetPairArchetypeInstance(List<IPokerCard> passedCards)
        {
            string archetypeIdentifier = "Pair";

            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighCardValueIteratorInstance()
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, archetypeIdentifier);
        }

        public IPokerHandArchetype GetRoyalFlushArchetypeInstance(List<IPokerCard> passedCards)
        {
            return new PokerRoyalFlushArchetype(passedCards, suitRankings);
        }

        public IPokerHandArchetype GetStraightArchetypeInstance(List<IPokerCard> passedCards)
        {
            string archetypeIdentifier = "Straight";

            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighCardValueIteratorInstance();

            return GetClassicNonIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, archetypeIdentifier);
        }

        public IPokerHandArchetype GetStraightFlushArchetypeInstance(List<IPokerCard> passedCards)
        {
            string archetypeIdentifier = "StraightFlush";

            IPokerHandValueIterator valuationProcess = valueIteratorFactory.GetHighCardValueIteratorInstance();

            return GetClassicNonIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, archetypeIdentifier);
        }

        public IPokerHandArchetype GetThreeOfAKindArchetypeInstance(List<IPokerCard> passedCards)
        {
            string archetypeIdentifier = "ThreeOfAKind";

            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighCardValueIteratorInstance()
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, archetypeIdentifier);
        }

        public IPokerHandArchetype GetTwoPairArchetypeInstance(List<IPokerCard> passedCards)
        {
            string archetypeIdentifier = "TwoPair";

            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighKindValueIteratorInstance(),
                valueIteratorFactory.GetHighCardValueIteratorInstance()
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, archetypeIdentifier);
        }

        private ClassicIncrementablePokerHandArchetype GetClassicIncrementablePokerHandArchetypeInstance(List<IPokerCard> passedCards, List<IPokerHandValueIterator> passedValuationProcess, string passedArchetypeIdentifier)
        {
            CheckArchetypeIdentifier(passedArchetypeIdentifier);

            (
            IValuationProcessState state,
            IEvaluationBehavior evaluator,
            IValuationProcessIncrementor incrementor
            ) components = componentFactory.CreateComponents(passedCards, passedValuationProcess);

            return new ClassicIncrementablePokerHandArchetype(components.state, components.evaluator, components.incrementor, passedArchetypeIdentifier);
        }

        private ClassicIncrementablePokerHandArchetype GetClassicIncrementablePokerHandArchetypeInstance(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationProcess, string passedArchetypeIdentifier)
        {
            List<IPokerHandValueIterator> valuationProcess = new List<IPokerHandValueIterator>()
            {
                passedValuationProcess
            };

            return GetClassicIncrementablePokerHandArchetypeInstance(passedCards, valuationProcess, passedArchetypeIdentifier);
        }

        private ClassicNonIncrementablePokerHandArchetype GetClassicNonIncrementablePokerHandArchetypeInstance(List<IPokerCard> passedCards, IPokerHandValueIterator passedValuationProcess, string passedArchetypeIdentifier)
        {
            CheckArchetypeIdentifier(passedArchetypeIdentifier);

            return new ClassicNonIncrementablePokerHandArchetype(passedCards, passedValuationProcess, passedArchetypeIdentifier);
        }

        private void CheckArchetypeIdentifier(string passedArchetypeIdentifier)
        {
            if (passedArchetypeIdentifier == null)
            {
                throw new ArgumentNullException("ClassicPokerHandArchetypeFactory", "passedArchetypeIndentifier cannot equal null");
            }

            if (passedArchetypeIdentifier.Length < 1)
            {
                throw new ArgumentOutOfRangeException("ClassicPokerHandArchetypeFactory", "passedArchetypeIdentifier must contain at least one character");
            }
        }
    }
}
