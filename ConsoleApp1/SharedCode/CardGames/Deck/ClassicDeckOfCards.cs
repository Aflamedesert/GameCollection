using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Deck.DeckBehavior.ShuffleBehavior;
using GameCollection.SharedCode.CardGames.Deck.DeckBehavior.DrawBehavior;
using GameCollection.SharedCode.CardGames.Deck.DeckBehavior.DiscardBehavior;
using GameCollection.SharedCode.CardGames.Deck.DeckBehavior.CardBackDisplayBehavior;

namespace GameCollection.SharedCode.CardGames.Deck
{
    class ClassicDeckOfCards<T> : IDeck<T>
    {
        IShuffleBehavior shuffleBehavior;

        ICardBackDisplayBehavior cardBackDisplayBehavior;

        IDrawBehavior<T> drawBehavior;

        IDiscardBehavior<T> discardBehavior;

        IPileOfCards<T> drawPile;

        IPileOfCards<T> discardPile;

        List<T> deck;

        public ClassicDeckOfCards(List<T> passedListOfCards, string[] passedCardBackDisplay)
        {
            drawPile = new ClassicPileOfCards<T>();

            discardPile = new ClassicPileOfCards<T>();

            shuffleBehavior = new ClassicShuffleBehavior();

            cardBackDisplayBehavior = new ClassicCardBackDisplayBehavior(passedCardBackDisplay);

            drawBehavior = new ClassicDrawBehavior<T>(shuffleBehavior, drawPile, discardPile);

            discardBehavior = new ClassicDiscardBehavior<T>(discardPile);

            deck = passedListOfCards;

            deck = Shuffle(deck);

            drawPile.AddToPile(deck);
        }

        public List<T> Shuffle(List<T> passedCards)
        {
            return shuffleBehavior.Shuffle<T>(passedCards);
        }

        public List<T> Draw(int passedDrawNumber)
        {
            return drawBehavior.Draw(passedDrawNumber);
        }

        public T Draw()
        {
            return drawBehavior.Draw();
        }

        public void Discard(List<T> passedDiscardedCards)
        {
            discardBehavior.Discard(passedDiscardedCards);
        }

        public void Discard(T passedDiscardedCard)
        {
            discardBehavior.Discard(passedDiscardedCard);
        }

        public string[] GetCardBackDisplay()
        {
            return cardBackDisplayBehavior.getCardBackDisplay();
        }
    }
}
