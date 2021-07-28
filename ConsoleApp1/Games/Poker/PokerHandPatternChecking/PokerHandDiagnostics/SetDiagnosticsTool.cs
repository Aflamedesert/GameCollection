using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandValueIterators;

namespace GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics
{
    class SetDiagnosticsTool
    {
        AbstractHighKindValueIterator highKindIterator;

        List<IPokerCard> unEvaluatedCards;

        List<List<IPokerCard>> sets;

        public List<int> setLengths { get; private set; }

        public int? numberOfSets { get; private set; }

        public int? numberOfNonSetCards { get; private set; }

        public SetDiagnosticsTool(AbstractHighKindValueIterator passedHighKindIterator)
        {
            highKindIterator = passedHighKindIterator;

            setLengths = null;
            numberOfSets = null;
            numberOfNonSetCards = null;
        }

        public void AnalyzeCards(List<IPokerCard> passedCards)
        {
            int numberOfCards = passedCards.Count;

            if(numberOfCards > 0)
            {
                unEvaluatedCards = new List<IPokerCard>(passedCards);

                sets = new List<List<IPokerCard>>();

                List<IPokerCard> currentSet;

                do
                {
                    currentSet = highKindIterator.GetHighSetOfCards(unEvaluatedCards);

                    if (currentSet != null)
                    {
                        sets.Add(currentSet);
                        unEvaluatedCards = RemoveSetFromCards(unEvaluatedCards, currentSet);
                    }
                } while (currentSet != null);

                numberOfSets = getNumberOfSets();

                setLengths = getSetLengths();

                numberOfNonSetCards = getNumberOfNonSetCards();
            }
            else
            {
                setLengths = null;
                numberOfSets = null;
                numberOfNonSetCards = null;
            }
        }

        private List<IPokerCard> RemoveSetFromCards(List<IPokerCard> passedCards, List<IPokerCard> passedSet)
        {
            List<IPokerCard> finalCards = new List<IPokerCard>(passedCards);

            int numberOfCards = finalCards.Count;

            if(numberOfCards > 0)
            {
                foreach(IPokerCard card in finalCards)
                {
                    foreach(IPokerCard setCard in passedSet)
                    {
                        if(card == setCard)
                        {
                            finalCards.Remove(card);
                        }
                    }
                }
            }

            return finalCards;
        }

        private int getNumberOfSets()
        {
            return sets.Count;
        }

        private List<int> getSetLengths()
        {
            setLengths = new List<int>();

            foreach (List<IPokerCard> set in sets)
            {
                int currentSetLengths = set.Count;

                setLengths.Add(currentSetLengths);
            }

            return setLengths;
        }

        private int getNumberOfNonSetCards()
        {
            int numberOfUnEvaluatedCards = unEvaluatedCards.Count;

            return numberOfUnEvaluatedCards;
        }
    }
}
