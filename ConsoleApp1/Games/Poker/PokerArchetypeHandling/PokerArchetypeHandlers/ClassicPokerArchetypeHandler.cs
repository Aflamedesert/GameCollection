using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerArchetypeHandling.PokerHandTrimmer;
using GameCollection.Games.Poker.PokerHandArchetypes.PokerHandArchetypes;
using GameCollection.Games.Poker.PokerArchetypeMatching.PokerArchetypeMatchers;

namespace GameCollection.Games.Poker.PokerArchetypeHandling.PokerArchetypeHandlers
{
    public delegate IPokerHandArchetype ArchetypeFactoryMethod(List<IPokerCard> passedCards);

    public class ClassicPokerArchetypeHandler : IPokerArchetypeHandler
    {
        IPokerArchetypeMatcher archetypeMatcher;

        ArchetypeFactoryMethod factoryMethod;

        IPokerHandTrimmer handTrimmer;

        public ClassicPokerArchetypeHandler(IPokerArchetypeMatcher passedArchetypeMatcher, ArchetypeFactoryMethod passedFactoryMethod,
            IPokerHandTrimmer passedHandTrimmer = null)
        {
            archetypeMatcher = passedArchetypeMatcher;

            factoryMethod = passedFactoryMethod;

            handTrimmer = passedHandTrimmer;
        }

        public IPokerHandArchetype GetArchetypeInstance(List<IPokerCard> passedCards)
        {
            List<IPokerCard> cards = new List<IPokerCard>(passedCards);

            if (handTrimmer != null)
            {
                cards = handTrimmer.TrimHand(cards);
            }

            return factoryMethod(cards);
        }

        public bool isArchetypeMatch(List<IPokerCard> passedCards)
        {
            return archetypeMatcher.isArchetypeMatch(passedCards);
        }
    }
}
