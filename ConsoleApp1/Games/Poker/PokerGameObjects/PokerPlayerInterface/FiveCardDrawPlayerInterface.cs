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

        //methods linked to IGetPlayerNameBehavior
        public string GetPlayerName()
        {
            return playerState.GetPlayerName();
        }

        //methods linked to IGetCardsInHandBehavior
        public List<IPokerCard> GetCardsInHand()
        {
            return playerState.GetPlayerCards();
        }

        //methods linked to IBettingRoundStateBehavior
        public int GetAmountBet()
        {
            return playerState.GetCurrentAmountBet();
        }

        public void AddToAmountBet(int passedAmountToBeAdded)
        {
            playerState.AddToAmountBet(passedAmountToBeAdded);
        }

        public void Clear()
        {
            playerState.ClearState();
        }

        //methods linked to IChipHandlingBehavior
        public int GetNumberOfChips()
        {
            return playerState.GetPlayerChipAmount();
        }

        public void AddChipsToPlayer(int passedAmount)
        {
            playerState.AddChips(passedAmount);
        }

        public void RemoveChipsFromPlayer(int passedAmount)
        {
            playerState.RemoveChips(passedAmount);
        }

        //methods linked to IFoldingBehavior
        public void Fold()
        {
            playerState.Fold();
        }

        public bool HasPlayerFolded()
        {
            return playerState.HasPlayerFolded();
        }

        //methods linked to IAddToHandBehavior
        public void AddToHand(IPokerCard passedCard)
        {
            playerState.AddToHand(passedCard);
        }

        public void AddToHand(List<IPokerCard> passedCards)
        {
            playerState.AddToHand(passedCards);
        }

        //methods linked to IEmptyHandBehavior
        public List<IPokerCard> EmptyHand()
        {
            return playerState.EmptyHand();
        }

        //methods linked to ICheckableBettingBehavior
        public void InitiateCheckableBet()
        {
            betSelector.InitializeCheckableBetSelection();
        }

        //methods linked to ICallableBettingBehavior
        public void InitiateCallableBet(int passedMinimumBetAmount)
        {
            betSelector.InitializeCallableBetSelection(passedMinimumBetAmount);
        }

        //methods linked to ICardActionBehavior
        public void InitiateCardAction()
        {
            cardActionSelector.InitializeCardActionSelection(GetCardsInHand());
        }

        //methods linked to IRemoveFromHandBehavior
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
