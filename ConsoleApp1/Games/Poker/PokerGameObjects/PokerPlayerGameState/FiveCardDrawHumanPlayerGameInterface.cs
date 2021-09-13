﻿using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.SharedCode.CardGames.Deck;
using GameCollection.Games.Poker.PokerGameObjects.GameBetting;
using GameCollection.Games.Poker.PokerHand.PokerHands;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerGameState
{
    public class FiveCardDrawHumanPlayerGameInterface : IDiscardableDrawableBettableHumanPlayerGameInterface
    {
        IDeck<IPokerCard> deck;

        IPokerHand hand;

        IHumanPlayerBetter playerBetter;

        public FiveCardDrawHumanPlayerGameInterface(IDeck<IPokerCard> passedPokerDeck, IPokerHand passedPokerHand, IHumanPlayerBetter passedHumanPlayerBetter)
        {
            deck = passedPokerDeck;

            hand = passedPokerHand;

            playerBetter = passedHumanPlayerBetter;
        }

        ~FiveCardDrawHumanPlayerGameInterface()
        {
            List<IPokerCard> cardsInHand = hand.DiscardHand();

            deck.Discard(cardsInHand);
        }

        public List<IPokerCard> GetCardsInHand()
        {
            return hand.GetPokerHand();
        }

        public void Draw()
        {
            IPokerCard drawnCard = deck.Draw();

            hand.Add(drawnCard);
        }

        public void Draw(int numberOfCardDraws)
        {
            List<IPokerCard> drawnCards = deck.Draw(numberOfCardDraws);

            hand.Add(drawnCards);
        }

        public void Discard(IPokerCard passedDiscardedCard)
        {
            IPokerCard discardedCard = hand.Discard(passedDiscardedCard);

            deck.Discard(discardedCard);
        }

        public void Discard(string passedCardType, string passedSuit)
        {
            IPokerCard discardedCard = hand.Discard(passedCardType, passedSuit);

            deck.Discard(discardedCard);
        }

        public void Discard(List<IPokerCard> passedDiscardedCards)
        {
            foreach(IPokerCard card in passedDiscardedCards)
            {
                Discard(card);
            }
        }

        public void Bet()
        {
            playerBetter.OpenBettingMenu();
        }
    }
}