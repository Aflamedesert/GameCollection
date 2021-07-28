using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerHand;
using GameCollection.SharedCode.CardGames.Deck;
using GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.Betting.PlayerBetter;

namespace GameCollection.Games.Poker.PokerGameObjects.PlayerHandling.State
{
    class ClassicPlayerState : IPlayerState
    {
        IDeck<IPokerCard> deck;

        IPokerHand hand;

        IPlayerBetter better;

        public ClassicPlayerState(IDeck<IPokerCard> passedDeck, IPokerHand passedHand, IPlayerBetter passedPlayerBetter)
        {
            deck = passedDeck;
            hand = passedHand;
            better = passedPlayerBetter;
        }

        public void Draw()
        {
            IPokerCard drawnCard = deck.Draw();
            hand.Add(drawnCard);
        }

        public void Draw(int passedNumberOfCards)
        {
            List<IPokerCard> drawnCards = deck.Draw(passedNumberOfCards);
            hand.Add(drawnCards);
        }

        public void Discard(IPokerCard passedCard)
        {
            IPokerCard discardedCard = hand.Discard(passedCard);

            if(discardedCard != null)
            {
                deck.Discard(discardedCard);
            }
        }

        public void Discard(string passedCardType, string passedCardSuit)
        {
            IPokerCard discardedCard = hand.Discard(passedCardType, passedCardSuit);

            if (discardedCard != null)
            {
                deck.Discard(discardedCard);
            }
        }

        public void Discard(List<IPokerCard> passedCards)
        {
            foreach(IPokerCard card in passedCards)
            {
                Discard(card);
            }
        }

        public void ReturnHandToDeck()
        {
            List<IPokerCard> returnedCards = hand.DiscardHand();

            deck.Discard(returnedCards);
        }

        public IReadOnlyList<IPokerCard> GetHand()
        {
            return hand.GetPokerHand().AsReadOnly();
        }

        public int GetNumberOfChips()
        {
            throw new NotImplementedException();
        }

        public void Ante()
        {
            throw new NotImplementedException();
        }

        public void Bet(int passedNumberOfChips)
        {
            throw new NotImplementedException();
        }

        ~ClassicPlayerState()
        {
            List<IPokerCard> returnedHand = hand.DiscardHand();

            deck.Discard(returnedHand);
        }
    }
}
