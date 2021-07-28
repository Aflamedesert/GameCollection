using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Deck.DeckBehavior.ShuffleBehavior;

namespace GameCollection.SharedCode.CardGames.Deck.DeckBehavior.DrawBehavior
{
    class ClassicDrawBehavior<T> : IDrawBehavior<T>
    {
        IShuffleBehavior shuffleBehavior;

        IPileOfCards<T> drawPile;

        IPileOfCards<T> discardPile;

        public ClassicDrawBehavior(IShuffleBehavior passedShuffleBehavior, IPileOfCards<T> passedDrawPile, IPileOfCards<T> passedDiscardPile)
        {
            shuffleBehavior = passedShuffleBehavior;

            drawPile = passedDrawPile;
            discardPile = passedDiscardPile;
        }

        public T Draw()
        {
            if (drawPile.HasCards())
            {
                T drawnCard = drawPile.RemoveFromPile();
                return drawnCard;
            }
            else
            {
                ResetDrawPile();
                return Draw();
            }
        }

        public List<T> Draw(int passedDrawNumber)
        {
            List<T> drawnCards = new List<T>();

            for (int i = 0; i < passedDrawNumber; i++)
            {
                drawnCards.Add(Draw());
            }

            return drawnCards;
        }

        private void ResetDrawPile()
        {
            List<T> discardPileCards = discardPile.EmptyPile();
            discardPileCards = shuffleBehavior.Shuffle(discardPileCards);
            drawPile.AddToPile(discardPileCards);
        }
    }
}
