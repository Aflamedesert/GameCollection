using GameCollection.Games.Poker.PokerCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games.Poker.PlayingEntities;
using GameCollection.Games.Poker.PokerHand.PokerHands;

namespace GameCollection.Games.Poker.PokerGameObjects.PokerPlayerState
{
    public class ClassicPokerPlayerState : IClassicPokerPlayerState
    {
        IPlayingEntity playingEntity;

        IPokerHand pokerHand;

        int currentAmountBet;

        bool HasFolded;

        public ClassicPokerPlayerState(IPlayingEntity passedPlayingEntity, IPokerHand passedPokerHand)
        {
            playingEntity = passedPlayingEntity;

            pokerHand = passedPokerHand;

            HasFolded = false;

            currentAmountBet = 0;
        }

        //methods linked to IGetPlayerNameBehavior
        public string GetPlayerName()
        {
            return playingEntity.GetName();
        }

        //methods linked to IGetPlayerCardsBehavior
        public List<IPokerCard> GetPlayerCards()
        {
            return pokerHand.GetPokerHand();
        }

        //methods linked to IChipHandlingBehavior
        public int GetPlayerChipAmount()
        {
            return playingEntity.GetChipAmount();
        }

        public void AddChips(int passedAmount)
        {
            playingEntity.AddChips(passedAmount);
        }

        public void RemoveChips(int passedAmount)
        {
            playingEntity.RemoveChips(passedAmount);
        }

        // methods linked to IBettingRoundStateBehavior
        public void AddToAmountBet(int passedAmountToBeAdded)
        {
            currentAmountBet += passedAmountToBeAdded;
        }

        public int GetCurrentAmountBet()
        {
            return currentAmountBet;
        }

        public void ClearState()
        {
            currentAmountBet = 0;
        }

        //methods linked to IFoldingBehavior
        public void Fold()
        {
            HasFolded = true;
        }

        public bool HasPlayerFolded()
        {
            return HasFolded;
        }

        //methods linked to IEmptyHandBehavior
        public List<IPokerCard> EmptyHand()
        {
            return pokerHand.EmptyHand();
        }

        //methods linked to IAddToHandBehavior
        public void AddToHand(IPokerCard passedCard)
        {
            pokerHand.Add(passedCard);
        }

        public void AddToHand(List<IPokerCard> passedCards)
        {
            pokerHand.Add(passedCards);
        }

        //methods linked to IRemoveFromHandBehavior
        public IPokerCard RemoveFromHand(IPokerCard passedCard)
        {
            return pokerHand.Remove(passedCard);
        }

        public List<IPokerCard> RemoveFromHand(List<IPokerCard> passedCards)
        {
            return pokerHand.Remove(passedCards);
        }

        public IPokerCard RemoveFromHand(string passedCardType, string passedCardSuit)
        {
            return pokerHand.Remove(passedCardType, passedCardSuit);
        }

        public List<IPokerCard> RemoveFromHand(List<(string, string)> passedCardSignatures)
        {
            return pokerHand.Remove(passedCardSignatures);
        }
    }
}
