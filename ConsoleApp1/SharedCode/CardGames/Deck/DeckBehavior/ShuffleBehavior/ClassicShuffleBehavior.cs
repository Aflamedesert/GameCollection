using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.CardGames.Deck.DeckBehavior.ShuffleBehavior
{
    public class ClassicShuffleBehavior : IShuffleBehavior
    {
        Random randomGenerator;

        public ClassicShuffleBehavior()
        {
            randomGenerator = new Random();
        }

        public List<T> Shuffle<T>(List<T> passedCards)
        {
            List<T> shuffledDeck = new List<T>(passedCards);

            for (int i = 0; i < shuffledDeck.Count - 1; i++)
            {
                int randomIndex = randomGenerator.Next(i, shuffledDeck.Count);

                T randomCard = shuffledDeck[randomIndex];
                shuffledDeck[randomIndex] = shuffledDeck[i];
                shuffledDeck[i] = randomCard;
            }

            return shuffledDeck;
        }
    }
}
