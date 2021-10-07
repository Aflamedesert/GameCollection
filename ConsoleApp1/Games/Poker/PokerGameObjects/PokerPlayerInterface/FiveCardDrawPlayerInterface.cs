using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PokerGameObjects.PokerPlayerState;
using GameCollection.Games.Poker.PokerGameObjects.PokerBettingRound.BetSelection;
using GameCollection.Games.Poker.PokerGameObjects.PokerCardActionRound.CardActionSelection;
using GameCollection.Games.Poker.PlayingEntities;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerInterface
{
    public class FiveCardDrawPlayerInterface : IClassicPlayerInterface, ICardActionBehavior, IRemoveFromHandBehavior
    {
        IClassicPokerPlayerState playerState;

        IClassicBetSelector betSelector;

        ICardActionSelector cardActionSelector;

        public FiveCardDrawPlayerInterface(IClassicPokerPlayerState passedPlayerState, IClassicBetSelector passedBetSelector, ICardActionSelector passedCardActionSelector)
        {
            playerState = passedPlayerState;

            betSelector = passedBetSelector;

            cardActionSelector = passedCardActionSelector;
        }

        public void AddChipsToPlayer(int passedAmount)
        {
            playerState.AddChips(passedAmount);
        }

        public void AddToHand(IPokerCard passedCard)
        {
            playerState.AddToHand(passedCard);
        }

        public void AddToHand(List<IPokerCard> passedCards)
        {
            playerState.AddToHand(passedCards);
        }

        public List<IPokerCard> EmptyHand()
        {
            return playerState.EmptyHand();
        }

        public void Fold()
        {
            playerState.Fold();
        }

        public List<IPokerCard> GetCardsInHand()
        {
            return playerState.GetPlayerCards();
        }

        public int GetNumberOfChips()
        {
            return playerState.GetPlayerChipAmount();
        }

        public string GetPlayerName()
        {
            return playerState.GetPlayerName();
        }

        public bool HasPlayerFolded()
        {
            return playerState.HasPlayerFolded();
        }

        public void InitiateCallableBet(int passedMinimumBetAmount)
        {
            betSelector.InitializeCallableBetSelection(passedMinimumBetAmount);
        }

        public void InitiateCardAction()
        {
            cardActionSelector.InitializeCardActionSelection(GetCardsInHand());
        }

        public void InitiateCheckableBet()
        {
            betSelector.InitializeCheckableBetSelection();
        }

        public void RemoveChipsFromPlayer(int passedAmount)
        {
            playerState.RemoveChips(passedAmount);
        }

        public IPokerCard RemoveFromHand(IPokerCard passedCard)
        {
            return playerState.RemoveFromHand(passedCard);
        }

        public List<IPokerCard> RemoveFromHand(List<IPokerCard> passedCards)
        {
            return playerState.RemoveFromHand(passedCards);
        }

        public IPokerCard RemoveFromHand(string passedCardType, string passedCardSuit)
        {
            return playerState.RemoveFromHand(passedCardType, passedCardSuit);
        }

        public List<IPokerCard> RemoveFromHand(List<(string, string)> passedCardSignatures)
        {
            return playerState.RemoveFromHand(passedCardSignatures);
        }
    }
}
