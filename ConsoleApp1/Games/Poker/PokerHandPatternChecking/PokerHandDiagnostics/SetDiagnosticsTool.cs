using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerCards;
using GameCollection.Games.Poker.PokerHandValueIterators;

namespace GameCollection.Games.Poker.PokerHandPatternChecking.PokerHandDiagnostics
{
    public class SetDiagnosticsTool : ISetDiagnosticsTool
    {
        AbstractHighKindValueIterator highKindIterator;

        List<IPokerCard> unEvaluatedCards;

        List<List<IPokerCard>> sets;

        public SetDiagnosticsTool(AbstractHighKindValueIterator passedHighKindIterator)
        {
            highKindIterator = passedHighKindIterator;
        }

        public List<int> AnalyzeCards(List<IPokerCard> passedCards)
        {
            List<int> setData = null;

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

                if(sets.Count > 0)
                {
                    setData = GetSetData(sets);
                }
            }

            return setData;
        }

        private List<IPokerCard> RemoveSetFromCards(List<IPokerCard> passedCards, List<IPokerCard> passedSet)
        {
            List<IPokerCard> finalCards = new List<IPokerCard>(passedCards);

            int numberOfCards = passedCards.Count;

            if(numberOfCards > 0)
            {
                foreach(IPokerCard card in passedCards)
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

        private List<int> GetSetData(List<List<IPokerCard>> passedSets)
        {
            List<int> setData = new List<int>();

            foreach(List<IPokerCard> set in passedSets)
            {
                setData.Add(set.Count);
            }

            return setData;
        }
    }
}
