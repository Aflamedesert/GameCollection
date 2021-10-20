using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface;
using GameCollection.Games.Poker.PokerGameObjects.PokerDeck;
using GameCollection.Games.Poker.PokerCards;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerStartingHandHandler
{
    public class ClassicStartingHandHandler<T> : IStartingHandHandler<T> where T : IAddToHandBehavior
    {
        IPokerDeck deck;

        int numberOfCardsToDraw;

        public ClassicStartingHandHandler(IPokerDeck passedPokerDeck, int passedNumberOfCardsToDraw)
        {
            deck = passedPokerDeck;

            numberOfCardsToDraw = passedNumberOfCardsToDraw;
        }

        public void DealStartingHand(List<T> passedPlayerInterfaces)
        {
            foreach(T player in passedPlayerInterfaces)
            {
                List<IPokerCard> startingCards = deck.Draw(numberOfCardsToDraw);

                player.AddToHand(startingCards);
            }
        }
    }
}
